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
using GestionRestaurant.Models;

namespace GestionRestaurant.Controllers
{
    public class DetailsCommandesController : ApiController
    {
        private GesRestoEntities db = new GesRestoEntities();

        // GET: api/DetailsCommandes
        public IQueryable<DetailsCommande> GetDetailsCommandes()
        {
            return db.DetailsCommandes;
        }

        // GET: api/DetailsCommandes/5
        [ResponseType(typeof(DetailsCommande))]
        public IHttpActionResult GetDetailsCommande(long id)
        {
            DetailsCommande detailsCommande = db.DetailsCommandes.Find(id);
            if (detailsCommande == null)
            {
                return NotFound();
            }

            return Ok(detailsCommande);
        }

        // PUT: api/DetailsCommandes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetailsCommande(long id, DetailsCommande detailsCommande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detailsCommande.DetailsID)
            {
                return BadRequest();
            }

            db.Entry(detailsCommande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsCommandeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DetailsCommandes
        [ResponseType(typeof(DetailsCommande))]
        public IHttpActionResult PostDetailsCommande(DetailsCommande detailsCommande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetailsCommandes.Add(detailsCommande);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detailsCommande.DetailsID }, detailsCommande);
        }

        // DELETE: api/DetailsCommandes/5
        [ResponseType(typeof(DetailsCommande))]
        public IHttpActionResult DeleteDetailsCommande(long id)
        {
            DetailsCommande detailsCommande = db.DetailsCommandes.Find(id);
            if (detailsCommande == null)
            {
                return NotFound();
            }

            db.DetailsCommandes.Remove(detailsCommande);
            db.SaveChanges();

            return Ok(detailsCommande);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailsCommandeExists(long id)
        {
            return db.DetailsCommandes.Count(e => e.DetailsID == id) > 0;
        }
    }
}