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
		//If the regular expression is matched, then there is a non alphanumerical character in the string
		//So if there is no match, then there are only alphanumerical characters in the string.
		bool isAlphaNumerical = !Regex.IsMatch(username, nonAlphaNumericalPattern);
		isValid = isAlphaNumerical && username.Length >= 5 && username.Length <= 20;
		return isValid;
	}
	public bool IsValidPassword(string password)
	{
		bool isValid = false;
		string nonAlphaNumericalPattern = @"[^a-zA-Z0-9]";
		//If the regular expression is matched, then there is a non alphanumerical character in the string
		//a non alphanumerical character is by definition a special character.
		bool thereIsASpecialCharacter = Regex.IsMatch(password, nonAlphaNumericalPattern);
		isValid = thereIsASpecialCharacter && password.Length >= 8;
		return isValid;
	}
	public bool IsValidEmail(string email)
	{
		return false;
	}
}
