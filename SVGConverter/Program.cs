using System.CommandLine;
using Svg; // Requires Svg.NET package

namespace SVGConverter
{
    internal class Program
    {
        static int Main(string[] args)
        {
            // Create the root command
            var rootCommand = new RootCommand("Converts SVG files to raster images (PNG, JPEG, BMP).");

            // Define options
            var sourceOption = new Option<DirectoryInfo>(
                new[] { "--source-directory", "-s" },
                description: "Source directory containing SVG files.")
            {
                IsRequired = false
            };

            var destOption = new Option<DirectoryInfo>(
                new[] { "--destination-directory", "-d" },
                description: "Destination directory for converted images.")
            {
                IsRequired = false
            };

            var formatOption = new Option<string>(
                new[] { "--image-format", "-f" },
                () => "png",
                "Output image format: png, jpeg, bmp.");

            // Add options to the root command
            rootCommand.AddOption(sourceOption);
            rootCommand.AddOption(destOption);
            rootCommand.AddOption(formatOption);

            // Set the handler
            rootCommand.SetHandler((DirectoryInfo sourceDir, DirectoryInfo destDir, string format) =>
            {
                // Default source directory to current directory if not specified
                if (sourceDir == null)
                {
                    sourceDir = new DirectoryInfo(Directory.GetCurrentDirectory());
                }

                // Validate the output format
                format = format.ToLower();
                var validFormats = new[] { "png", "jpeg", "bmp" };
                if (!validFormats.Contains(format))
                {
                    Console.WriteLine($"Invalid format '{format}'. Valid formats are: png, jpeg, bmp.");
                    return;
                }

                // Default destination directory if not specified
                if (destDir == null)
                {
                    string destDirName = $"SVG-to-{format.ToUpper()}";
                    destDir = new DirectoryInfo(Path.Combine(sourceDir.FullName, destDirName));
                }

                // Check if source directory exists
                if (!sourceDir.Exists)
                {
                    Console.WriteLine($"Source directory does not exist: {sourceDir.FullName}");
                    return;
                }

                // Create destination directory if it doesn't exist
                if (!destDir.Exists)
                {
                    destDir.Create();
                    Console.WriteLine($"Created destination directory: {destDir.FullName}");
                }

                // Get all SVG files in source directory
                FileInfo[] svgFiles = sourceDir.GetFiles("*.svg");

                if (svgFiles.Length == 0)
                {
                    Console.WriteLine("No SVG files found in the source directory.");
                    return;
                }

                foreach (FileInfo svgFile in svgFiles)
                {
                    try
                    {
                        // Load SVG document without the second parameter
                        var svgDoc = SvgDocument.Open<SvgDocument>(svgFile.FullName);

                        // Convert SVG to bitmap
                        using (var bitmap = svgDoc.Draw())
                        {
                            // Prepare the output file path
                            string fileName = Path.GetFileNameWithoutExtension(svgFile.Name);
                            string destFilePath = Path.Combine(destDir.FullName, fileName + "." + format);

                            // Determine the image format
                            var imageFormat = format switch
                            {
                                "png" => System.Drawing.Imaging.ImageFormat.Png,
                                "jpeg" => System.Drawing.Imaging.ImageFormat.Jpeg,
                                "bmp" => System.Drawing.Imaging.ImageFormat.Bmp,
                                _ => System.Drawing.Imaging.ImageFormat.Png,
                            };

                            // Save the bitmap in the specified format
                            bitmap.Save(destFilePath, imageFormat);
                            Console.WriteLine($"Converted {svgFile.FullName} to {destFilePath}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting file {svgFile.FullName}: {ex.Message}");
                    }
                }

                Console.WriteLine("Conversion complete.");

            }, sourceOption, destOption, formatOption);

            // Invoke the root command
            return rootCommand.Invoke(args);
        }
    }
}
