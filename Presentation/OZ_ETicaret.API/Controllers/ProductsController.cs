using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OZ_ETicaret.Application.Features.Commands.ProductCommands.AddProductCommand;
using OZ_ETicaret.Application.Features.Commands.ProductCommands.AddRangeProductCommand;
using OZ_ETicaret.Application.Features.Commands.ProductCommands.DeleteProductCommand;
using OZ_ETicaret.Application.Features.Commands.ProductCommands.UpdateProductCommand;
using OZ_ETicaret.Application.Features.Queries.ProductQueries.GetAllProductQuery;
using OZ_ETicaret.Application.Features.Queries.ProductQueries.GetProductByIdQuery;
using OZ_ETicaret.Application.Features.Queries.ProductQueries.GetProductsByCategoryQuery;
using OZ_ETicaret.Application.Repositories.ProductRepositories;

namespace OZ_ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse result = await mediator.Send(getAllProductQueryRequest);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductById([FromQuery]GetProductByIdQueryRequest getProductByIdQueryRequest)
        {
            GetProductByIdQueryResponse result = await mediator.Send(getProductByIdQueryRequest);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsByCategory([FromQuery]GetProductsByCategoryQueryRequest getProductsByCategoryQueryRequest)
        {
            var response = await mediator.Send(getProductsByCategoryQueryRequest);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes ="Bearer", Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductCommandRequest addProductCommandRequest)
        {
            await mediator.Send(addProductCommandRequest);
            return Ok();
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddProducts(AddRangeProductCommandRequest addRangeProductCommandRequest)
        {
            await mediator.Send(addRangeProductCommandRequest);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
        {
            await mediator.Send(updateProductCommandRequest);
            return Ok();
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery]DeleteProductCommandRequest deleteProductCommandRequest)
        {
            await mediator.Send(deleteProductCommandRequest);
            return Ok();
        }
    }
}
