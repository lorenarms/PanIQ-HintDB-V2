using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Contracts
{
	public interface IHintRepository
	{
		Task<IEnumerable<Hint>> GetAllHints();
		Task<Hint> GetHintById(int id);
		Task<IEnumerable<Hint>> GetHintsByPuzzleId(int id);
		Task<Hint> AddNewHintToPuzzle(Hint hint);
		
		
		

	}
}
