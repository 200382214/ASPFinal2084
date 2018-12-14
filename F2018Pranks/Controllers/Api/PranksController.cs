using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using F2018Pranks.Models;

namespace F2018Pranks.Controllers.Api
{
    public class PranksController : ApiController
    {
        private Models.DbModel db = new Models.DbModel();

        // GET: api/Pranks
        public IQueryable<Prank> GetPranks()
        {
            return db.Pranks;
        }

        // GET: api/Pranks/5
        [ResponseType(typeof(Prank))]
        public IHttpActionResult Get(int id)
        {
            Prank prank = db.Pranks.SingleOrDefault(p => p.PrankId == id);

            if (prank == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(prank);
            }
        }



        // POST: api/Pranks
        [ResponseType(typeof(Prank))]
        public IHttpActionResult PostPrank([FromBody]Prank prank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Pranks.Add(prank);
                db.SaveChanges();

                return CreatedAtRoute("Api/Pranks/POST", new { id = prank.PrankId }, prank);
            }

        }

    }
}