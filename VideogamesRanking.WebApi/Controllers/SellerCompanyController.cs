using Microsoft.AspNetCore.Authorization;
using VideogamesRanking.UseCases;

namespace MFT.WebApi.Controllers
{
    [ApiController]
    [Route("api/sellerCompany")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SellerCompanyController : ControllerBase
    {
        private readonly SellerCompanyUseCases SellerCompanyUseCases;

        public SellerCompanyController(SellerCompanyUseCases tournamentUseCases)
        {
            SellerCompanyUseCases = tournamentUseCases;
        }

        [HttpGet]
        public async ValueTask<ActionResult<IEnumerable<SellerCompany>>> ReadSeveral()
        {
            try
            {
                var result = await SellerCompanyUseCases.ReadSeveral();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:long}")]
        public async ValueTask<ActionResult<IEnumerable<SellerCompany>>> ReadOne(long id)
        {
            try
            {
                var result = await SellerCompanyUseCases.ReadOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async ValueTask<ActionResult<SellerCompany>> Create(CreateSellerCompanyDto newSellerCompany)
        {
            try
            {
                var result = await SellerCompanyUseCases.Create(newSellerCompany);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async ValueTask<ActionResult<SellerCompany>> Update(SellerCompanyDto newSellerCompany)
        {
            try
            {
                var result = await SellerCompanyUseCases.Update(newSellerCompany);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<ActionResult<SellerCompany>> Delete(long id)
        {
            var result = await SellerCompanyUseCases.ReadOne(id);
            await SellerCompanyUseCases.Delete(id);
            return Ok(result);
        }

    }
}
