namespace UserRegistrationService.Test
{
	[TestClass]
	public class UsernameTests
	{
		[TestMethod]
		public void IsUniqueUsernameVerifyingUniqueUnexistingUsername_ShouldReturnTrue()
		{
			//Arrange
			UserRegistration userRegistration = new UserRegistration();

			//Act
			bool usernameIsUnique = userRegistration.IsUniqueUsername("newUniqueUsername");

			//Assert
			Assert.IsTrue(usernameIsUnique);
		}

		[TestMethod]
		public void IsUniqueUsernameOnAllreadyExistingUsername_ShouldReturnFalse()
		{
			//Arrange
			UserRegistration userRegistration = new UserRegistration();
			//new User is added directly tu Users, aviding the AddNewUSerMethod so this test is independent of other methods.
			userRegistration.Users.Add(new User() { Username = "unique", Password = "daP@ssword", Email = "email@email.com" });

			//Act
			bool usernameIsUnique = userRegistration.IsUniqueUsername("unique");

			//Assert
			Assert.IsFalse(usernameIsUnique);
		}

		[TestMethod]
		public void IsUniqueUsernameOnAllreadyExistingUsernameButWithUppercase_ShouldReturnTrue()
		{
			//Arrange
			UserRegistration userRegistration = new UserRegistration();
			//new User is added directly tu Users, aviding the AddNewUSerMethod so this test is independent of other methods.
			userRegistration.Users.Add(new User() { Username = "unique", Password = "daP@ssword", Email = "email@email.com" });

			//Act
			bool usernameIsUnique = userRegistration.IsUniqueUsername("Unique");

			//Assert
			Assert.IsTrue(usernameIsUnique);
		}

		[DataTestMethod]
		[DataRow("Lala58")]
		[DataRow("aaaaaaaa")]
		[DataRow("11111")] //5 chars
		[DataRow("DqDq345")]
		[DataRow("aaaaaaaaaaaaaaaaaaaa")] //20 chars
		public void IsValidUsernameTestingValidUsernames_ShouldReturnTrue(string validUsername)
		{
			//Arrange
			UserRegistration userRegistration = new UserRegistration();

			//Act
			bool usernameIsValid = userRegistration.IsValidUsername(validUsername);

			//Assert
			Assert.IsTrue(usernameIsValid);
		}

		[DataTestMethod]
		[DataRow("Lala@58")]
		[DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
		[DataRow("11_111")] 
		[DataRow("Dq")]
		[DataRow("*****")] 
		public void IsValidUsernameTestingInvalidUsernames_ShouldReturnTrue(string invalidUsername)
		{
			//Arrange
			UserRegistration userRegistration = new UserRegistration();

			//Act
			bool usernameIsValid = userRegistration.IsValidUsername(invalidUsername);

			//Assert
			Assert.IsFalse(usernameIsValid);
		}
	}
}