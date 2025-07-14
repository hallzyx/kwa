using System.Net.Mime;
using casokohler.crm.Application.Internal.CommandServices;
using casokohler.crm.Domain.Services;
using casokohler.crm.Interfaces.Resources;
using casokohler.crm.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace casokohler.crm.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("PreSet management operations")]
public class PreSetController(IPreSetCommandService preSetCommandService): ControllerBase
{
    [HttpPost("{customerId}/products/{productId}/pre-sets")]
    [SwaggerOperation("Create a new PreSet")]
    [SwaggerResponse(201, type: typeof(PreSetResource))]
    [SwaggerResponse(400, "Invalid input data")]
    public async Task<ActionResult> CreatePreSet(
        [FromRoute] string productId,
        [FromRoute] string customerId,
        [FromBody] CreatePreSetResource resource)
    {
        try
        {
            var command = CreatePreSetCommandFromResourceAssembler.ToCreatePreSetCommandFromResource(productId, customerId,resource);
            var newPreSet = await preSetCommandService.Handle(command);
            if(newPreSet == null) return BadRequest("PreSet creation failed.");
            var preSetResource = PreSetResourceFromEntityAssembler.ToPreSetResourceFromEntity(newPreSet);
            return Created(string.Empty, preSetResource);

        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
        
    }
}