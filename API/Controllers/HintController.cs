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

		[HttpGet("{puzzleId:int}")]
		public async Task<ActionResult<IEnumerable<HintDto>>> GetPuzzleHintsById(int puzzleId)
		{
			try
			{
				var hints = await _hintRepository.GetPuzzleHintsById(puzzleId);
				
				if (hints == null)
				{
					return NotFound();
				}

				var hintDtos = hints.ConvertToDto();

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
