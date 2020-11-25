using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using TechnoStore.Models;
using TechnoStore.Services.Interfaces;
using Newtonsoft.Json;


namespace TechnoStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }


        [HttpGet]
        public IEnumerable<Category> GetAllCategories()
        {
            return _homeService.GetAllCategories;
        }

        public async Task<IActionResult> GetCategory(int id)
        {
            var category = _homeService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string name, string imagePath)
        { 
            var category = await _homeService.CreateCategory(name, imagePath);

            return CreatedAtAction("GetCategory", new {id = category.Id}, category);


        }
    }
}
