using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async void Get()
        {
            await _writeRepository.AddRangeAsync(new()
            {
                new() {Id=Guid.NewGuid(), Name="Product 1", Price = 100, createdDate = DateTime.UtcNow, Stock = 80 },
                new() {Id=Guid.NewGuid(), Name="Product 2", Price = 200, createdDate = DateTime.UtcNow, Stock = 60 },
                new() {Id=Guid.NewGuid(), Name="Product 3", Price = 300, createdDate = DateTime.UtcNow, Stock = 20 },
                new() {Id=Guid.NewGuid(), Name="Product 4", Price = 400, createdDate = DateTime.UtcNow, Stock = 50 },
                new() {Id=Guid.NewGuid(), Name="Product 5", Price = 500, createdDate = DateTime.UtcNow, Stock = 120 },
            });

            await _writeRepository.SaveAsync();
        }


    }
}
