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
			var result = _puzzleRepository.GetPuzzleById(puzzleId);

			PuzzleDto puzzle = new PuzzleDto()
			{
				Id = result.Result.Id,
				RoomId = result.Result.RoomId,
				RoomName = result.Result.Room.Name,
				Name = result.Result.Name,
				Description = result.Result.Description,
				Order = result.Result.Order,
			};

			return Ok(puzzle);
		}

		[HttpPost("NewPuzzle/{roomId:int}")]
		public async Task<ActionResult<Puzzle>> AddNewPuzzleToRoom(PuzzleDto puzzleDto)
		{
			

			var newPuzzle = new Puzzle()
			{
				RoomId = puzzleDto.RoomId,
				Name = puzzleDto.Name,
				Description = puzzleDto.Description,
				Order = puzzleDto.Order
			};

			//await _puzzleRepository.AddNewPuzzleToRoom(newPuzzle);

			return Ok(newPuzzle);
		}

		[HttpPost("MultipleNewPuzzles/{roomId:int}")]
		public async Task<ActionResult<MultiPuzzleDto>> AddMultipleNewPuzzlesToRoom(MultiPuzzleDto puzzles)
		{
			
			if (puzzles != null){
				foreach (var puzzleDto in puzzles.NewPuzzlesToAdd)
				{
					var newPuzzle = new Puzzle()
					{
						RoomId = puzzleDto.RoomId,
						Name = puzzleDto.Name,
						Description = puzzleDto.Description,
						Order = puzzleDto.Order
					};

					//await _puzzleRepository.AddNewPuzzleToRoom(newPuzzle);
				}

				return Ok(puzzles);
			}

			return NoContent();
			
		}
	}
}
