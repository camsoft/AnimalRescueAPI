using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnimalRescue.Services.Interfaces;
using System.Runtime.Serialization.Json;
//using System.Xml;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AnimalRescueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        public readonly IAnimalsService animalService;
        public AnimalsController(IAnimalsService _animalsService) 
        {
            animalService = _animalsService;
        }

        [HttpGet]
        [Route("GetAnimals")]
        public async Task<IActionResult> GetAnimals()
        {
            var model = await animalService.GetAnimals();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = new ReferenceLoopHandling(),
                Formatting = Formatting.Indented
            };

            settings.Converters.Add(new StringEnumConverter());
            var json = JsonConvert.SerializeObject(model, settings);

            return Ok(json);
        }
    }
}
