using System.Net.Http.Json;
using Client.Services.Contracts;
using Models.DTOs;

namespace Client.Services
{
	public class HintService : IHintService
	{
		private readonly HttpClient _httpClient;

		public HintService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		public async Task<IEnumerable<HintDto>> GetHints(int puzzleId)
		{
			var response = await _httpClient.GetAsync($"api/Hints/{puzzleId}");

			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return Enumerable.Empty<HintDto>();
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<HintDto>>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public async Task<IEnumerable<RoomDto>> GetRooms()
		{
			var response = await _httpClient.GetAsync("api/Rooms");
			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return Enumerable.Empty<RoomDto>();
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<RoomDto>>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public async Task<IEnumerable<PuzzleDto>> GetPuzzles()
		{
			var response = await _httpClient.GetAsync("api/Puzzles");
			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return Enumerable.Empty<PuzzleDto>();
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<PuzzleDto>>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public async Task<IEnumerable<PuzzleDto>> GetPuzzlesByRoomId(int roomId)
		{
			var response = await _httpClient.GetAsync($"api/Puzzles/{roomId}");

			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return default(IEnumerable<PuzzleDto>);
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<PuzzleDto>>();

			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);

		}

		public Task<PuzzleDto> GetPuzzleById(int puzzleId)
		{
			throw new NotImplementedException();
		}


		public async Task<PuzzleDto> AddNewPuzzleToRoom(PuzzleDto puzzle)
		{
			
			var response = await _httpClient.PostAsJsonAsync($"NewPuzzle/{puzzle.RoomId}", puzzle);

			return puzzle;
		}

		public async Task<MultiPuzzleDto> AddMultipleNewPuzzlesToRoom(MultiPuzzleDto puzzles)
		{
			var singlePuzzle= puzzles.NewPuzzlesToAdd.FirstOrDefault();
			var roomId = singlePuzzle.RoomId;

			// var response = await _httpClient.PostAsJsonAsync($"MultipleNewPuzzles/{roomId}", puzzles);
			

			var response = await _httpClient.PostAsJsonAsync($"MultipleNewPuzzles/{roomId}", puzzles);

			return puzzles;
		}
	}
}
