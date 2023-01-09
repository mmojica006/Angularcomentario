﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEComentarios.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEComentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ComentarioController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listComentarios = await _context.Comentarios.ToListAsync();
                return Ok(listComentarios);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comentario = await _context.Comentarios.FindAsync(id);
                if (comentario == null)
                {
                    return NotFound();
                }

                return Ok(comentario);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();

                return Ok(comentario);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
