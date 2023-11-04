using API.Entities;
using API.Extensions;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HintsController : ControllerBase
	{
		private readonly IHintRepository _hintRepository;
		public HintsController(IHintRepository hintRepository)
		{
			_hintRepository = hintRepository;
		}

		[HttpGet("{puzzleId:int}")]
		public async Task<ActionResult<IEnumerable<HintDto>>> GetPuzzleHintsById(int puzzleId)
		{
			try
			{
				var hints = await _hintRepository.GetHintsByPuzzleId(puzzleId);
				
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

		[HttpPost("/newhint/{puzzleId:int}")]
		public async Task<ActionResult<Hint>> AddHintToPuzzle(HintDto hintDto, int puzzleId)
		{
			var newHint = new Hint()
			{
				PuzzleId = puzzleId,
				Order = hintDto.Order,
				Description = hintDto.Description,
			};

			await _hintRepository.AddNewHintToPuzzle(newHint);

			return Ok(newHint);
		}



	}
}
