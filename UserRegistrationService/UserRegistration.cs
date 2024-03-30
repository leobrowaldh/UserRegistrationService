using System.Text.RegularExpressions;

namespace UserRegistrationService;

public class UserRegistration
{
	public List<User> Users { get; set; } = [];

	/// <summary>
	/// If the provided parameters are correctly verified, a new user is added to the Users list.
	/// </summary>
	/// <param name="username"></param>
	/// <param name="password"></param>
	/// <param name="email"></param>
	/// <returns>A message to confirm the user was added successfully, or a message indicating what went wrong.</returns>
	public string AddNewUser(string username, string password, string email)
	{
		if ( !IsValidUsername(username) )
		{
			return "Incorrect Username, must be 5-10 alphanumerical characters long";
		}
		else if (!IsUniqueUsername(username))
		{
			return "Username allready taken, try another";
		}
		else if (!IsValidPassword(password))
		{
			return "Incorrect Password, must be at least 8 characters long and must include special characters";
		}
		else if (!IsValidEmail(email))
		{
			return "Incorrect email, must follow the format myemail@example.com";
		}
		else
		{
			User userToAdd = new User() { Username = username, Email = email, Password = password};
			Users.Add(userToAdd);
			return $"User {username} added successfully";
		}
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

	/// <summary>
	/// Verifies the password is at least 8 characters long and include at least one special character.
	/// </summary>
	/// <param name="password"></param>
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

	/// <summary>
	/// Verifies the email address adheres to a valid format
	/// </summary>
	/// <param name="email"></param>
	public bool IsValidEmail(string email)
	{
		//This email regex pattern represents: (non @ nor whitespace)@(non . nor whitespace).(non . nor whitespace)
		string emailPattern = @"^[^\s@]+@[^\s.]+\.[^\s.]+$";
		bool emailIsValid = Regex.IsMatch(email, emailPattern);
		return emailIsValid;
	}
}
