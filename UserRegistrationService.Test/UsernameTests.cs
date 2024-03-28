namespace UserRegistrationService.Test
{
	[TestClass]
	public class UsernameTests
	{
		[DataTestMethod]
		[DataRow("unique")]
		[DataRow("Unique")]
		public void IsUniqueUsernameOnAllreadyExistingUsername_ShouldReturnFalse(string nonUniqueUsername)
		{
			//Arrange
			UserRegistration userRegistration = new UserRegistration();
			userRegistration.AddNewUser("unique", "daP@ssword", "email@email.com");

			//Act
			bool usernameIsUnique = userRegistration.IsUniqueUsername(nonUniqueUsername);

			//Assert
			Assert.IsFalse(usernameIsUnique);
		}
	}
}