namespace TheHat.Models
{
	public class User
	{
		public User(string username)
		{
			Name = username;
		}
		public string Name { get; set; }
		public int Score { get; set; }
	}
}