using DAL;
using DAL.Models;
using DitechBackend.ModelDTO;
using DitechBackend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DitechBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _uinitOfWork;

        public CityController(IUnitOfWork uinitOfWork)
        {
            _uinitOfWork = uinitOfWork;
        }

        // GET: api/<CityController>
        [HttpGet]
        public ActionResult<IEnumerable<City>> Get()
        {
            try
            {
                return Ok(_uinitOfWork.Cities.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            try
            {
                return Ok(_uinitOfWork.Cities.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<CityController>
        [HttpPost]
        public ActionResult<City> Post(CityModel values)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var city = new City()
                    {
                        Description = values.Description
                    };


                    _uinitOfWork.Cities.Add(city);

                    _uinitOfWork.Save();

                    return Ok(city);
                }
                return UnprocessableEntity(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public ActionResult<City> Put(int id, CityModel values)
        {
            try
            {
                if (ModelState.IsValid) {
                    var city = new City()
                    {
                        Id = id,
                        Description = values.Description
                    };


                    _uinitOfWork.Cities.Update(city);

                    _uinitOfWork.Save();

                    return Ok(city);
                }

                return UnprocessableEntity(ModelState);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var query = _uinitOfWork.Sellers.Get(x => x.CityId == id);
                if (query == null)
                {
                    _uinitOfWork.Cities.Delete(id);
                    _uinitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(new ErrorModel() { Message = "Existen usuarios que están asociados con la ciudad, debe eliminarlos o editarlos primero" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
