param (
    [string]$inputImage,
    [string]$targetDimension,
    [string]$outputWithoutExtension,
    [ValidateSet("ico", "png", "jpeg")][string]$outputFormat
)

Write-Host "Usage: .\magickps.ps1 -inputImage <inputImageName> -targetDimension <width>x<height> -outputWithoutExtension <outputWithoutExtension> -outputFormat <format>"

if (-not $inputImage) {
    $inputImage = Read-Host "Enter the input image name (e.g., 'example')"
}
if (-not $targetDimension) {
    $targetDimension = Read-Host "Enter the target dimension (e.g., '100x100')"
}
if (-not $outputIco) {
    $outputWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($inputImage)
}
if (-not $outputFormat) {
    $outputFormat = Read-Host "Enter the output format (e.g., 'ico', 'png')"
}

# Validate the required parameters (inputImage and outputFormat are required)
if (-not $inputImage) {
    Write-Host "The input image is required."
    exit
}

if (-not $outputFormat) {
    Write-Host "The output format is required."
    exit
}

$sizes = @("1024x1024", "512x512", "256x256", "128x128", "64x64", "48x48", "32x32", "16x16")

foreach ($size in $sizes) {
    $outputWithExtension = "$outputWithoutExtension-$size.$outputFormat"
    magick $inputImage -resize $size $outputWithExtension

    Write-Host "Created $outputWithExtension with size $size"
}