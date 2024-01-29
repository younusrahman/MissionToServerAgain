using api.Model;
using api.MongoDB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly MongoDBService _photoservice;
        public PhotoController(MongoDBService mongoDBService) => _photoservice = mongoDBService;


        // GET: api/<PhotoController>
        [HttpGet]
        public async Task<IEnumerable<Photo>> Get()
        {
            return await _photoservice.GetAsync();
        }

        // GET api/<PhotoController>/5
        [HttpGet("{id}")]
        public async Task<Photo> Get(string id)
        {
            return await _photoservice.GetAsync(id);
        }

        // POST api/<PhotoController>
        [HttpPost]
        public async void Post([FromBody] Photo photo)
        {
            await _photoservice.CreateAsync(photo);
        }

        // PUT api/<PhotoController>/5
        [HttpPut("{id}")]
        public async void Put(string id, [FromBody] Photo photo)
        {
            await _photoservice.UpdateAsync(id,photo);
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _photoservice.DeleteAsync(id);
        }
    }
}
