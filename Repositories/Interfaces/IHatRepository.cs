using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHat.Models;

namespace TheHat.Repositories.Interfaces
{
	public interface IHatRepository
	{
		Hat CreateHat(string hatName);
		List<Hat> GetHats();
		User AddUser(string hatName, string userName);
		List<User> GetHatUsers(string hatName);

		void AddWords(string hatName, string words);
		List<string> GetHatWords(string hatName);
		string GuessedWord(string hatName);
		string GetRandomWord(string hatName);
		void ResetHatWords(string hatName);
	}
}
