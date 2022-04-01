using MediatR;

using MediatrSandbox.Api.Commands;
using MediatrSandbox.Api.Dtos;
using MediatrSandbox.Api.Entities;
using MediatrSandbox.Api.Queries;
using MediatrSandbox.Api.Repositories;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediatrSandbox.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IMediator _mediatr;

    public ItemsController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    // GET: api/<ItemsController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllItemsQuery();
        var result = await _mediatr.Send(query);
        
        return Ok(result);
    }

    // GET api/<ItemsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var query = new GetItemByIdQuery(id);
        var result = await _mediatr.Send(query);

        return result is null ? NotFound() : Ok(result);
    }

    // POST api/<ItemsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateItemCommand command)
    {
        var result = await _mediatr.Send(command);

        return CreatedAtAction(nameof(Get), new { itemId = result.Id }, result);
    }

    // PUT api/<ItemsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Item payload)
    {

    }

    // DELETE api/<ItemsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
}
