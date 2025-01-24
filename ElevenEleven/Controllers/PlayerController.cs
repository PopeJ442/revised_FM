using ElevenEleven.Data;
using ElevenEleven.Models;
using ElevenEleven.Services;
using ElevenEleven.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ElevenEleven.Controllers
{
    public class PlayerController : Controller
    {
       // private readonly ApplicationDbContext _context;
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService, ApplicationDbContext context)
        {
            _playerService = playerService;
         //   _context = context;
        }

        // GET: Player
        public IActionResult Index()
        {
            var players = _playerService.GetAllPlayers();
            return View(players);
        }

        // GET: Player/Details/5
        public IActionResult Details(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
                return NotFound();

            return PartialView("_Details", player);
        }


        public IActionResult CreateStep1()
        {
            var model = TempData["Player"] != null
                ? JsonSerializer.Deserialize<Player>(TempData["Player"].ToString())
                : new Player();

            TempData.Keep("Player"); // Retain TempData for subsequent requests
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateStep1(Player player)
        {
            TempData["Player"] = JsonSerializer.Serialize(player); // Save data
            TempData.Keep("Player"); // Retain TempData
            return RedirectToAction("CreateStep2");
        }

        public IActionResult CreateStep2()
        {
            var model = TempData["Player"] != null
                ? JsonSerializer.Deserialize<Player>(TempData["Player"].ToString())
                : new Player();

            TempData.Keep("Player"); // Retain TempData
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateStep2(Player player)
        {
            var previousPlayer = TempData["Player"] != null
                ? JsonSerializer.Deserialize<Player>(TempData["Player"].ToString())
                : new Player();

            previousPlayer.Nationality = player.Nationality;
            previousPlayer.PhoneNumber = player.PhoneNumber;
            previousPlayer.EmailAddress = player.EmailAddress;
            previousPlayer.ResidentialAddress = player.ResidentialAddress;

            TempData["Player"] = JsonSerializer.Serialize(previousPlayer); // Update TempData
            TempData.Keep("Player"); // Retain TempData
            return RedirectToAction("CreateStep3");
        }

        public IActionResult CreateStep3()
        {
            var model = TempData["Player"] != null
                ? JsonSerializer.Deserialize<Player>(TempData["Player"].ToString())
                : new Player();

            TempData.Keep("Player"); // Retain TempData
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateStep3(Player player)
        {
            var completePlayer = TempData["Player"] != null
                ? JsonSerializer.Deserialize<Player>(TempData["Player"].ToString())
                : new Player();

            completePlayer.Height = player.Height;
            completePlayer.Weight = player.Weight;
            completePlayer.PreferredFoot = player.PreferredFoot;

            _playerService.AddPlayer(completePlayer); // Save to database
            TempData.Clear(); // Clear TempData once saving is complete

            return RedirectToAction("Index");
        }



        // GET: Player/Edit/5
        public IActionResult Edit(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
                return NotFound(); // Return 404 if player is not found

            return PartialView("_Edit", player); // Returns the "Edit" view with the player data
        }

        // POST: Player/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Player player)
        {
            if (id != player.Id)
                return BadRequest(); // Return 400 if IDs don't match

            if (ModelState.IsValid)
            {
                _playerService.UpdatePlayer(player);
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }

            return PartialView("_Edit", player); // Returns the "Edit" view with validation errors
        }
       
        
        // GET: Player/Delete/5
        public IActionResult Delete(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
                return NotFound(); 

            return PartialView("_Delete", player); 
        }


         //POST: Player/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Player player)
        {
            _playerService.DeletePlayer(id);
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }

      

    }
}

