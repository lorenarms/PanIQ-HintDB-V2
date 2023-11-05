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
		
		public async Task<IEnumerable<HintDto>> GetHints()
		{
			var response = await _httpClient.GetAsync($"api/Hints");

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

		public async Task<IEnumerable<HintDto>> GetHintsByPuzzle(int puzzleId)
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

		public Task<HintDto> GetHintById(int hintId)
		{
			throw new NotImplementedException();
		}
	}
}
