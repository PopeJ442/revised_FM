using ElevenEleven.Data;
using ElevenEleven.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElevenEleven.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string title, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("imageFile", "Please select an image file.");
                return View();
            }

            using var memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream);

            var image = new Image
            {
                Title = title,
                Content = memoryStream.ToArray(),
                ContentType = imageFile.ContentType,
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Images/Index
        public IActionResult Index()
        {
            var images = _context.Images.ToList();
            return View(images);
        }
    }
}
