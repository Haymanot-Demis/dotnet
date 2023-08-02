public class MediaItems
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }

    public MediaItems(string title, string mediaType, int duration)
    {
        Id = Guid.NewGuid();
        Title = title;
        MediaType = mediaType;
        Duration = duration;
    }

}