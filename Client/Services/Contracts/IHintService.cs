using System.Reflection;
using Models.DTOs;

namespace Client.Services.Contracts
{
	public interface IHintService
	{
		Task<IEnumerable<HintDto>> GetHints();
		Task<IEnumerable<HintDto>> GetHintsByPuzzle(int puzzleId);
		Task<HintDto> GetHintById(int hintId);
		
	}
}
