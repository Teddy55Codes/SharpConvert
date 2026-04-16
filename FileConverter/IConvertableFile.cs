namespace FileConverter;

public interface IConvertableFile
{
    public string Name { get; }
    public string FileEnding { get; }
    public string[] ConvertableTo { get; }
    
    public MemoryStream Convert(MemoryStream file, string targetFormat);
}