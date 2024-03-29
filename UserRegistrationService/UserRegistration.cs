using System.Text.RegularExpressions;

namespace UserRegistrationService;

public class UserRegistration
{
	public List<User> Users { get; set; } = [];
	public string AddNewUser(string userName, string password, string email)
	{
		return "";
	}

	/// <summary>
	/// Verifies the username does not allready exist in the Users list
	/// </summary>
	/// <param name="username"></param>
	public bool IsUniqueUsername(string username)
	{	
		User? uniqueUser = Users.FirstOrDefault(u => u.Username == username);
		return uniqueUser == null;
	}

	/// <summary>
	/// Verifies username only contains alphanumerical characters, and is between 5 and 20 characters long.
	/// </summary>
	/// <param name="username"></param>
	public bool IsValidUsername(string username)
	{
		bool isValid = false;
		string nonAlphaNumericalPattern = @"[^a-zA-Z0-9]";
		bool isAlphaNumerical = !Regex.IsMatch(username, nonAlphaNumericalPattern);
		isValid = isAlphaNumerical && username.Length >= 5 && username.Length <= 20;
		return isValid;
	}
	public bool IsValidPassword(string password)
	{
		return false;
	}
	public bool IsValidEmail(string email)
	{
		return false;
	}
}
