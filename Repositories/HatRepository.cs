using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHat.Models;
using TheHat.Repositories.Interfaces;

namespace TheHat.Repositories
{
	public class HatRepository : IHatRepository
	{
		private List<Hat> hats = new List<Hat>();
		public Hat CreateHat(string hatName)
		{
			var hat = new Hat(hatName);
			hats.Add(hat);
			return hat;
		}

		public List<Hat> GetHats()
		{
			return hats;
		}

		public User AddUser(string hatName, string userName)
		{
			var hat = GetHat(hatName);
		
			var newUser = hat.AddUser(userName);

			return newUser;			
		}

		public List<User> GetHatUsers(string hatName)
		{
			var hat = GetHat(hatName);
			return hat.GetUsers();
		}

		public void AddWords(string hatName, string words)
		{
			var hat = GetHat(hatName);

			hat.AddWords(words);
		}

		public List<string> GetHatWords(string hatName)
		{
			var hat = GetHat(hatName);
			return hat.GetWords();
		}

		public string GetRandomWord(string userName, string hatName)
		{
			var hat = GetHat(hatName);
			return hat.GetWord(userName);
		}

		public string GuessedWord(string hatName)
		{
			var hat = GetHat(hatName);
			return hat.GuessedActiveWord();
		}

		public void ResetHatWords(string hatName)
		{
			var hat = GetHat(hatName);
			hat.ResetWords();
		}

		private Hat GetHat(string hatName)
		{
			var hat = hats.FirstOrDefault(x => x.Name == hatName);
			if (hat == null)
				throw new Exception("Указанная игра не найдена");
			return hat;
		}	
	}
}
