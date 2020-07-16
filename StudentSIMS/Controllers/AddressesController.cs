using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSIMS.Data;
using StudentSIMS.Models;

namespace StudentSIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentContext _context;

        public AddressesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.Include(c => c.Student).ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.addressID)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {

            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.addressID }, address);
        }
        // POST: api/Addresses/id
        // This method adds an address to the relevant student when passed an ID.
        [HttpPost("{id}")]
        public async Task<ActionResult<Address>> PostStudentAddress(Address address, int id)
        {
            // checks if student is within the Student context / is a real entry in the database.

            var student = await _context.Student.FindAsync(id);

            // next statement checks if there is already an address associated with the student.
            // If there is an entry for that student it throws a NotFound().

            if (student == null)
            {
                return NotFound();
            }

            if (_context.Address.Any(o => o.studentId == id)) {
                return NoContent();

            } else {
                _context.Address.Add(address);
                address.studentId = id;
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAddress", new { id = address.addressID }, address);
            }

        }
        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.addressID == id);
        }
    }
}
