﻿using LARTech.API.Entities;
using LARTech.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LARTech.API.Controllers
{
    [Route("api/lar-tech")]
    [ApiController]
    public class LarTechController : ControllerBase
    {
        private readonly LarTechDbContext _context;

        public LarTechController(LarTechDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll() 
        { 
            var persons = _context.Persons.Where(d => !d.IsDeleted).ToList();

            return Ok(persons);
        }

        [HttpGet("{id}")]

        public ActionResult GetById(int id) 
        {
            var person = _context.Persons.SingleOrDefault(d => d.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }


        [HttpPost]
        public ActionResult Post(Person person) 
        {

            var existingPerson = _context.Persons.SingleOrDefault(p => p.Id == person.Id);
            var existingCPF = _context.Persons.SingleOrDefault(p => p.CPF == person.CPF );

            if (existingPerson != null)
            {
                return Conflict("A person with the same ID already exists.");
            }

            if (existingCPF != null)
            {
                return Conflict("A person with the same CPF already exists.");
            }


            _context.Persons.Add(person);

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }


        [HttpPut("{id}")]

        public IActionResult Update(int id, Person input) 
        {
            var person = _context.Persons.SingleOrDefault(d => d.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            person.Update(input.Name, input.CPF, input.BirthDate, input.IsActive);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var person = _context.Persons.SingleOrDefault(d => d.Id == id);

            if (person == null) 
            {
                return NotFound();
            }

            person.Delete();

            return NoContent();
        }


        [HttpPost("{id}/phone-numbers")]

        public IActionResult PostPhoneNumbers(int id, PhoneNumbers input) 
        {
            var person = _context.Persons.SingleOrDefault(d => d.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            person.Phones.Add(input);

            return NoContent();
        }
    }
}
