using System.IO;

namespace ScoresRanking.WebApi.Controllers
{
    [ApiController]
    [Route("api/score")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ScoreController : ControllerBase
    {
        private readonly ScoreUseCases ScoreUseCases;

        public ScoreController(ScoreUseCases scoreUseCases)
        {
            ScoreUseCases = scoreUseCases;
        }


        [HttpGet("{number}")]
        public async  Task<IActionResult> GenerarArchivoPlano(int number)
        {
            try
            {
                var result = await ScoreUseCases.ReadSeveral(number);
                // Ruta del archivo de salida (ajusta la ruta según tu necesidad)
                string rutaArchivo = "ranking.csv";

                int middle = result.ToList().Count / 2;
                // Crear el archivo y escribir los resultados
                using (StreamWriter sw = new StreamWriter(rutaArchivo))
                {
                    int i = 0;
                    foreach (var resultado in result)
                    {
                        i++;
                        string category = i >= middle ? "AAA" : "GOTY";
                        sw.WriteLine($"{resultado.Title}|{resultado.Company}|{resultado.Score.ToString("N2")}|{category}");
                    }
                }

                byte[] archivoBytes = System.IO.File.ReadAllBytes(rutaArchivo);
                string tipoContenido = "text/plain";
                string nombreArchivo = "ranking.csv";

                return File(archivoBytes, tipoContenido, nombreArchivo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


    }
}
