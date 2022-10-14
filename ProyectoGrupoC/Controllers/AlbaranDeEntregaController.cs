using GrupoC.AlbaranDeEntrega.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace GrupoC.AlbaranDeEntrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbaranDeEntregaController : ControllerBase
    {
        private readonly IEstanteriaService estanteriaService;
        private readonly IProductoService productoService;

        public AlbaranDeEntregaController(IEstanteriaService estanteriaService, IProductoService productoService)
        {
            this.estanteriaService = estanteriaService;
            this.productoService = productoService;
        }

        [HttpGet("estanterias/{estanteriaId}")]
        public async Task<IActionResult> AlbaranAsync(string estanteriaId)
        {
            if (string.IsNullOrWhiteSpace(estanteriaId)) return BadRequest();
            try
            {
                var estanterias = await estanteriaService.GetAsync(estanteriaId);

                foreach (var item in estanterias.Productos)
                {
                    var product = await productoService.GetAsync(item.ProductoId);
                    item.Producto = product;
                }


                return Ok(estanterias);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
