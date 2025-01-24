namespace ElevenEleven.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; } = string.Empty;

        public string Stadium { get; set; } = string.Empty;
        public DateOnly FoundedYear { get; set; }

        public String League { get; set; } = String.Empty;
    }
}
