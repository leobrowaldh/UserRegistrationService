namespace UserRegistrationService.Test;

internal class PasswordTests
{
	[DataTestMethod]
	[DataRow("AveryGoodPassword49582*")]
	[DataRow("@@@@@@@@@@")]
	[DataRow("Only8@lg")] //edge case: 8 characters
	[DataRow("veryyylooonggggg)*()*()*()*()*())*()*())*()")]
	public void IsValidPasswordTestingValidPasswords_ShouldReturnTrue(string validPassword)
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		bool passwordIsValid = userRegistration.IsValidPassword(validPassword);

		//Assert
		Assert.IsTrue(passwordIsValid);
	}

	[DataTestMethod]
	[DataRow("$hort")] 
	[DataRow("noSpecialCharacterHere")]
	[DataRow("345245456856")]
	public void IsValidPasswordTestingInvalidPasswords_ShouldReturnFalse(string invalidPassword)
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		bool passwordIsValid = userRegistration.IsValidPassword(invalidPassword);

		//Assert
		Assert.IsFalse(passwordIsValid);
	}
}
