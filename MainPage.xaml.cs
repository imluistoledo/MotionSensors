using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SensoresMovimiento
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnNavegarAcelerometroClicked(object sender, EventArgs e)
        {
            btnAcelerometro.BackgroundColor = Color.CornflowerBlue;
            btnAcelerometro.TextColor = Color.White;
            await Task.Delay(200);
            await Navigation.PushAsync(new Acelerometro());
        }
        private async void btnNavegarGiroscopioClicked(object sender, EventArgs e)
        {
            btnGiroscopio.BackgroundColor = Color.CornflowerBlue;
            btnGiroscopio.TextColor = Color.White;
            await Task.Delay(200);
            await Navigation.PushAsync(new Giroscopio());
        }
        private async void btnNavegarRotacionClicked(object sender, EventArgs e)
        {
            btnRotacion.BackgroundColor = Color.CornflowerBlue;
            btnRotacion.TextColor = Color.White;
            await Task.Delay(200);
            await Navigation.PushAsync(new Rotacion());
        }
    }
}
