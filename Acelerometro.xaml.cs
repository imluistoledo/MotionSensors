using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace SensoresMovimiento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Acelerometro : ContentPage
    {
        public Acelerometro()
        {
            InitializeComponent();
        }

        private bool lamparaEncendida = false;
        SensorSpeed velocidadSensor = SensorSpeed.Default;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(velocidadSensor);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Stop();
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => { 
                if (!lamparaEncendida)
                {
                    try
                    {
                        Flashlight.TurnOnAsync();
                        lamparaEncendida = true;
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    try
                    {
                        Flashlight.TurnOffAsync();
                        lamparaEncendida = false;
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }
    }
}