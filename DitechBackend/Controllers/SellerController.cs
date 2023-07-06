using DAL;
using DAL.Models;
using DitechBackend.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DitechBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IUnitOfWork _uinitOfWork;

        public SellerController(IUnitOfWork uinitOfWork)
        {
            _uinitOfWork = uinitOfWork;
        }

        // GET: api/<SellerController>
        [HttpGet]
        public ActionResult<IEnumerable<Seller>> Get()
        {
            try
            {
                return Ok(_uinitOfWork.Sellers.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<SellerController>/5
        [HttpGet("{id}")]
        public ActionResult<Seller> Get(int id)
        {
            try
            {
                var result = _uinitOfWork.Sellers.Get(x => x.Id == id, "City");
                result.City.Sellers = null;



                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<SellerController>
        [HttpPost]
        public ActionResult<Seller> Post(SellerModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SellerModel, Seller>();
                });

                    var mapper = config.CreateMapper();

                    Seller seller = mapper.Map<Seller>(value);

                    _uinitOfWork.Sellers.Add(seller);

                    _uinitOfWork.Save();


                    return Ok(seller);
                }
                return UnprocessableEntity(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<SellerController>/5
        [HttpPut("{id}")]
        public ActionResult<Seller> Put(int id, SellerModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SellerModel, Seller>();
                });
                    var mapper = config.CreateMapper();

                    Seller seller = mapper.Map<Seller>(value);
                    seller.Id = id;

                    _uinitOfWork.Sellers.Update(seller);
                    _uinitOfWork.Save();

                    return Ok(seller);
                }
                return UnprocessableEntity(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // DELETE api/<SellerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _uinitOfWork.Sellers.Delete(id);
                _uinitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
