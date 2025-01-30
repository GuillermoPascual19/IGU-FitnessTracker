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
    /// 
    public class SelectionChangeEventArgs : EventArgs
    {
        public Exercises SelectedExercise { get; }
        public SelectionChangeEventArgs(Exercises selectedExercise)
        {
            SelectedExercise = selectedExercise;
        }
    }

    public partial class MainWindow : Window
    {
        SecondaryExecutions sec;
        ObservableCollection<Exercises> exercisesList = new ObservableCollection<Exercises>();
        public event EventHandler<SelectionChangeEventArgs> SelectionChanged;
        

        int cont = 0;

        public MainWindow()
        {
            InitializeComponent();

            ExercisesTable.ItemsSource = exercisesList;
            //SecondaryExecutions sec = new SecondaryExecutions(exercisesList);
            graphicCanvas.Children.Clear();
            DrawAxis();
            DrawGraph(DateTime.Today, 0);
        }

        private void Add_Examples_Button_Click(object sender, RoutedEventArgs e)
        {
            Exercises ex, ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8;
            
            string name;
            string description;
            string muscleName;

            Executions executions;
            DateTime date;

            //=======================First Exercise=======================
            name = "Sentadilla";
            description = "Excelente ejercicio para fortalecer las piernas, en especial los cuadriceps y los gluteos";
            muscleName = "Piernas";
            ex = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 13);
            executions = new Executions(10, 115, date);
            ex.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(12, 120, date);
            ex.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 16);
            executions = new Executions(15, 125, date);
            ex.ListExecution.Add(executions);

            exercisesList.Add(ex);

            //=======================Second Exercise=======================
            name = "Dominadas";
            description = "Ejercicio ideal para desarrollar la espalda y los biceps";
            muscleName = "Espalda";
            ex1 = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 12);
            executions = new Executions(20, 5, date);
            ex1.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(15, 0, date);
            ex1.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 16);
            executions = new Executions(5, 15, date);
            ex1.ListExecution.Add(executions);
            exercisesList.Add(ex1);

            //=======================Third Exercise=======================
            name = "Plancha";
            description = "Un ejercicio isométrico para trabajar el core, especialemente los abdominales";
            muscleName = "Core";
            ex2 = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 12);
            executions = new Executions(60, 0, date);
            ex2.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 12);
            executions = new Executions(70, 0, date);
            ex2.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 12);
            executions = new Executions(80, 0, date);
            ex2.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 13);
            executions = new Executions(60, 0, date);
            ex2.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 13);
            executions = new Executions(80, 0, date);
            ex2.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 15);
            executions = new Executions(80, 0, date);
            ex2.ListExecution.Add(executions);

            exercisesList.Add(ex2);

            //=======================Fourth Exercise=======================
            name = "Curl de Biceps";
            description = "Un ejercicio simple pero efectivo para desarrollas los brazos, especialmente los biceps";
            muscleName = "Brazos";
            ex3 = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 13);
            executions = new Executions(14, 15, date);
            ex3.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(12, 10, date);
            ex3.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 15);
            executions = new Executions(15, 15, date);
            ex3.ListExecution.Add(executions);
            exercisesList.Add(ex3);

            //=======================Fifth Exercise=======================
            name = "Press de banca";
            description = "Este ejercicio se realiza en una maquina guiada y permite trabajar los musculos del pecho con mayor control";
            muscleName = "Pecho";
            ex4 = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 13);
            executions = new Executions(15, 115, date);
            ex4.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(20, 120, date);
            ex4.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 15);
            executions = new Executions(5, 125, date);
            ex4.ListExecution.Add(executions);
            exercisesList.Add(ex4);

            //=======================Sixth Exercise=======================
            name = "Jalón al pecho";
            description = "Un ejercicio en maquima para trabajar la espalda, especialmente el dorsal ancho";
            muscleName = "Espalda";
            ex5 = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 12);
            executions = new Executions(14, 65, date);
            ex5.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(12, 90, date);
            ex5.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 13);
            executions = new Executions(15, 75, date);
            ex5.ListExecution.Add(executions);
            exercisesList.Add(ex5);

            //=======================Seventh Exercise=======================
            name = "Prensa de pierna";
            description = "Una maquina guiada para trabajar los musculos de las piernas, especialmente los cuadriceps";
            muscleName = "Piernas";
            ex6 = new Exercises(name, description, muscleName);
            
            date = new DateTime(2024, 10, 12);
            executions = new Executions(12, 100, date);
            ex6.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 12);
            executions = new Executions(15, 110, date);
            ex6.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(14, 115, date);
            ex6.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(12, 120, date);
            ex6.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 16);
            executions = new Executions(15, 125, date);
            ex6.ListExecution.Add(executions);
            exercisesList.Add(ex6);

            //=======================Eighth Exercise=======================
            name = "Extensión de pierna";
            description = "Este ejercicio se enfoca en el desarrollo de los cuadriceps mediante una máquina guiada";
            muscleName = "Piernas";
            ex7 = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 13);
            executions = new Executions(14, 15, date);
            ex7.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(12, 20, date);
            ex7.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 15);
            executions = new Executions(15, 25, date);
            ex7.ListExecution.Add(executions);
            exercisesList.Add(ex7);

            //=======================Nineth Exercise=======================
            name = "Press de hombros";
            description = "Un ejercicio para trabajar  los hombros utilizando una máquina guiada";
            muscleName = "Brazos";
            ex8 = new Exercises(name, description, muscleName);
            date = new DateTime(2024, 10, 13);
            executions = new Executions(14, 15, date);
            ex8.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 14);
            executions = new Executions(12, 20, date);
            ex8.ListExecution.Add(executions);

            date = new DateTime(2024, 10, 16);
            executions = new Executions(15, 15, date);
            ex8.ListExecution.Add(executions);
            exercisesList.Add(ex8);

            Delete_Button.IsEnabled = true;
            Modify_Button.IsEnabled = true;

            DrawAxis();
            DrawGraph(DateTime.Today, 0);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            //ExersiceDataWindow exersiceDataWindow = new ExersiceDataWindow(exercisesList);
            //exerciceDataWindow.ShowDialog();
            //if(exersiceDataWindow.DialogResult == true)
            //{
            //    exercisesList.Add(exersiceDataWindow.newExercise);
            //}
            //Delete_Button.IsEnabled = true;
            
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if(ExercisesTable.SelectedItem != null)
            {
                exercisesList.Remove((Exercises)ExercisesTable.SelectedItem);
            }
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExercisesTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChanged?.Invoke(this, new SelectionChangeEventArgs((Exercises)ExercisesTable.SelectedItem));
            Exercises ex = (Exercises)ExercisesTable.SelectedItem;
            if(ExercisesTable.SelectedItem != null)
            {
                if (sec == null)
                {
                    SecondaryExecutions sec = new SecondaryExecutions(ex);

                    sec.Show();
                    sec.Focus();
                }
                else
                {
                    sec.Show();
                }
            }
            
        }


        //private void EX_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    switch (e.PropertyName)
        //    {
        //        case "Name":
        //        case "Description":
        //        case "ListMuscles":
        //        case "ListExecution":
        //            DrawAxis();
        //            DrawGraphic();
        //            break;
        //    }
        //}

        private void DrawAxis()
        {
            Line axis;

            string[] musclegroups = { "Piernas", "Espalda", "Core", "Pecho", "Brazos" };

            double centerX = (graphicCanvas.Width) / 2;
            double centerY = (graphicCanvas.Height) / 2;
            Console.WriteLine(centerX);
            Console.WriteLine(centerY);
            double radius = Math.Min(centerX, centerY) - 40;
            graphicCanvas.Children.Clear();

            for (int i = 0; i < musclegroups.Length; i++)
            {
                double angle = (5 + i * 2 * Math.PI) / musclegroups.Length;
                axis = new Line();
                axis.Stroke = Brushes.Black;
                axis.StrokeThickness = 2;
                axis.X1 = centerX;
                axis.Y1 = centerY;
                axis.X2 = centerX + radius * Math.Cos(angle);
                axis.Y2 = centerY + radius * Math.Sin(angle);

                TextBlock textBlock = new TextBlock
                {
                    Text = musclegroups[i],
                    FontSize = 12
                };

                Canvas.SetLeft(textBlock, centerX + (radius + 45) * Math.Cos(angle) - textBlock.ActualWidth / 2);
                Canvas.SetTop(textBlock, centerY + (radius + 25) * Math.Sin(angle) - textBlock.ActualHeight / 2);

                graphicCanvas.Children.Add(axis);
                graphicCanvas.Children.Add(textBlock);
            }
        }

        private void DrawGraph(DateTime date, int flag)
        {
            if (exercisesList.Count == 0) return;

            double centerX = graphicCanvas.Width / 2;
            double centerY = graphicCanvas.Height / 2;
            double radius = Math.Min(centerX, centerY) - 30;
            Point point;
            PointCollection points = new PointCollection();
            Ellipse ellipse;
            Polygon polygon;

            string[] musclegroups = { "Piernas", "Espalda", "Core", "Brazos", "Pecho" };

            if (date.Equals(null) || flag == 0) date = DateTime.Today;

            var totalRepsPerMuscleGroup = exercisesList
                .Where(ex => ex.ListExecution.Any(exec => exec.Date.Date == date.Date))
                .GroupBy(x => x.MuscleGroup)
                .Select(group => new
                {
                    MuscleGroup = group.Key,
                    TotalReps = group
                        .SelectMany(x => x.ListExecution)
                        .Where(exec => exec.Date.Date == date.Date)
                        .Sum(exec => exec.Reps)
                }).ToList();

            double maxReps = totalRepsPerMuscleGroup.Any() ? Math.Min(100, totalRepsPerMuscleGroup.Max(x => x.TotalReps)) : 0;
            
            for (int i = 0; i < musclegroups.Length; i++)
            {
                double angle = (5 + i * 2 * Math.PI) / musclegroups.Length;

                var muscleReps = totalRepsPerMuscleGroup.FirstOrDefault(group => group.MuscleGroup == musclegroups[i]);
                double reps = muscleReps != null ? muscleReps.TotalReps : 0;
                double radius2 = ((reps / 100 ) * radius);

                double x = (centerX + radius2 * Math.Cos(angle));
                double y = (centerY + radius2 * Math.Sin(angle));
                point = new Point(x,y);
                points.Add(point);
                ellipse = new Ellipse
                {
                    Width = 5,
                    Height = 5,
                    Fill = Brushes.Red
                };
                Canvas.SetLeft(ellipse, x - (ellipse.Width / 2));
                Canvas.SetTop(ellipse, y - (ellipse.Height / 2));

                ToolTip tooltip = new ToolTip()
                {
                    Content = $"Reps: {(muscleReps?.TotalReps ?? 0)}"
                };
                ellipse.ToolTip = tooltip;
                graphicCanvas.Children.Add(ellipse);
            }

            polygon = new Polygon
            {
                Points = new PointCollection(points),
                Stroke = Brushes.DarkBlue,
                StrokeThickness = 2,
                //Fill = Brushes.LightBlue
                Fill = new SolidColorBrush(Color.FromArgb(100, 173, 216, 230))
            };
            graphicCanvas.Children.Add(polygon);
        }


        private void PrevDay_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime date = DateTime.Today.AddDays(cont-1);
            cont -= 1;

            DrawGraph(date, -1);
        }

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Today;
            DrawGraph(date, 0);
        }

        private void PostDay_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Today.AddDays(cont + 1);
            cont += 1;

            DrawGraph(date, 1);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
