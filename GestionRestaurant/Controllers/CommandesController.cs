using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GestionRestaurant.Models;

namespace GestionRestaurant.Controllers
{
    public class CommandesController : ApiController
    {
        private GesRestoEntities db = new GesRestoEntities();

        // GET: api/Commandes
        public IQueryable<Commande> GetCommandes()
        {
            return db.Commandes;
        }

        // GET: api/Commandes/5
        [ResponseType(typeof(Commande))]
        public IHttpActionResult GetCommande(long id)
        {
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return NotFound();
            }

            return Ok(commande);
        }

        // PUT: api/Commandes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommande(long id, Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commande.CommandeID)
            {
                return BadRequest();
            }

            db.Entry(commande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
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

        // POST: api/Commandes
        [ResponseType(typeof(Commande))]
        public IHttpActionResult PostCommande(Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Commandes.Add(commande);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = commande.CommandeID }, commande);
        }

        // DELETE: api/Commandes/5
        [ResponseType(typeof(Commande))]
        public IHttpActionResult DeleteCommande(long id)
        {
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return NotFound();
            }

            db.Commandes.Remove(commande);
            db.SaveChanges();

            return Ok(commande);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommandeExists(long id)
        {
            return db.Commandes.Count(e => e.CommandeID == id) > 0;
        }
    }
}