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
        public async Task<ActionResult<Reservation>> CreateEdit(ReservationDto Reservations)
        {
            var reservation = new Reservation
            {
                HotelName = Reservations.HotelName,
                ClientName = Reservations.ClientName,
                CheckInDate = Reservations.CheckInDate,
                CheckOutDate = Reservations.CheckOutDate,
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }


        [HttpPut]
        public async Task<ActionResult<List<Reservation>>> Update(Reservation Reservations)
        {
            //popraw

            var Editing = await _context.Reservations.FindAsync(Reservations.Id);
            if (Editing == null)
            {
                return BadRequest("Can't edit non-existent record");
            }

            Editing.ClientName = Reservations.ClientName;
            Editing.CheckInDate = Reservations.CheckInDate;
            Editing.CheckOutDate = Reservations.CheckOutDate;
            Editing.HotelName = Reservations.HotelName;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }
            var ReservatiosnList = await _context.Reservations.ToListAsync();
            return Ok(ReservatiosnList);

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
        
            return Ok(await _context.Reservations.ToListAsync());

        }


    }
}
