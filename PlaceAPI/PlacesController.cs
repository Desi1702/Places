using Microsoft.AspNetCore.Mvc;
using PlaatsNamen;
using Places;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaceAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        // GET: api/<PlacesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var placeDatabase = new PlaceDatabase("geo");
            return placeDatabase.AllPlaces();
        }

        // GET api/<PlacesController>/am
        [HttpGet("{place}")]
        public List<Place> Get(string place)
        {
            List<Place> result = [];
            if (!string.IsNullOrWhiteSpace(place))
            {
                var placeDatabase = new PlaceDatabase("geo");
                result = placeDatabase.Search(place);
            }
            return result;
        }
    }
}
