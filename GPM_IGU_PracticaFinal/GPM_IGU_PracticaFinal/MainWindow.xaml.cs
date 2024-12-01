using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
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
            
            DrawAxis();
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
            //string name, description;
            //string muscleName;

            //MusclesGroups groups;
            //Exercises exercises;

            //if (TableExercises.SelectedItem != null)
            //{
            //    //name = 

            //}

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void TableExercises_SelectionChanged(object sender, SelectionChangedEventArgs e)
        private void TableExercises_SelectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Exercises ex in e.NewItems)
                {
                    if (ex != null)
                    {
                        ex.PropertyChanged += EX_PropertyChanged();
                        foreach (Executions exec in ex.ListExecution)
                        {
                            exec.PropertyChanged += EX_PropertyChanged();
                        }

                    }
                }
            }
            else
            {
                Add_Button.IsEnabled = false;
                Delete_Button.IsEnabled = false;
                Modify_Button.IsEnabled = false;
            }
        }

        private void EX_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":
                case "Description":
                case "ListMuscles":
                case "ListExecution":
                    DrawAxis();
                    DrawGraphic();
                    break;
            }
        }

        private void DrawGraphic()
        {
            //distance between rectangles
            double distanceRect = 20;
            double maxHeigth = graphicCanvas.Height;
            int maxExecutions = exercisesList.Max(x => x.ListExecution.Count);

            if (exercisesList != null && exercisesList.Count > 0)
            {
                foreach(Exercises ex in exercisesList)
                {
                    ex.ReorderDate();
                    if (ex.ListExecution != null && ex.ListExecution.Count > 0)
                    {
                        foreach (Executions exec in ex.ListExecution)
                        {
                            Rectangle r = new Rectangle();
                            r.Width = 10;
                            r.Height = exec.Reps * maxHeigth / maxExecutions;
                            r.Fill = Brushes.Red;
                            Canvas.SetLeft(r, distanceRect);
                            Canvas.SetTop(r, distanceRect);
                            graphicCanvas.Children.Add(r);
                            distanceRect += 10;
                        }
                    }
                }
            }
        }

        private void DrawAxis()
        {
            Line ejeX;
            Line ejeY;
            double width = 0;
            double height = 0;

            width = graphicCanvas.ActualWidth;
            height = graphicCanvas.ActualHeight;

            graphicCanvas.Children.Clear();

            ejeX = new Line();
            ejeX.Stroke = Brushes.Black;
            ejeX.StrokeThickness = 2;
            ejeX.X1 = 0;
            ejeX.Y1 = 20;
            ejeX.X2 = width - 20;
            ejeX.Y2 = 20;
            graphicCanvas.Children.Add(ejeX);

            ejeY = new Line();
            ejeY.Stroke = Brushes.Black;
            ejeY.StrokeThickness = 2;
            ejeY.X1 = 20;
            ejeY.Y1 = 0;
            ejeY.X2 = 20;
            ejeY.Y2 = height - 20;
            graphicCanvas.Children.Add(ejeY);
        }
    }
}
