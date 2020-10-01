using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ClassLibraryCykel;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CykelRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CykelController : ControllerBase
    {
        private static int idCount = 1;

        static List<Cykel> cykelList = new List<Cykel>()
        {
            new Cykel(idCount++, "Sort", 1999.95, 8),
            new Cykel(idCount++, "Hvid", 2999.95, 6),
            new Cykel(idCount++, "Grå", 2500, 12),
            new Cykel(idCount++, "Hvid", 1999, 16),
            new Cykel(idCount++, "Gul", 2900, 7),
            new Cykel(idCount++, "Grøn", 4999.99, 21),
            new Cykel(idCount++, "Blå", 4000, 18),
            new Cykel(idCount++, "Lilla", 1799.99, 5),
            new Cykel(idCount++, "Pink", 4500, 5),
            new Cykel(idCount++, "Sort", 1500, 3),
            new Cykel(idCount++, "Blå", 1999.95, 6)
        };

        // GET: api/<CykelController>
        [HttpGet]
        public IEnumerable<Cykel> Get()
        {
            return cykelList;
        }

        // GET api/<CykelController>/5
        [HttpGet("{id}")]
        public Cykel Get(int id)
        {
            if (cykelList.Exists(c => c.Id == id))
                return cykelList.Find(c => c.Id == id);
            else
                return new Cykel();
        }

        // POST api/<CykelController>
        [HttpPost]
        public void Post([FromBody] Cykel value)
        {
            value.Id = idCount++;
            cykelList.Add(value);
        }

        // PUT api/<CykelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cykel value)
        {
            foreach (Cykel c in cykelList)
            {
                if (c.Id == id)
                {
                    c.Pris = value.Pris;
                    c.Gear = value.Gear;
                    c.Farve = value.Farve;
                    break;
                }
            }
        }

        // DELETE api/<CykelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Cykel cykel = Get(id);
            if (cykel != null)
                cykelList.Remove(cykel);
        }
    }
}
