using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P230_Pronia.DAL;
using P230_Pronia.Entities;
using System.Numerics;

namespace P230_Pronia.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProniaDbContext _context;

        public ShopController(ProniaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Plant> plants = _context.Plants.Include(P => P.PlantImages)
                .Include(P => P.PlantDeliveryInformation)
                .Include(P => P.PlantCategories)
                .ThenInclude(P => P.Category)
                .Include(P => P.PlantTags)
                .ThenInclude(P => P.Tag)
                .ToList();
            return View(plants);
        }

        public IActionResult Index1(int id)
        {
            Plant? plant = _context.Plants.Include(P => P.PlantImages)
                .Include(P => P.PlantDeliveryInformation)
                .Include(P => P.PlantCategories)
                .ThenInclude(P => P.Category)
                .Include(P => P.PlantTags)
                .ThenInclude(P => P.Tag).FirstOrDefault(P => P.Id == id);
            return View(plant);
        }
    }
}
