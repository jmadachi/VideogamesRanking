namespace VideogamesRanking.WebApi.Controllers
{
    [ApiController]
    [Route("api/videogame")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VideogameController : ControllerBase
    {
        private readonly VideogameUseCases VideogameUseCases;

        public VideogameController(VideogameUseCases videogameUseCases)
        {
            VideogameUseCases = videogameUseCases;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videogame>>> ReadVideogames()
        {
            try
            {
                var result = await VideogameUseCases.ReadSeveral();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<IEnumerable<Videogame>>> ReadVideogame(long id)
        {
            try
            {
                var result = await VideogameUseCases.ReadOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Videogame>> CreateVideogame(CreateVideogameDto newVideogame)
        {
            try
            {
                var result = await VideogameUseCases.Create(newVideogame);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Videogame>> UpdateVideogame(VideogameDto newVideogame)
        {
            try
            {
                var result = await VideogameUseCases.Update(newVideogame);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Videogame>> DeleteVideogame(long id)
        {
            var result = await VideogameUseCases.ReadOne(id);
            await VideogameUseCases.Delete(id);
            return Ok(result);
        }

    }
}
