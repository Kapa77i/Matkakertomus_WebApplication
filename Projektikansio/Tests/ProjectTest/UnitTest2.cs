
using Bunit;
using FrontEnd.Pages;
using FrontEnd.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using SharedLib;

namespace ProjectTest
{
    public class LoginTest : TestContext
    {
        [Fact]
        public async Task TestLogin()
        {
            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();

            // Render the NavMenu component
            var component = RenderComponent<NavMenu>();

            // Find the Kirjaudu sisään button
            var loginButton = component.Find("#kirjaudu");

            // Simulate a click on the button
            loginButton.Click();

            // Assert that the user is redirected to the login page
            var navigationManager = Services.GetRequiredService<NavigationManager>();
            Assert.Equal("http://localhost/", navigationManager.Uri);


            var comp = RenderComponent<Login>();
            var emailInput = comp.Find("#email");
            var passwordInput = comp.Find("#password");
            var submitButton = comp.Find("button[type='submit']");


            // Act
            emailInput.Change("sebastian@halonen.fi");
            passwordInput.Change("12345");
            submitButton.Click();

            // Wait for the login to complete

            // Assert
            Assert.Equal(loginState.isLoggedIn.Equals(true), loginState.isLoggedIn.Equals(true));


        }
    }


}