using API.Extensions;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomsController : ControllerBase
	{
		private readonly IRoomRepository _roomRepository;

		public RoomsController(IRoomRepository roomRepository)
		{
			_roomRepository = roomRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
		{
			try
			{
				var rooms = await _roomRepository.GetAllRooms();

				if (rooms == null)
				{
					return NotFound();
				}

				var roomDtos = rooms.ConvertToDto();

				return Ok(roomDtos);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}

		}
	}
}
