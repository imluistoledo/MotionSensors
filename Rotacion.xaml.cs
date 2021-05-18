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
    public partial class Rotacion : ContentPage
    {
        public Rotacion()
        {
            InitializeComponent();
        }

        // API OrientationSensor

        // Define la velocidad para el sensor
        SensorSpeed velocidadCalibracion = SensorSpeed.Default;
        // Variables para guardar el valor de los ejes
        double valorEjeX;
        double valorEjeY;
        double valorEjeZ;

        private void btnIniciarCalibracionClicked(object sender, EventArgs e)
        {
            if (OrientationSensor.IsMonitoring)
                return;
            // Agrega el evento ReadingChanged para mostrar cambios
            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
            OrientationSensor.Start(velocidadCalibracion);
        }
        private void btnDetenerCalibracionClicked(object sender, EventArgs e)
        {
            if (!OrientationSensor.IsMonitoring)
                return;
            // Elimina el metodo
            OrientationSensor.ReadingChanged -= OrientationSensor_ReadingChanged;
            OrientationSensor.Stop();
            lblEjeX.Text = "Valor eje X";
            lblEjeY.Text = "Valor eje Y";
            lblEjeZ.Text = "Valor eje Z";
        }

        void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            // Multiplica por cien para un mejor control y redondea a entero
            valorEjeX = Math.Round(e.Reading.Orientation.X * 100);
            valorEjeY = Math.Round(e.Reading.Orientation.Y * 100);
            valorEjeZ = Math.Round(e.Reading.Orientation.Z * 100);

            // Cada vez que cambie, el valor se muestra en las etiquetas
            lblEjeX.Text = valorEjeX.ToString();
            lblEjeY.Text = valorEjeY.ToString();
            lblEjeZ.Text = valorEjeZ.ToString();

            if (valorEjeX <= 59 || valorEjeY <= 0 || valorEjeZ <= 0)
            {
                Vibration.Vibrate(TimeSpan.FromMilliseconds(1000));
            }
            else if (valorEjeX >= 81 || valorEjeY >= 31 || valorEjeZ >= 21)
            {
                Vibration.Vibrate(TimeSpan.FromMilliseconds(1000));
            }
            else
            {
                Vibration.Cancel();
            }
        }
    }
}