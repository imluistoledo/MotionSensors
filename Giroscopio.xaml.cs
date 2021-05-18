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
    public partial class Giroscopio : ContentPage
    {
        public Giroscopio()
        {
            InitializeComponent();
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
        }

        SensorSpeed velocidad = SensorSpeed.Game;

        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            nombreX.Text = e.Reading.AngularVelocity.X.ToString();
            nombreY.Text = e.Reading.AngularVelocity.Y.ToString();
            nombreZ.Text = e.Reading.AngularVelocity.Z.ToString();
        }

        private void switchdoble_Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                if (Gyroscope.IsMonitoring)
                    Gyroscope.Stop();
                else
                    Gyroscope.Start(velocidad);
            }
            catch (FeatureNotSupportedException)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}