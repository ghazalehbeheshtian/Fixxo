using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {







        private readonly ProductRepository _repository;

        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }





        #region GET

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            var product = await _repository.GetAsync(productId);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpGet("tag/{tagName}")]
        public async Task<IActionResult> GetByTag(string tagName)
        {
            return Ok(await _repository.GetAllByTagAsync(tagName));
        }

        public ProductRepository Get_repository()
        {
            return _repository;
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<IActionResult> Create(ProductHttpResquest request)
        {
            if (ModelState.IsValid)
            {
                var product = await _repository.CreateAsync(request);

                if (product != null)
                {
                    return Created("", product);
                }
            }

            return BadRequest();
        }

    }

    #endregion

  
}

