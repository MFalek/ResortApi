using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace ResortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public readonly DataContext _context;

        public ReservationController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Reservation>>> CreateEdit(Reservation Reservations)
        {

            _context.Reservations.Add(Reservations);
            var HotelID = _context.Reservations.Find(Reservations.Id);

            _context.SaveChanges();

            return Ok(HotelID);
        }
        [HttpPatch]
        public async Task<ActionResult<List<Reservation>>> Update(Reservation Reservations)
        {
            //popraw

            var Editing = _context.Reservations.Find(Reservations.Id);
            if (Editing == null)
            {
                return BadRequest("Can't edit non-existent record");
            }

            Editing.ClientName = Reservations.ClientName;
            Editing.CheckInDate = Reservations.CheckInDate;
            Editing.CheckOutDate = Reservations.CheckOutDate;
            Editing.HotelName = Reservations.HotelName;


            await _context.SaveChangesAsync();

            return Ok(Editing);

        }
        [HttpDelete]

        public async Task<ActionResult<List<Reservation>>> Delete(int Id)
        {

            var Deleting = _context.Reservations.Find(Id);
            if (Deleting == null)
            {
                return BadRequest("Can't delete non-existent record");
            }

            _context.Reservations.Remove(Deleting);

            await _context.SaveChangesAsync();

            string message = "Deleted successfully";

            return Ok(message); 

        }

        [HttpGet]

        public async Task<ActionResult<List<Reservation>>> Find()
        {
            //popraw??
            return Ok(await _context.Reservations.ToListAsync());

        }


    }
}
