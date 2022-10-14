using GrupoC.Estanteria.Controllers;
using GrupoC.Estanteria.DAL;
using Microsoft.AspNetCore.Mvc;

namespace TestEstanteria
{
    [TestClass]
    public class EstanteriaTest
    {
        [TestMethod]
        public void GetAsyncReturnsOK()
        {
            var productosRepository = new EstanteriaProvider();
            var productsController = new EstanteriaController(productosRepository);

            var result = productsController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotOK()
        {
            var productosRepository = new EstanteriaProvider();
            var productosController = new EstanteriaController(productosRepository);

            var result = productosController.GetAsync("666").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}