using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Ejercicio_4_Ekaitz_Jimenez.Models
{
    //Clase de una foto de la API
    public class Photo
    {
        public int id { get; set; }
        public Camera camera { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public Rover rover { get; set; }
        public int sol { get; set; }

    }

    //Clase que representa una camara de la foto
    public class Camera
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rover_id { get; set; }
        public string full_name { get; set; }
    }

    //Clase que representa el rover que ha sacado las fotos
    public class Rover
    {
        public int id { get; set; }
        public string name { get; set; }
        public string landing_date { get; set; }
        public string launch_date { get; set; }
        public string status { get; set; }

    }
}
