using FileConverter.FileFormats;
using FluentResults;

namespace FileConverter;

public static class FileConverter
{
    public static IConvertableFile[] SupportedFormats = [new PNGFile()];

    public static Result<MemoryStream> ConvertFile(MemoryStream originalFile, string format, string targetFormat)
    {
        var cf = SupportedFormats.FirstOrDefault(cf => cf.Name == format);
        if (cf is null)
        {
            return Result.Fail("File format not supported.");
        }

        if (!cf.ConvertableTo.Contains(targetFormat))
        {
            return Result.Fail($"File format {cf.Name} can not be converted to {targetFormat}.");
        }
        
        return cf.Convert(originalFile, targetFormat);
    }
}