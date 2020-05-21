using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheHat.Models
{
	public class Hat
	{	
		public string Name { get; set; }
		private List<User> Users { get; set; } = new List<User>();
		private List<string> Words { get; set; } = new List<string>();
		private List<string> GuessedWords { get; set; } = new List<string>();
		private string ActiveWord { get; set; }
		private User ActiveUser { get; set; }

		public Hat(string hatName)
		{
			Name = hatName;
		}

		public User AddUser(string userName)
		{
			CheckUser(userName);

			var newUser = new User(userName);
			Users.Add(newUser);
			return newUser;
		}

		public List<User> GetUsers()
		{
			return Users;
		}

		public void AddWords(string words)
		{
			var splittedWords = words.Split(" ");
			Words.AddRange(splittedWords);
		}

		public List<string> GetWords()
		{
			return Words;
		}

		public string GetWord()
		{
			var count = Words.Count;
			if (count > 0)
			{
				var random = new Random();
				ActiveWord = Words[random.Next(count - 1)];
				return ActiveWord;
			}
			ActiveWord = null;
			return null;
		}

		public string GuessedActiveWord()
		{
			Words.Remove(ActiveWord);
			if(!string.IsNullOrWhiteSpace(ActiveWord))
				GuessedWords.Add(ActiveWord);
			return GetWord();
		}

		public string SkipActiveWord()
		{
			return GetWord();
		}

		public void ResetWords()
		{
			Words.AddRange(GuessedWords);
			GuessedWords.Clear();
		}		

		private void CheckUser(string userName)
		{
			var alreadyRegistred = Users.FirstOrDefault(x => x.Name == userName);
			if (alreadyRegistred != null)
				throw new Exception("Такое имя уже существует!");
		}	
	}
}
