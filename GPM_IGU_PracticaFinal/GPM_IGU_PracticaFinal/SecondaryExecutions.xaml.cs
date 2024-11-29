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
        ObservableCollection<Exercises> listExercises = new ObservableCollection<Exercises>();
        Executions exec;
        public SecondaryExecutions(ObservableCollection<Exercises> exercises)
        {
            InitializeComponent();
            listExercises = exercises;
            //TableExecutions.ItemsSource = listExercises.ListExecution;

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Executions ex; 

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_4Exec_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
