using Microsoft.AspNetCore.Mvc;
using System;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;

namespace ProjectManagement.Api.Controllers
{
    public class BaseController<T> : ControllerBase where T: BaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var result = _repository.Get(id);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(T entity)
        {
            var result =_repository.Add(entity);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(T entity)
        {
            var result =_repository.Update(entity);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var entity = _repository.Get(id);
            if(entity is null)
            {
                return BadRequest();
            }
            _repository.Delete(id);
            return Ok();
        }

    }
}
