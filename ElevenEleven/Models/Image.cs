namespace ElevenEleven.Models
{
    public class Image
    {
       // public int id { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public byte[] Content { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public DateTime UploadedOn { get; set; } = DateTime.Now;

    }
    
}
