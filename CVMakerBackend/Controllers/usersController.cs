using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CVMakerBackend.Controllers
{

    [RoutePrefix("api/users")]
    public class usersController : ApiController
    {
        [AllowAnonymous]

        [HttpGet]

        public IEnumerable<cv> Get() { 
        
            using (cvmakeEntities entities = new cvmakeEntities()) {
            
                return entities.cvs.ToList();
            }
        }


        //To post users

        
        [HttpPost]
        [ResponseType(typeof(cv))]

        public IHttpActionResult Post(cv tb)
        {

            cvmakeEntities db = new cvmakeEntities();

    
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
       

            db.cvs.Add(tb);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new
            {
                id = tb.ID

            }, tb);


            
        }
         
        //Update


        [HttpPut]

        public IHttpActionResult Put(int id, [FromBody]cv tutor)
        {

          

                using (cvmakeEntities entities = new cvmakeEntities())
                {

                    var entity = entities.cvs.FirstOrDefault(t => t.ID == id);

                    if (entity == null)
                    {

                        return NotFound();

                    }


                    else
                    {


                        entity.Names = tutor.Names;
                        entity.Email = tutor.Email;
                        entity.Addres = tutor.Addres;
                        entity.Contact = tutor.Contact;

                 

                        entities.SaveChanges();
                        return CreatedAtRoute("DefaultApi", new
                        {
                            id = tutor.ID 

                        }, tutor);
                     }
                }
            

          
        }
    }
}
