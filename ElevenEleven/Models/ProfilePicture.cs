namespace ElevenEleven.Models
{
    public class ProfilePicture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Picture { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public DateTime UploadedOn { get; set; } = DateTime.Now;
    }
}
