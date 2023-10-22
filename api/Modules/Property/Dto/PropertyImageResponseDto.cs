public record PropertyImageResponseDto
{
    public Guid Id { get; init; }
    public Guid PropertyId { get; init; }
    public string FileName { get; init; }
    public string FilePath { get; init; }
    public string FileType { get; init; }
    public int FileSize { get; init; }
    public Guid UploadedById { get; init; }
}