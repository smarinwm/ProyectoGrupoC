using GrupoC.Estanteria.DAL;
using Microsoft.AspNetCore.Mvc;

namespace GrupoC.Estanteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstanteriaController : ControllerBase
    {
        private readonly IEstanteriaProvider estanteriaProvider;
        public EstanteriaController(IEstanteriaProvider estanteriaProvider)
        {
            this.estanteriaProvider = estanteriaProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = estanteriaProvider.GetAsnyc(id);
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}
