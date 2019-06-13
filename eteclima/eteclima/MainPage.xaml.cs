using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using eteclima.Model;
using eteclima.Services;

namespace eteclima
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Previsão do Tempo";
            //define o databinding para os objetos padrão iniciais
            this.BindingContext = new Tempo();
        }

        private async void btnPrevisao_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cidadeEntry.Text))
                {
                    Tempo previsaoDoTempo = await DataService.GetPrevisaoDoTempo(cidadeEntry.Text);
                    this.BindingContext = previsaoDoTempo;
                    btnPrevisao.Text = "Nova Previsao";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro ", ex.Message, "OK");
            }
        }
    }
}