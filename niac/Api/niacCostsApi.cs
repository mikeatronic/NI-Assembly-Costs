﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace niac.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class niacCostsApi : ControllerBase
    {
        // GET: api/<niacCostsApi>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<niacCostsApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<niacCostsApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<niacCostsApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<niacCostsApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
