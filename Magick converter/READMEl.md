# SVG to Magick Converter

This project provides a script to convert SVG files using ImageMagick.

## How to Use

1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Run the PowerShell script `magickps.ps1` to perform the conversion.

## Script Explanation

### `magickps.ps1`

The `magickps.ps1` script is a PowerShell script designed to convert SVG files to other image formats using ImageMagick. Here is a brief explanation of how it works:

1. **Input Parameters**: The script accepts input parameters for the source SVG file and the desired output format.
2. **ImageMagick Command**: It constructs an ImageMagick command based on the input parameters.
3. **Execution**: The script executes the ImageMagick command to perform the conversion.
4. **Output**: The converted file is saved in the specified output format.

### Example Usage

```powershell
.\magickps.ps1 -InputFile "example.svg" -OutputFormat "png"
```

This command will convert `example.svg` to `example.png` using ImageMagick.

## Requirements

- PowerShell
- ImageMagick

You can easily install ImageMagick using `winget` with the following command:

```powershell
winget install --id ImageMagick.ImageMagick
```

Make sure both are installed and properly configured on your system.

## Contributing

Suggestions and ideas are welcome!