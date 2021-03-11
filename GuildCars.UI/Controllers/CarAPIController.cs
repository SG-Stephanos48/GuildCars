using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class CarAPIController : ApiController
    {

        [Route("api/inventory/searchnew")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNew(string magicTerm, decimal? maxPrice, decimal? minPrice, string minYear, string maxYear)
        {
            var repo = GuildCarsRepositoryFactory.GetRepository();

            try
            {
                var parameters = new CarSearchParameters
                {
                    MagicTerm = magicTerm,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinMfgYear = minYear,
                    MaxMfgYear = maxYear
                };

                var result = repo.SearchNew(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/searchused")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsed(string magicTerm, decimal? maxPrice, decimal? minPrice, string minYear, string maxYear)
        {
            var repo = GuildCarsRepositoryFactory.GetRepository();

            try
            {
                var parameters = new CarSearchParameters
                {
                    MagicTerm = magicTerm,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinMfgYear = minYear,
                    MaxMfgYear = maxYear
                };

                var result = repo.SearchUsed(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/searchsales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchSales(string magicTerm, decimal? maxPrice, decimal? minPrice, string minYear, string maxYear)
        {
            var repo = GuildCarsRepositoryFactory.GetRepository();

            try
            {
                var parameters = new CarSearchParameters
                {
                    MagicTerm = magicTerm,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinMfgYear = minYear,
                    MaxMfgYear = maxYear
                };

                var result = repo.SearchSales(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/searchadmin")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchAdmin(string magicTerm, decimal? maxPrice, decimal? minPrice, string minYear, string maxYear)
        {
            var repo = GuildCarsRepositoryFactory.GetRepository();

            try
            {
                var parameters = new CarSearchParameters
                {
                    MagicTerm = magicTerm,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinMfgYear = minYear,
                    MaxMfgYear = maxYear
                };

                var result = repo.SearchSales(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/contact/add/{VIN}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult ContactVIN(string VIN)
        {
            var repo = GuildCarsRepositoryFactory.GetRepository();

            try
            {
                repo.ContactUs(VIN);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
