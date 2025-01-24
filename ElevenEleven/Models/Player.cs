using ElevenEleven.Enums;
using System.Data;

namespace ElevenEleven.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Country Nationality { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string ResidentialAddress { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public PreferredFoot PreferredFoot { get; set; }
      
        public ICollection<Role> Roles { get; set; } = [];
       

        public int Age
        {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public byte[]? ProfilePicture { get; set; }
    }
}
