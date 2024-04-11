using Microsoft.Maui.Controls;
using System;

namespace Gatin
{
    public partial class MortePage : ContentPage
    {
        MainPage mainPage; // Referência à MainPage

        public MortePage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage; // Atribuir a referência da MainPage recebida pelo construtor
        }

        [Obsolete]
        private async void OnRecomecarClicked(object sender, EventArgs e)
        {
            // Reiniciar a página principal usando a referência salva
            mainPage.Restart();
            await Navigation.PopToRootAsync();
        }
    }
}