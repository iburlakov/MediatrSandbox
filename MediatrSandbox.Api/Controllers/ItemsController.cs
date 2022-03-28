using MediatR;

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
    private readonly IRepository<Item> _itemRepository;
    private readonly IMediator _mediatr;

    public ItemsController(IRepository<Item> itemRepository, IMediator mediatr)
    {
        _itemRepository = itemRepository;
        _mediatr = mediatr;
    }

    // GET: api/<ItemsController>
    [HttpGet]
    public ActionResult<IAsyncEnumerable<Item>> Get()
    {
  
        var items = _itemRepository.GetAll();        

        return Ok(items);
    }

    // GET api/<ItemsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var item = await _itemRepository.Get(id);

        return Ok(item);
    }

    // POST api/<ItemsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Item payload)
    {
        await _itemRepository.Create(payload);
            
        return Ok(payload);
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
