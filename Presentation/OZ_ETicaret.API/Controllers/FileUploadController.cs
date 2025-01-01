using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OZ_ETicaret.Application.Abstracts.Services;
using OZ_ETicaret.Application.Features.Commands.ProductImageFileCommands.AddProductImageFileCommand;

namespace OZ_ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController(IFileService fileService, IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFiles(AddProductImageFileCommandRequest addProductImageFileCommandRequest)
        {
            await mediator.Send(addProductImageFileCommandRequest);
            return Ok();



            //var files = Request.Form.Files;
            //var result = await fileService.UploadFiles(files);
            //return Ok(result);
        }
    }
}
