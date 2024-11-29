using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPM_IGU_PracticaFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Exercises> exercisesList = new ObservableCollection<Exercises>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Examples_Button_Click(object sender, RoutedEventArgs e)
        {
            Exercises ex;
            MusclesGroups mg;

            string name = null;
            string description = null;
            string muscleName = null;

            //=======================First Exercise=======================
            name = "Sentadilla";
            description = "Excelente ejercicio para fortalecer las piernas y los gluteos";
            muscleName = "Piernas";
            mg = new MusclesGroups(muscleName);
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================Second Exercise=======================
            name = "Dominadas";
            description = "Ejercicio ideal para desarrollar la espalda y los biceps";
            muscleName = "Espalda, Brazos";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================Third Exercise=======================
            name = "Plancha";
            description = "Un ejercicio isométrico para trabajar  los abdominales";
            muscleName = "Core, Brazos";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================Fourth Exercise=======================
            name = "Curl de Biceps";
            description = "Un ejercicio simple pero efectivo para desarrollas los brazos, los biceps";
            muscleName = "Brazos";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================Fifth Exercise=======================
            name = "Press de banca";
            description = "Este ejercicio se realiza en una maquina guiada y permite trabajar los musculos como los pectorales, los triceps y los hombros";
            muscleName = "Pecho, Brazos, Hombros";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================Sixth Exercise=======================
            name = "Jalón al pecho";
            description = "Un ejercicio en maquima para trabajar la espalda, especialmente los dorsales";
            muscleName = "Espalda, Brazos";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================First Exercise=======================
            name = "Prensa de pierna";
            description = "Una maquina guiada para trabajar los musculos de las piernas, especialmente los cuadriceps";
            muscleName = "Piernas";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================Seventh Exercise=======================
            name = "Extensión de pierna";
            description = "Este ejercicio se enfoca en el desarrollo de los cuadriceps mediante una máquina";
            muscleName = "Piernas";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);

            //=======================Eighth Exercise=======================
            name = "Press de hombros";
            description = "Un ejercicio para trabajar  los hombros utilizando una máquina guiada";
            muscleName = "Brazos";
            ex = new Exercises(name, description);
            ex.ListMuscles.Add(mg);
            exercisesList.Add(ex);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            string name, description;
            string muscleName;

            MusclesGroups groups;
            Exercises exercises;

            if(TableExercises.SelectedItem != null)
            {
                //name = 
                
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
