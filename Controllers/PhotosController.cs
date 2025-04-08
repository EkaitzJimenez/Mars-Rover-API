using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wpf_Ejercicio_4_Ekaitz_Jimenez.Models;

namespace Wpf_Ejercicio_4_Ekaitz_Jimenez.Controllers
{
    //Controlador para manejar los datos obtenidos de la NASA
    public class PhotosController
    {
        private HttpClient client; //HTTP para las solicitudes

        //Constructor que inicializa el cliente http
        public PhotosController()
        {
            client = new HttpClient();
        }

        //Metodo asincrono para obtener todos los datos de la api
        public async Task<Photos> GetAllPhotos()
        {
            try
            {
                //Inicializa un objeto 
                Photos photos = new Photos();

                //Realiza la solicitud GET a la API
                HttpResponseMessage response = await client.GetAsync("https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=Q6NzCdIqivihbOR3NVbraBQ9GeVEurhd3ceZq0sD");

                //Comprueba que la respuesta haya sido correcta
                response.EnsureSuccessStatusCode();

                //Lee la respuesta como JSON
                string responseJson = await response.Content.ReadAsStringAsync();
                //Deserializa el json a un objeto de tipo photos
                photos = JsonConvert.DeserializeObject<Photos>(responseJson);
                
                //Devuelve el objeto
                return photos;
            }
            catch (Exception ex)//Manejo de errores
            {
                Console.WriteLine($"Error al obtener las fotos: {ex.Message}");
                return null;
            }
        }
    }
}