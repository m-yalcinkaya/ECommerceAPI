using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.ViewModels;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;

        public ProductsController(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _readRepository.GetByIdAsync(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_readRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _writeRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });
            return Ok(await _writeRepository.SaveAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Product model)
        {
            Product p = await _readRepository.GetByIdAsync(model.Id);
            p.Stock = model.Stock;
            p.Price = model.Price;
            p.Name = model.Name;
            await _writeRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _writeRepository.RemoveAsync(id);
            await _writeRepository.SaveAsync();
            return Ok();
        }


    }
}
