using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GPM_IGU_PracticaFinal
{
    /// <summary>
    /// Lógica de interacción para SecondaryExecutions.xaml
    /// </summary>
    public partial class SecondaryExecutions : Window
    {
        Exercises exercise;
        Executions exec;
        public SecondaryExecutions(Exercises exercises)
        {
            InitializeComponent();
            exercise = exercises;
            TableExecutions.ItemsSource = exercise.ListExecution;

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_4Exec_Button_Click(object sender, RoutedEventArgs e)
        {
            Executions ex;

            int reps = 0, weight = 0;
            Random rand = new Random();
            DateTime date = new DateTime(1999, 1, 1);
            int range;

            //=======================First Exercise========================
            reps = rand.Next(1, 30);
            weight = rand.Next(1, 200);
            range = (DateTime.Today - date).Days;
            date = date.AddDays(rand.Next(range));
            ex = new Executions(reps, weight, date);
            exercise.ListExecution.Add(ex);

            //=======================Second Exercise=======================
            reps = rand.Next(1, 30);
            weight = rand.Next(1, 200);
            range = (DateTime.Today - date).Days;
            date = date.AddDays(rand.Next(range));
            ex = new Executions(reps, weight, date);
            exercise.ListExecution.Add(ex);

            //=======================Third Exercise========================
            reps = rand.Next(1, 30);
            weight = rand.Next(1, 200);
            range = (DateTime.Today - date).Days;
            date = date.AddDays(rand.Next(range));
            ex = new Executions(reps, weight, date);
            exercise.ListExecution.Add(ex);

            //=======================Fourth Exercise=======================
            reps = rand.Next(1, 30);
            weight = rand.Next(1, 200);
            range = (DateTime.Today - date).Days;
            date = date.AddDays(rand.Next(range));
            ex = new Executions(reps, weight, date);
            exercise.ListExecution.Add(ex);

            exercise.ReorderDate();
            TableExecutions.ItemsSource = exercise.ListExecution;
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
