using ElevenEleven.Enums;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace ElevenEleven.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public Country Nationality { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; } = string.Empty;

        public string ResidentialAddress { get; set; } = string.Empty;
        public int LicenseLevelId { get; set; }
        public int SpecializationId { get; set; }
        public int YearsOfExperience { get; set; }
        public string TeamAssigned { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; }
        public LicenseLevel? LicenseLevel { get; set; }
        public Specialization? Specialization { get; set; }
    }
}
