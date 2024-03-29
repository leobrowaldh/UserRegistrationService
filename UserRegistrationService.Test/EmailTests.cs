namespace UserRegistrationService.Test;

[TestClass]
public class EmailTests
{
	[DataTestMethod]
	[DataRow("a@gmail.com")]
	[DataRow("AVeryLongEmailAddressWithUnneccesaryLengthButStillLegit@yahoo.com")]
	[DataRow("Different_Domain@NewZelandMail.nz")] 
	[DataRow("special,.Characters&*(@lala.net")]
	public void IsValidEmailTestingValidEmails_ShouldReturnTrue(string validEmail)
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		bool passwordIsValid = userRegistration.IsValidEmail(validEmail);

		//Assert
		Assert.IsTrue(passwordIsValid);
	}

	[DataTestMethod]
	[DataRow("Noat.com")]
	[DataRow("noDomain@gmail")]
	[DataRow("@.gmail.com")]
	public void IsValidEmailTestingInvalidEmails_ShouldReturnFalse(string invalidEmail)
	{
		//Arrange
		UserRegistration userRegistration = new UserRegistration();

		//Act
		bool passwordIsValid = userRegistration.IsValidEmail(invalidEmail);

		//Assert
		Assert.IsFalse(passwordIsValid);
	}
}
