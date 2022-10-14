using Grupo5.Producto.Controllers;
using Grupo5.Producto.DAL;
using Microsoft.AspNetCore.Mvc;

namespace TestProductos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAsyncReturnsOK()
        {
            var productosRepository = new ProductoRepository();
            var productsController = new ProductoController(productosRepository);

            var result = productsController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotOK()
        {
            var productosRepository = new ProductoRepository();
            var productosController = new ProductoController(productosRepository);

            var result = productosController.GetAsync("666").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}