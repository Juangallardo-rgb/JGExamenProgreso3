
namespace JGExamenProgreso3.Properties.Model
{
    public class JGBookModel
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Thumbnail { get; set; }
    }
    public class GoogleBooksResponse
    {
        public List<GoogleBookItem> Items { get; set; }
    }

    public class GoogleBookItem
    {
        public GoogleBookVolumeInfo VolumeInfo { get; set; }
    }

    public class GoogleBookVolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public GoogleBookImageLinks ImageLinks { get; set; }
    }

    public class GoogleBookImageLinks
    {
        public string Thumbnail { get; set; }
    }
}

