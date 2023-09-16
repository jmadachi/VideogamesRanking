using System.Security.Claims;

namespace VideogamesRanking.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly ApplicationDatabaseContext context;

        public UserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            ApplicationDatabaseContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Crear([FromBody] LoginRequest login)
        {
            var usuario = new IdentityUser { UserName = login.Email, Email = login.Email };
            var resultado = await userManager.CreateAsync(usuario, login.Password);

            if (resultado.Succeeded)
            {
                return await generarToken(login);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] LoginRequest login)
        {
            var resultado = await signInManager.PasswordSignInAsync(login.Email, login.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return await generarToken(login);
            }
            else
            {
                return BadRequest("Login Error");
            }
        }

        private async Task<AuthenticationResponse> generarToken(LoginRequest login)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", login.Email)
            };

            var usuario = await userManager.FindByEmailAsync(login.Email);
            var claimsDB = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddHours(24);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);

            return new AuthenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiracion
            };
        }
    }
}
