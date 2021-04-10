using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ContentNegotiation.Models;
using Microsoft.Extensions.Logging;

namespace ContentNegotiation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AdventureWorks2019Context _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(AdventureWorks2019Context context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        //[Produces("application/json")]
        [FormatFilter]
        public IEnumerable<Product> Get()
        {
            var products = _context.Products.Take(5).ToArray();
            return products;
        }
    }
}
