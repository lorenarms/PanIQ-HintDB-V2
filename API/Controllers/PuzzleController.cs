using API.Entities;
using API.Extensions;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models.DTOs;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PuzzleController : ControllerBase
	{
		private readonly IHintRepository _hintRepository;

		public PuzzleController(IHintRepository hintRepository)
		{
			_hintRepository = hintRepository;
		}

		[HttpGet("{roomId:int}")]
		public async Task<ActionResult<IEnumerable<PuzzleDto>>> GetPuzzles(int roomId)
		{
			try
			{
				var puzzles = await _hintRepository.GetPuzzlesById(roomId);

				if (puzzles == null)
				{
					return NotFound();
				}

				var puzzleDtos = puzzles.ConvertToDto(roomId);

				return Ok(puzzleDtos);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}

		[HttpPost("/newpuzzle/{roomId:int}")]
		public async Task<ActionResult<Puzzle>> AddNewPuzzleToRoom(PuzzleDto puzzleDto, int roomId)
		{
			var newPuzzle = new Puzzle()
			{
				Name = puzzleDto.Name,
				Description = puzzleDto.Description,
				Order = puzzleDto.Order
				
			};

			await _hintRepository.AddNewPuzzleToRoom(newPuzzle);

			return Ok(newPuzzle);
		}
	}
}
