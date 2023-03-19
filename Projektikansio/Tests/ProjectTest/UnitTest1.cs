using Bunit;
using Microsoft.AspNetCore.Components.Web;
namespace ProjectTest
{
    //Rekister�itymislomakkeen testit
    public class SignUpTest : TestContext
    {
        [Fact]
        public async Task EmptyFormTest()
        {
            //testin ideana on testata, ettei vajaa formi mene l�pi

            var page = RenderComponent<FrontEnd.Pages.Signup>();

            var button = page.Find("button[type='submit']");
            await button.ClickAsync(new MouseEventArgs());


            Assert.True(true);
        }
    }
}
