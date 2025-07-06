using App.Services.Models;
using App.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => HandleServiceResult(await productService.GetAllAsync());

        [HttpGet("{pageNumber:int}/{pageSize:int}") ]
        public async Task<IActionResult> GetPagedAllDataAsync(int pageNumber, int pageSize) 
            => HandleServiceResult(await productService.GetPagedAllDataAsync(pageNumber, pageSize));


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id) => HandleServiceResult(await productService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest productDto) => CreateActionResult(await productService.CreateAsync(productDto));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProductRequest productDto) => HandleServiceResult(await productService.UpdateAsync(id, productDto));

        [HttpPatch("stock")]
        public async Task<IActionResult> UpdateStockAsync(int id, [FromBody] int stock) => HandleServiceResult(await productService.UpdateStockAsync(id, stock));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id) => HandleServiceResult(await productService.DeleteAsync(id));


    }
}
