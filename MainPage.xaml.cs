using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UbicacionGPS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAbrir_Clicked(object sender, EventArgs e)
        {
            // Validar y parsear las coordenadas
            if (!double.TryParse(txtLatitud.Text, out double lat))
            {
                await DisplayAlert("Error", "Por favor, ingrese una latitud válida.", "OK");
                return;
            }
            if (!double.TryParse(txtLongitud.Text, out double lng))
            {
                await DisplayAlert("Error", "Por favor, ingrese una longitud válida.", "OK");
                return;
            }

            // Abrir la ubicación en el mapa
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = txtNombreUbicacion.Text,
                NavigationMode = NavigationMode.None
            });
        }
    }
}
