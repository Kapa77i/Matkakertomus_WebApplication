using Bunit;
using FrontEnd.Pages;
using FrontEnd.Shared;
using Microsoft.Extensions.DependencyInjection;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest
{
    public class GroupTrips : TestContext
    {
        //Tämä facta pittää olla että näkkyyy tuolla test explorelilla <---
        [Fact]
        public async Task TestGrouptripsPage()
        {
            Services.AddSingleton(new HttpClient { BaseAddress = new System.Uri("http://localhost") });
            Services.AddSingleton<LoginState>();
            var loginState = Services.GetRequiredService<LoginState>();
            loginState.SetLogin(false, null);

            var navMenuComponent = RenderComponent<NavMenu>();

            var kirjauduButton = navMenuComponent.Find("#kirjaudu");
            kirjauduButton.Click();

            await Task.Delay(500);

            var loginComponent = RenderComponent<Login>();


        }
    }
}
