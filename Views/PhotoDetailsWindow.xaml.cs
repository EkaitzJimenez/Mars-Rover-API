using System.Windows;
using Wpf_Ejercicio_4_Ekaitz_Jimenez.Models;

namespace Wpf_Ejercicio_4_Ekaitz_Jimenez.Views
{
    //Ventana que muestra los detalles de un registro elegido
    public partial class PhotoDetailsWindow : Window
    {
        public PhotoDetailsWindow(Photo photo)
        {
            //Inicializa un componente y establece un contexto de datos con el objeto Photo pasado por parametro
            InitializeComponent();
            DataContext = photo;
        }
    }
}
