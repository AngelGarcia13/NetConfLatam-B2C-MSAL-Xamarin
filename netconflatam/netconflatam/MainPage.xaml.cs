using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace netconflatam
{
    public partial class MainPage : ContentPage
    {
        AuthenticationResult authenticationResult;

        public MainPage(AuthenticationResult result)
        {
            InitializeComponent();
            authenticationResult = result;

        }

        protected override void OnAppearing()
        {
            if (authenticationResult != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(authenticationResult.IdToken);
                var claims = data.Claims.ToList();
                messageLabel.Text = $"Hello {data.Claims.FirstOrDefault(x => x.Type.Equals("name")).Value}";
            }

            base.OnAppearing();
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

            while (accounts.Any())
            {
                await App.AuthenticationClient.RemoveAsync(accounts.First());
                accounts = await App.AuthenticationClient.GetAccountsAsync();
            }

            await Navigation.PopAsync();
        }
    }
}
