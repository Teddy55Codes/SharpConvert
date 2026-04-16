using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace FileConverter.FileFormats;

public class PNGFile : IConvertableFile
{
    public string Name { get; } = "PNG";
    public string FileEnding { get; } = "png";
    public string[] ConvertableTo { get; } = ["JPEG"];

    public MemoryStream Convert(MemoryStream file, string targetFormat)
    {
        using Image image = Image.Load(file);
        using var result = new MemoryStream();
        
        switch(targetFormat)
        {
            case "JPEG":
                image.Save(result, JpegFormat.Instance);
                break;
        }

        return result;
    }
}