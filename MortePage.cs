using Microsoft.Maui.Controls;
using System;

namespace Gatin
{
    public partial class MortePage : ContentPage
    {
        MainPage mainPage; 

        public MortePage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage; 
        }

        private async void OnRecomecarClicked(object sender, EventArgs e)
        {
            mainPage.Restart();
            await Navigation.PopToRootAsync();
        }
    }
}
