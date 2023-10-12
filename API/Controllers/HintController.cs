using API.Extensions;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HintController : ControllerBase
	{
		private IHintRepository _hintRepository;
		public HintController(IHintRepository hintRepository)
		{
			_hintRepository = hintRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<HintDto>>> GetHints()
		{
			try
			{
				var hints = await _hintRepository.GetHints();
				var puzzles = await _hintRepository.GetPuzzles();
				var rooms = await _hintRepository.GetRooms();

				if (hints == null || puzzles == null)
				{
					return NotFound();
				}

				var hintDtos = hints.ConvertToDto(puzzles, rooms);

				return Ok(hintDtos);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}

	}
}
