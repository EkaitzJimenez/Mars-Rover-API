using System;
using System.Windows;
using System.Windows.Controls;
using Wpf_Ejercicio_4_Ekaitz_Jimenez.Controllers;
using Wpf_Ejercicio_4_Ekaitz_Jimenez.Models;

namespace Wpf_Ejercicio_4_Ekaitz_Jimenez.Views
{
    //Clase de la vista que maneja la interfaz y la logica para las fotos
    public partial class PhotosView : Window
    {
        private PhotosController PhotosController;

        public PhotosView()
        {
            InitializeComponent();
            //Se crea instancia del controlador
            PhotosController = new PhotosController();
        }

        //Evento para obtener las fotos
        private async void ObtenerDatos(object sender, RoutedEventArgs e)
        {
            //Intenta llamar al controlador para obtener las fotos de forma asincrona
            try
            {
                var photosData = await PhotosController.GetAllPhotos();

                //Comprueba que los datos sean correctos
                if (photosData != null && photosData.photos != null && photosData.photos.Any())
                {
                    //Asigna los datos al DataGrid y muestra un mensaje informativo
                    PhotosDataGrid.ItemsSource = photosData.photos;
                    MessageBox.Show($"Se han cargado {photosData.photos.Count} registros");
                }
                else
                {   //Si no hay fotos, muestra error
                    MessageBox.Show("No se han encontrado datos");
                }
            }
            catch (Exception ex)
            {   //Manejo de excepciones
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        //Abrir detalle del dato en DataGrid, muestra información más detallada
        private void PhotosDataGrid_data(object sender, SelectionChangedEventArgs e)
        {
            //si el item selecionado es una foto
            if (PhotosDataGrid.SelectedItem is Photo selectedPhoto)
            {
                //abre nueva ventana con los detalles
                PhotoDetailsWindow detailsWindow = new PhotoDetailsWindow(selectedPhoto);
                detailsWindow.Show();
            }
        }
    }
}
