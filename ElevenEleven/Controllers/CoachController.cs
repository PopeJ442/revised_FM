using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElevenEleven.Controllers
{
    public class CoachController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CoachService _coachService;

        public CoachController(CoachService coachService, ApplicationDbContext context)
        {
            _coachService = coachService;
            _context = context;
        }
        public IActionResult Index()
        {
            var coach = _coachService.GetAllCoaches();
            return View(coach);
        }

        // GET: Coach/Details/5
        public IActionResult Details(int id)
        {
            var Coach = _coachService.GetCoachById(id);
            if (Coach == null)
                return NotFound();

            return View(Coach);
        }

        // GET: Coach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _coachService.AddCoach(coach);
                return RedirectToAction(nameof(Index));
            }

            return View(coach); // Returns the "Create" view with validation errors
        }

        // GET: Coach/Edit/5
        public IActionResult Edit(int id)
        {
            var coach = _coachService.GetCoachById(id);
            if (coach == null)
                return NotFound(); // Return 404 if Coach is not found

            return View(coach); // Returns the "Edit" view with the Coach data
        }

        // POST: Coach/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Coach coach)
        {
            if (id != coach.Id)
                return BadRequest(); // Return 400 if IDs don't match

            if (ModelState.IsValid)
            {
                _coachService.UpdateCoach(coach);
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }

            return View(coach); // Returns the "Edit" view with validation errors
        }

        // GET: Coach/Delete/5
        public IActionResult Delete(int id)
        {
            var coach = _coachService.GetCoachById(id);
            if (coach == null)
                return NotFound(); // Return 404 if Coach is not found

            return View(coach); // Returns the "Delete" confirmation view
        }

        // POST: Coach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _coachService.DeleteCoach(id);
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }
    }
}
