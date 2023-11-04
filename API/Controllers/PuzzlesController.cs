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
	public class PuzzlesController : ControllerBase
	{
		private readonly IPuzzleRepository _puzzleRepository;

		public PuzzlesController(IPuzzleRepository puzzleRepository)
		{
			_puzzleRepository = puzzleRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PuzzleDto>>> GetPuzzles()
		{
			try
			{
				var puzzles = await _puzzleRepository.GetAllPuzzles();

				if (puzzles == null)
				{
					return NotFound();
				}

				var puzzleDtos = puzzles.ConvertToDto();

				return Ok(puzzleDtos);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}

		[HttpGet("{roomId:int}")]
		public async Task<ActionResult<IEnumerable<PuzzleDto>>> GetPuzzles(int roomId)
		{
			try
			{
				var puzzles = await _puzzleRepository.GetPuzzlesByRoomId(roomId);

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

		[HttpGet("SinglePuzzle/{puzzleId}")]
		public async Task<ActionResult<PuzzleDto>> GetPuzzleById(int puzzleId)
		{
			try
			{
				var puzzle = await _puzzleRepository.GetPuzzleById(puzzleId);

				if (puzzle == null)
				{
					return NotFound();
				}

				var puzzleDto = puzzle.ConvertToPuzzleDto();

				return Ok(puzzleDto);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			
		}

		[HttpPost("AddNewPuzzle/{roomId:int}")]
		public async Task<ActionResult<PuzzleDto>> AddNewPuzzleToRoom(PuzzleDto puzzleDto)
		{
			if (puzzleDto == null)
			{
				return NoContent();
			}
			
			try
			{
				var newPuzzle = puzzleDto.ConvertToPuzzle();

				var response = await _puzzleRepository.AddNewPuzzle(newPuzzle);

				if (response == null)
				{
					return NoContent();
				}

				return Ok(puzzleDto);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			
		}

		
	}
}
