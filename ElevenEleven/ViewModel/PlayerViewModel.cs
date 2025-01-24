using ElevenEleven.Models;
using Microsoft.AspNetCore.Http;

namespace ElevenEleven.ViewModel
{
    public class PlayerViewModel
    {
        public Player Player { get; set; } = new Player();
       public IFormFile ProfileImage { get; set; }
    }
}
