using Microsoft.AspNetCore.Mvc;
using Model.DB;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController<TEntity> : ControllerBase where TEntity : DbEntity
{
    protected readonly IBaseService<TEntity> Service;

    protected BaseController(IBaseService<TEntity> service)
    {
        Service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    public virtual ActionResult<IEnumerable<TEntity>> GetAll()
    {
        var entities = Service.GetAll();
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public virtual ActionResult<TEntity> GetById(object id)
    {
        var entity = Service.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    //[HttpPost]
    //public virtual ActionResult<TEntity> Create(TEntity entity)
    //{
    //    if (entity == null)
    //    {
    //        return BadRequest("Entity object is null");
    //    }
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest("Invalid model object");
    //    }
    //    _service.Insert(entity);
    //    return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    //}

    //[HttpPut("{id}")]
    //public virtual ActionResult<TEntity> Update(object id, [FromBody] TEntity entity)
    //{
    //    if (entity == null)
    //    {
    //        return BadRequest("Entity object is null");
    //    }
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest("Invalid model object");
    //    }
    //    var existingEntity = _service.GetById(id);
    //    if (existingEntity == null)
    //    {
    //        return NotFound();
    //    }
    //    _service.Update(entity);
    //    return NoContent();
    //}


    [HttpDelete("{id}")]
    public virtual ActionResult Delete(object id)
    {
        var entity = Service.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        Service.Delete(id);
        return NoContent();
    }
}