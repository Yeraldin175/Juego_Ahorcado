﻿namespace AhorcdoTEAM1
{
    public partial class MainPage : ContentPage
    {
        private string nombrePersonajeSeleccionado;
        private Dictionary<ImageButton, string> nombresPersonajes;

        public MainPage()
        {
            InitializeComponent();

            nombresPersonajes = new Dictionary<ImageButton, string>();
            nombresPersonajes.Add(ImageButtonPatricio, "Patricio");
            nombresPersonajes.Add(ImageButtonBob, "Bob");
            nombresPersonajes.Add(ImageButtonPlankton, "Cangrejo");
            nombresPersonajes.Add(ImageButtonArenita, "Pop");
        }

        private async void OnJugarClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nombrePersonajeSeleccionado) && nivelPicker.SelectedItem != null)
            {
                string nivelSeleccionado = nivelPicker.SelectedItem.ToString();
                switch (nombrePersonajeSeleccionado)
                {
                    case "Patricio":
                        await Navigation.PushAsync(new personaje1(nivelSeleccionado));
                        break;
                    case "Bob":
                        await Navigation.PushAsync(new personaje2(nivelSeleccionado));
                        break;
                    case "Cangrejo":
                        await Navigation.PushAsync(new personaje3(nivelSeleccionado));
                        break;
                    case "Pop":
                        await Navigation.PushAsync(new personaje4(nivelSeleccionado));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Por favor, selecciona un personaje y un nivel antes de jugar.", "OK");
            }
        }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton clickedButton && nombresPersonajes.ContainsKey(clickedButton))
            {
                nombrePersonajeSeleccionado = nombresPersonajes[clickedButton];
                SeleccionLabel.Text = $"Seleccionado: {nombrePersonajeSeleccionado}";
            }
        }
    }
}
