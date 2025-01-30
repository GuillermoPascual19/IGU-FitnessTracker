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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace GPM_IGU_PracticaFinal
{
    /// <summary>
    /// Lógica de interacción para SecondaryExecutions.xaml
    /// </summary>
    //public class SelectionExChangedEventArgs : EventArgs
    //{
    //    public Exercises exer { get; set; }
    //    public SelectionExChangedEventArgs(Exercises exercises)
    //    {
    //        exercises = exer;
    //    }
    //}

    //private MainWindow mainW;
    //private ExerciseSelection exerciseSelection;

    public partial class SecondaryExecutions : Window
    {
        //public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
        Exercises exercise;
        public SecondaryExecutions(Exercises exercises)
        {
            InitializeComponent();
            exercise = exercises;
            TableExecutions.ItemsSource = exercise.ListExecution;
            
            if(exercise.ListExecution.Count > 0)
            {
                Delete_Button.IsEnabled = true;
                Modify_Button.IsEnabled = true;
            }

            DrawGraph();
            DrawAxis();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Tab_ExecutionForm.Focus();
            ExerciseName_TextBox.Text = exercise.Name;
            Delete_Button.IsEnabled = true;
            Modify_Button.IsEnabled = true;
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if(TableExecutions.SelectedItem != null)
            {
                exercise.ListExecution.Remove((Executions)TableExecutions.SelectedItem);
            }
            exercise.ReorderDate();
            TableExecutions.ItemsSource = exercise.ListExecution;
            DrawGraph();
            DrawAxis();

        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TableExecutions.SelectedItem != null)
            {
                
                Executions ex = (Executions)TableExecutions.SelectedItem;
                repsExecution_TextBox.Text = ex.Reps.ToString();
                weightExecution_TextBox.Text = ex.Weight.ToString();
                dateExecution_TextBox.Text = ex.Date.ToString("dd/MM/yyyy");
                calend.SelectedDate = ex.Date;

                Tab_ExecutionForm.Focus();

            }
        }

        private void Add_4Exec_Button_Click(object sender, RoutedEventArgs e)
        {
            Executions ex;

            int reps = 0, weight = 0;
            Random rand = new Random();
            DateTime date = new DateTime(1999, 1, 1);
            int range;

            for (int i = 0; i < 4; i++)
            {
                reps = rand.Next(1, 30);
                weight = rand.Next(1, 200);
                range = (DateTime.Today - date).Days;
                date = date.AddDays(rand.Next(range));
                ex = new Executions(reps, weight, date);
                exercise.ListExecution.Add(ex);
            }

            exercise.ReorderDate();
            TableExecutions.ItemsSource = exercise.ListExecution;
            DrawGraph();
            DrawAxis();
            Delete_Button.IsEnabled = true;
            Modify_Button.IsEnabled = true;
        }

        private void DrawAxis()
        {
            graphicCanvas.Children.Clear();
            if (exercise == null && exercise.ListExecution == null && exercise.ListExecution.Count < 0)
                return;

            //double width = graphicCanvas.ActualWidth;
            //double height =  graphicCanvas.ActualHeight;
            double width = 740;
            double height = 340;
            double maxHeight = 0; 
            graphicCanvas.Children.Clear();

            //Maximos valores de repeticiones y peso, 30 y 150 respectivamente, para el eje Y y X
            int maxReps = 30;
            double maxWeight =  150;

            int decrementR = maxReps / 10;
            double decrementW = maxWeight / 10;
            for (int i = 0; i <= maxReps; i += decrementR)
            {
                double y = height - (i * (height - 20) / maxReps);
                Line axisY = new Line()
                {
                    X1 = 20,
                    Y1 = y,
                    X2 = 30,
                    Y2 = y,
                    Stroke = Brushes.Red,
                    StrokeThickness = 1,
                };
                graphicCanvas.Children.Add(axisY);
                TextBlock textBlock = new TextBlock()
                {
                    Text = i.ToString(),
                    FontSize = 12
                };
                Canvas.SetLeft(textBlock, 0);
                Canvas.SetTop(textBlock, y - 10);
                graphicCanvas.Children.Add(textBlock);
            }
            
            for (double i = 0; i <= maxWeight; i += decrementW)
            {
                double y = height - (i * (height - 20) / maxWeight);
                Line axisWeight = new Line()
                {
                    X1 = width - 30,
                    Y1 = y,
                    X2 = width - 20,
                    Y2 = y,
                    Stroke = Brushes.DarkBlue,
                    StrokeThickness = 1,
                };
                graphicCanvas.Children.Add(axisWeight);
                TextBlock textBlock2 = new TextBlock()
                {
                    Text = i.ToString(),
                    FontSize = 12
                };
                Canvas.SetLeft(textBlock2, width - 10);
                Canvas.SetTop(textBlock2, y - 10);
                graphicCanvas.Children.Add(textBlock2);
                maxHeight = y;
            }

            TextBlock reps = new TextBlock()
            {
                Text = "Reps",
                FontSize = 12
            };
            Canvas.SetLeft(reps, 0);
            Canvas.SetTop(reps, height + 15);
            graphicCanvas.Children.Add(reps);

            TextBlock Weight = new TextBlock()
            {
                Text = "Peso(kg)",
                FontSize = 12
            };
            Canvas.SetLeft(Weight, width - 10);
            Canvas.SetTop(Weight, height + 15);
            graphicCanvas.Children.Add(Weight);

            DrawGraph();
        }

        private void DrawGraph()
        {
            double widthRect = 20;
            double distancePol = 60;
            double groupDistance = 40;

            double maxCanvasHeigth = 340;
            //double maxCanvasHeigth = graphicCanvas.ActualHeight;

            double maxWeight = 150;

            int maxReps = 30;
            double currentX = 60;

            if (exercise == null && exercise.ListExecution == null && exercise.ListExecution.Count < 0)
                return;
            
            var groupExecutions = exercise.ListExecution
                        .GroupBy(x => x.Date)
                        .OrderBy(x => x.Key);

            Polyline pol = new Polyline()
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2,
                StrokeDashArray = new DoubleCollection { 4, 2 },
            };

            foreach (var group in groupExecutions)
            {

                TextBlock textBlock = new TextBlock
                {
                    Text = group.Key.ToString("dd/MM/yyyy"),
                    FontSize = 12,
                    TextAlignment = TextAlignment.Center,
                };
                Canvas.SetLeft(textBlock, currentX + (group.Count() * widthRect) / 2 - 10);

                Canvas.SetTop(textBlock, maxCanvasHeigth + 10);
                graphicCanvas.Children.Add(textBlock);

                foreach (Executions ex in group)
                {
                    if (ex != null && ex.Reps > 0)
                    {
                        Rectangle r = new Rectangle();
                        r.Width = 20;
                        r.Height = ex.Reps * maxCanvasHeigth / maxReps;
                        r.Fill = Brushes.Red;
                        Canvas.SetLeft(r, currentX);

                        Canvas.SetTop(r, maxCanvasHeigth - r.Height);

                        ToolTip tooltip = new ToolTip()
                        {
                            Content = $"Reps: {ex.Reps}"
                        };
                        r.ToolTip = tooltip;

                        graphicCanvas.Children.Add(r);

                        double y = maxCanvasHeigth - (ex.Weight * maxCanvasHeigth / maxWeight);

                        Ellipse elip = new Ellipse()
                        {
                            Width = 8,
                            Height = 8,
                            Fill = Brushes.Blue,
                        };
                        Canvas.SetLeft(elip, currentX + widthRect / 2 - 2.5);
                        Canvas.SetTop(elip, y);

                        ToolTip tooltipEllipse = new ToolTip()
                        {
                            Content = $"Peso: {ex.Weight}kg"
                        };
                        elip.ToolTip = tooltipEllipse;

                        graphicCanvas.Children.Add(elip);
                        Point point = new Point(currentX + widthRect / 2 + 2, y);
                        pol.Points.Add(point);
                    }
                    currentX += widthRect;
                }

                currentX += groupDistance;
            }

            graphicCanvas.Children.Add(pol);

        }

        private void calend_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            dateExecution_TextBox.Text = calend.SelectedDate.Value.ToString("dd/MM/yyyy");
        }
        private void Acept_FormExec_Button_Click(object sender, RoutedEventArgs e)
        {
            if (exercise != null)
            {
                ExerciseName_TextBox.Text = exercise.Name;
                if(calend.SelectedDate != null && repsExecution_TextBox.Text != null && weightExecution_TextBox.Text != null)
                {
                    Acept_FormExec_Button.IsEnabled = true;
                    Delete_Button.IsEnabled = true;
                    Modify_Button.IsEnabled = true;
                    Executions ex = new Executions(int.Parse(repsExecution_TextBox.Text), int.Parse(weightExecution_TextBox.Text), calend.SelectedDate.Value);
                    exercise.ListExecution.Add(ex);
                    exercise.ReorderDate();
                    TableExecutions.ItemsSource = exercise.ListExecution;
                    DrawGraph();
                    DrawAxis();
                } else if (calend.SelectedDate == null)
                {
                    MessageBox.Show("No has seleccionado una fecha","Save error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (repsExecution_TextBox.Text == null)
                {
                    MessageBox.Show("No has introducido las repeticiones", "Save error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (weightExecution_TextBox.Text == null)
                {
                    MessageBox.Show("No has introducido el peso", "Save error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                ExerciseName_TextBox.Text = "No hay ejercicio seleccionado";
                MessageBox.Show("No has seleccionado un ejercicio", "Save error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Tab_Executions.Focus();
            repsExecution_TextBox.Text = "";
            weightExecution_TextBox.Text = "";
            dateExecution_TextBox.Text = "";
            calend.SelectedDate = DateTime.Today;
        }

        private void dateExecution_TextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            calend.SelectedDate = DateTime.Parse(dateExecution_TextBox.Text);
        }

    }
}
