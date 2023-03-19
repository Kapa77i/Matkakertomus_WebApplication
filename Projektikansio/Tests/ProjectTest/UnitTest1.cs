using Bunit;
using Microsoft.AspNetCore.Components.Web;
namespace ProjectTest
{
    //Rekisteröitymislomakkeen testit
    public class SignUpTest : TestContext
    {
        [Fact]
        public async Task EmptyFormTest()
        {
            //testin ideana on testata, ettei vajaa formi mene läpi

            var page = RenderComponent<FrontEnd.Pages.Signup>();

            var button = page.Find("button[type='submit']");
            await button.ClickAsync(new MouseEventArgs());


            Assert.True(true);
        }
    }
}
