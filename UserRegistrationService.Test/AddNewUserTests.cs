namespace UserRegistrationService.Test;

[TestClass]
public class AddNewUserTests
{
	[TestMethod]
	public void AddNewValidUser_ShouldReturnExpectedMessage()
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		string message = userRegistration.AddNewUser("GoodUsername", "GreatPassword!", "valid@email.com");

		//Assert
		Assert.AreEqual(message, "User GoodUsername added successfully");
	}

	[TestMethod]
	public void AddNewUserWithBadUsername_ShouldReturnExpectedMessage()
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		string message = userRegistration.AddNewUser("BadUsername%^&", "GreatPassword!", "valid@email.com");

		//Assert
		Assert.AreEqual(message, "Incorrect Username, must be 5-10 alphanumerical characters long");
	}

	[TestMethod]
	public void AddNewUserWithBadPassword_ShouldReturnExpectedMessage()
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		string message = userRegistration.AddNewUser("GoodUsername", "BadPass", "valid@email.com");

		//Assert
		Assert.AreEqual(message, "Incorrect Password, must be at least 8 characters long and must include special characters");
	}

	[TestMethod]
	public void AddNewUserWithBadEmail_ShouldReturnExpectedMessage()
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		string message = userRegistration.AddNewUser("GoodUsername", "GreatPassword!", "invalidemail.com");

		//Assert
		Assert.AreEqual(message, "Incorrect email, must follow the format myemail@example.com");
	}

	[TestMethod]
	public void AddallreadyExistingValidUser_ShouldReturnExpectedMessage()
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();
		//new User is added directly tu Users, aviding the AddNewUSerMethod so this test is independent of other methods.
		userRegistration.Users.Add(new User() { Username = "ExistingUsername", Password = "daP@ssword", Email = "email@email.com" });

		//Act
		string message = userRegistration.AddNewUser("ExistingUsername", "GreatPassword!", "valid@email.com");

		//Assert
		Assert.AreEqual(message, "Username allready taken, try another");
	}
}
