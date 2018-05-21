using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clarity.Examples.Tests
{
    [TestClass]
    public class Authentication
    {
        [TestMethod]
        public void Authentication_Server_Responds_With_User_Authenticated()
        {
            // Arrange
            var correctResponse = "User Authenticated";
            var credentials = new Credential("bob", "bob123;");
            var app = new App();

            // Act
            app.AuthenticateUser(credentials);

            // Assert
            Assert.AreEqual(correctResponse, app.Response);
        }

        [TestMethod]
        public void Authentication_Server_Responds_With_User_Not_Authenticated()
        {
            // Arrange
            var correctResponse = "User Not Authenticated";
            var credentials = new Credential("bob", "bob1222");
            var app = new App();

            // Act
            app.AuthenticateUser(credentials);

            // Assert
            Assert.AreEqual(correctResponse, app.Response);
        }
    }
}