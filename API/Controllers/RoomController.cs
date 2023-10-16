using API.Extensions;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly IHintRepository _hintRepository;

		public RoomController(IHintRepository hintRepository)
		{
			_hintRepository = hintRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
		{
			try
			{
				var rooms = await _hintRepository.GetRooms();

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
