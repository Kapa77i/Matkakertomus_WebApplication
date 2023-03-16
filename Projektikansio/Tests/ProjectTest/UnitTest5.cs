using Bunit;
using FrontEnd.Pages;
using FrontEnd.Shared;
using SharedLib;
using FrontEnd;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Components;
using Moq;
using System.Net;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Sdk;
using Moq.Protected;
using ProjectTest;

namespace ProjectTest
{
    public class Signup : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public LoginState LoginState { get; set; } // Add this line

        public matkaajaDTO user { get; set; } = new matkaajaDTO();

        // ...
    }
    public class RegistryTest : TestContext
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;

        public RegistryTest(TestContext context) 
        
        {
            // Get the HttpClient and NavigationManager instances from the TestContext
            _http = context.Services.GetRequiredService<HttpClient>();
            _navManager = context.Services.GetRequiredService<NavigationManager>();
        }


        [Fact]
        public void TestRegistry()
        {
            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();

            // Render the NavMenu component
            var component = RenderComponent<NavMenu>();

            // Find the Kirjaudu sisään button
            var RegistryButton = component.Find("#rekisteroidy");

            // Simulate a click on the button
            RegistryButton.Click();

            // Assert that the user is redirected to the login page
            var navigationManager = Services.GetRequiredService<NavigationManager>();
            Assert.Equal("http://localhost/", navigationManager.Uri);

            var user = new matkaajaDTO
            {
                etunimi = "John",
                sukunimi = "Doe",
                nimimerkki = "johndoe",
                esittely = "Lorem ipsum",
                paikkakunta = "Helsinki",
                kuva = "1.png"
            };
            var page = RenderComponent<Signup>(
                builder => builder
                    .Add(s => s.user, user)
                    .Add(s => s.Http, _http)
                    .Add(s => s.NavManager, _navManager)
            );

            // Assert
            Assert.NotNull(page.Instance.user);
            Assert.Equal(user.etunimi, page.Instance.user.etunimi);
            Assert.Equal(user.sukunimi, page.Instance.user.sukunimi);
            Assert.Equal(user.nimimerkki, page.Instance.user.nimimerkki);
            Assert.Equal(user.esittely, page.Instance.user.esittely);
            Assert.Equal(user.paikkakunta, page.Instance.user.paikkakunta);
            Assert.Equal(user.kuva, page.Instance.user.kuva);

            // Mock the HTTP POST request to the API endpoint
            var mockHttp = new Mock<HttpMessageHandler>();
            mockHttp.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new StringContent(""),
                });
            var httpClient = new HttpClient(mockHttp.Object);

            // Mock the NavigationManager
            var mockNavigationManager = new Mock<NavigationManager>();
            mockNavigationManager.Setup(n => n.NavigateTo(It.IsAny<string>(), It.IsAny<bool>())).Verifiable();
            navigationManager = mockNavigationManager.Object;

            // Render the Signup component with the mocked dependencies
            var signupComponent = RenderComponent<Signup>(
                builder => builder
                    .Add(s => s.Http, httpClient)
                    .Add(s => s.NavManager, navigationManager)
                    .Add(s => s.user, user)
                    .Add(s => s.LoginState, loginState)
                    );
            // Find the submit button
            var submitButton = signupComponent.Find("#submit-button");

            // Simulate a click on the submit button
            submitButton.Click();

            // Verify that the HTTP POST request was sent to the correct API endpoint
            mockHttp.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post
                    && req.RequestUri.ToString() == "https://localhost:5001/api/Matkaajat/"
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            // Verify that the user is redirected to the login page after successful registration
            
        }
    }

}



// Set up fixture data for HttpClient and NavigationManager
//var http = new HttpClient();
//var navManager = new MockNavigationManager();

//// Use the fixture data in the test
//using var ctx = new TestContext();
//ctx.UseHttp(http);
//ctx.UseNavigation(navManager);