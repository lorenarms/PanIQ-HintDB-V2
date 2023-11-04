using System.Net.Http.Json;
using Client.Services.Contracts;
using Models.DTOs;

namespace Client.Services
{
	public class PuzzleService : IPuzzleService
	{
		private readonly HttpClient _httpClient;

		public PuzzleService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<PuzzleDto>> GetPuzzles()
		{
			var response = await _httpClient.GetAsync($"api/Puzzles");
			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					return Enumerable.Empty<PuzzleDto>();
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<PuzzleDto>>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public async Task<IEnumerable<PuzzleDto>> GetPuzzlesByRoom(int roomId)
		{
			var response = await _httpClient.GetAsync($"api/Puzzles/{roomId}");

			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return default;
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<PuzzleDto>>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public async Task<PuzzleDto> GetPuzzleById(int puzzleId)
		{
			var response = await _httpClient.GetAsync($"api/Puzzles/SinglePuzzle/{puzzleId}");
			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					return default;
				}

				return await response.Content.ReadFromJsonAsync<PuzzleDto>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public Task<PuzzleDto> AddNewPuzzleToRoom(PuzzleDto puzzleDto)
		{
			throw new NotImplementedException();
		}
	}
}
