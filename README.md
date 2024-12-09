# SVGConverter

A simple command-line application that converts SVG files to raster images (PNG, JPEG, BMP).

## Features

- **Batch Conversion**: Converts all SVG files in the specified source directory.
- **Multiple Output Formats**: Supports PNG, JPEG, and BMP formats.
- **Flexible Parameters**: Specify source directory, destination directory, and image format.
- **Default Behaviors**:
  - If the source directory is not specified, it uses the current directory.
  - If the destination directory is not specified, it creates one inside the source directory named `SVG-to-FORMAT` (e.g., `SVG-to-PNG`).
  - If the image format is not specified, it defaults to `png`.

## Requirements

- **.NET 8.0 SDK** or later
- **Svg.NET** library
- **System.CommandLine** library (version `2.0.0-beta4.22272.1` or later)

## Installation

1. **Clone the Repository**:

   
2. **Restore NuGet Packages**:

   
3. **Build the Application**:

   
## Publishing as a Single Executable (Optional)

To publish the application as a single executable file:

1. **Modify the `.csproj` File**:

   Ensure your `SVGConverter.csproj` includes the following properties:

   
2. **Publish the Application**:

   
   The single executable can be found in the `bin/Release/net8.0/win-x64/publish` directory.

## Usage


### Options

- `--source-directory`, `-s`:

  - **Description**: Source directory containing SVG files.
  - **Default**: Current directory.

- `--destination-directory`, `-d`:

  - **Description**: Destination directory for converted images.
  - **Default**: Creates a directory inside the source directory named `SVG-to-FORMAT` (e.g., `SVG-to-PNG`).

- `--image-format`, `-f`:

  - **Description**: Output image format.
  - **Valid Values**: `png`, `jpeg`, `bmp`.
  - **Default**: `png`.

### Examples

- **Convert SVGs in the current directory to PNG**:
- **Specify the source directory**:
- **Specify the destination directory**:  
- **Specify the image format**:
- **Full example with all options**:


## How It Works

1. **Command-Line Parsing**:

   Utilizes the `System.CommandLine` library to parse command-line options and arguments.

2. **Setting Defaults**:

   - If the source directory is not provided, the application uses the current working directory.
   - If the destination directory is not provided, it creates one inside the source directory with the naming pattern `SVG-to-FORMAT`.

3. **File Conversion Process**:

   - Scans the source directory for `.svg` files.
   - Converts each SVG file to the specified image format using the `Svg.NET` library.
   - Saves the converted images to the destination directory.

4. **Error Handling**:

   - Reports invalid formats.
   - Handles exceptions during file conversion without stopping the entire process.

## Dependencies

Ensure the following NuGet packages are installed:


## Supported Platforms

- **Windows** (`win-x64`, `win-x86`, `win-arm64`)
- **Linux** (`linux-x64`, `linux-arm64`)
- **macOS** (`osx-x64`, `osx-arm64`)

> **Note**: Adjust the `RuntimeIdentifier` in the `.csproj` file according to your target platform.

## Development

To contribute or modify the application:

1. **Open the Project**:

   Open `SVGConverter.sln` in Visual Studio 2022 or your preferred IDE.

2. **Modify the Code**:

   The main logic is in `Program.cs`. Adjust the functionality as needed.

3. **Testing**:

   - Run the application using `dotnet run`.
   - Test with different options to ensure all features work correctly.

## Troubleshooting

- **Installation Issues**:

  - If you encounter issues installing `System.CommandLine`, ensure you include the `-Prerelease` flag.
  - Example:

    
- **Ambiguous Method Calls**:

  - If you receive errors about ambiguous calls to `SvgDocument.Open<T>`, use the overload without the second parameter or cast `null` appropriately.
  - Example:

    
## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [Svg.NET](https://github.com/svg-net/SVG) for SVG processing.
- [System.CommandLine](https://github.com/dotnet/command-line-api) for command-line parsing.

