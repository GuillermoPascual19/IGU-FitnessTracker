using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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

    public class ExecutionDateChangedEventArgs : EventArgs
    {
        public DateTime date { get; }
        public ExecutionDateChangedEventArgs(DateTime selectedDate)
        {
            date = selectedDate;
        }
    }
    public partial class SecondaryExecutions : Window
    {
        public event EventHandler<ExecutionDateChangedEventArgs> OnExecutionDataSelected;
        Exercises exercise;

        bool isModify = false;

        public SecondaryExecutions(Exercises exercises)
        {
            InitializeComponent();
            exercise = exercises;
            TableExecutions.ItemsSource = exercise.ListExecution;

            if (exercise.ListExecution.Count > 0)
            {
                Delete_Button.IsEnabled = true;
                Modify_Button.IsEnabled = true;
            }

            scroll.SizeChanged += Scroll_SizeChanged;

            DrawGraph();
            DrawAxis();
        }

        //Scroll
        private void Scroll_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            graphicCanvas.Width = scroll.ActualWidth;
            graphicCanvas.Height = scroll.ActualHeight;

            graphicCanvas.Children.Clear();
            DrawAxis();
            DrawGraph();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Tab_ExecutionForm.Visibility = Visibility.Visible;
            Tab_ExecutionForm.Focus();
            Acept_FormExec_Button.IsEnabled = false;
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TableExecutions.SelectedItem != null)
            {
                exercise.ListExecution.Remove((Executions)TableExecutions.SelectedItem);
                if (exercise.ListExecution.Count == 0)
                {
                    Delete_Button.IsEnabled = false;
                    Modify_Button.IsEnabled = false;
                    Acept_FormExec_Button.IsEnabled = false;
                    exercise.ListExecution.Clear();
                }
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
                Tab_ExecutionForm.Visibility = Visibility.Visible;
                Executions ex = (Executions)TableExecutions.SelectedItem;
                repsExecution_TextBox.Text = ex.Reps.ToString();
                weightExecution_TextBox.Text = ex.Weight.ToString();
                dateExecution_TextBox.Text = ex.Date.ToString("dd/MM/yyyy");
                calend.SelectedDate = ex.Date;

                Acept_FormExec_Button.IsEnabled = true;

                Tab_ExecutionForm.Focus();
                isModify = true;
            }
        }

        private void calend_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            dateExecution_TextBox.Text = calend.SelectedDate.Value.ToString("dd/MM/yyyy");
            Acept_FormExec_Button.IsEnabled = true;
        }
        private void Acept_FormExec_Button_Click(object sender, RoutedEventArgs e)
        {
            if (isModify == false)
            {
                if (calend.SelectedDate != null && repsExecution_TextBox.Text != null && weightExecution_TextBox.Text != null)
                {
                    int reps = int.Parse(repsExecution_TextBox.Text);
                    double weight = double.Parse(weightExecution_TextBox.Text);
                    DateTime date = calend.SelectedDate.Value;

                    Delete_Button.IsEnabled = true;
                    Modify_Button.IsEnabled = true;
                    Executions ex = new Executions(reps, weight, date);
                    exercise.ListExecution.Add(ex);
                    exercise.ReorderDate();
                    TableExecutions.ItemsSource = exercise.ListExecution;
                    DrawGraph();
                    DrawAxis();

                    repsExecution_TextBox.Text = "";
                    weightExecution_TextBox.Text = "";
                    dateExecution_TextBox.Text = "";
                    calend.SelectedDate = DateTime.Today;
                    Tab_ExecutionForm.Visibility = Visibility.Collapsed;
                    Tab_Executions.Focus();
                    Delete_Button.IsEnabled = true;
                    Modify_Button.IsEnabled = true;
                }
                else if (calend.SelectedDate == null)
                {
                    MessageBox.Show("No has seleccionado una fecha", "Save error", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                Executions ex = (Executions)TableExecutions.SelectedItem;
                ex.Reps = int.Parse(repsExecution_TextBox.Text);
                ex.Weight = double.Parse(weightExecution_TextBox.Text);
                ex.Date = calend.SelectedDate.Value;

                exercise.ReorderDate();
                TableExecutions.ItemsSource = exercise.ListExecution;
                DrawGraph();
                DrawAxis();
                isModify = false;

                repsExecution_TextBox.Text = "";
                weightExecution_TextBox.Text = "";
                dateExecution_TextBox.Text = "";
                calend.SelectedDate = DateTime.Today;
                Tab_ExecutionForm.Visibility = Visibility.Collapsed;
                Tab_Executions.Focus();
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Tab_ExecutionForm.Visibility = Visibility.Collapsed;
            Tab_Executions.Focus();
            repsExecution_TextBox.Text = "";
            weightExecution_TextBox.Text = "";
            dateExecution_TextBox.Text = "";
            calend.SelectedDate = DateTime.Today;
        }

        private void DrawAxis()
        {
            graphicCanvas.Children.Clear();
            if (exercise == null && exercise.ListExecution == null && exercise.ListExecution.Count < 0)
                return;

            //double width = 740;
            //double height = 340;
            double width = graphicCanvas.Width;
            double height = graphicCanvas.Height;
            double maxHeight = 0;
            double paddingTop = 20;
            double paddingBotton = 50;
            double paddingRight = 40;

            double adjustHeight = height - paddingTop - paddingBotton;

            int maxReps = 80;
            double maxWeight = 125;

            int decrementR = maxReps / 10;
            double decrementW = maxWeight / 10;

            //Left Axis
            for (int i = 0; i <= maxReps; i += decrementR)
            {
                //double y = height - (i * (height - 20) / maxReps);
                double y = height - paddingBotton - (i * adjustHeight / maxReps);
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
                maxHeight = y;
            }
            TextBlock reps = new TextBlock()
            {
                Text = "Reps",
                FontSize = 12
            };
            Canvas.SetLeft(reps, 5);
            Canvas.SetTop(reps, adjustHeight + 40);
            graphicCanvas.Children.Add(reps);

            //Right Axis
            double rightAxis = width - paddingRight;
            for (double i = 0; i <= maxWeight; i += decrementW)
            {
                //double y = height - (i * (height - 20) / maxWeight);
                double y = height - paddingBotton - (i * adjustHeight / maxWeight);
                Line axisWeight = new Line()
                {
                    X1 = rightAxis,
                    Y1 = y,
                    X2 = rightAxis + 10,
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
                Canvas.SetLeft(textBlock2, rightAxis + 10);
                Canvas.SetTop(textBlock2, y - 10);
                graphicCanvas.Children.Add(textBlock2);
                maxHeight = y;
            }

            TextBlock Weight = new TextBlock()
            {
                Text = "Peso(kg)",
                FontSize = 12
            };
            Canvas.SetLeft(Weight, rightAxis - 10);
            Canvas.SetTop(Weight, adjustHeight + 40);
            graphicCanvas.Children.Add(Weight);

            DrawGraph();
        }

        private void DrawGraph()
        {
            double widthRect = 20;
            double groupDistance = 40;
            double currentX = 60;
            double maxCanvasHeigth = graphicCanvas.Height;

            //Establecer "un margen" para que no se vea tan pegado a los bordes
            double paddingTop = 20;
            double paddingBotton = 50;
            double adjustHeight = maxCanvasHeigth - paddingTop - paddingBotton;
            if (adjustHeight < 0)
            {
                adjustHeight = 0;
            }

            double maxWeight = 125;
            int maxReps = 80;

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
                Canvas.SetTop(textBlock, maxCanvasHeigth - paddingBotton + 10);
                graphicCanvas.Children.Add(textBlock);

                foreach (Executions ex in group)
                {
                    if (ex != null && ex.Reps > 0)
                    {
                        ex.Reps = ex.Reps >= maxReps ? maxReps : ex.Reps;
                        ex.Weight = ex.Weight >= maxWeight ? maxWeight : ex.Weight;

                        Rectangle r = new Rectangle();
                        r.Width = 20;
                        //r.Height = ex.Reps * (maxCanvasHeigth - 20) / maxReps;
                        r.Height = Math.Max(ex.Reps * adjustHeight / maxReps, 0);

                        r.Fill = Brushes.Red;
                        r.Stroke = Brushes.Black;
                        Canvas.SetLeft(r, currentX);
                        Canvas.SetTop(r, maxCanvasHeigth - paddingBotton - r.Height);
                        ToolTip tooltip = new ToolTip()
                        {
                            Content = $"Reps: {ex.Reps}"
                        };
                        r.ToolTip = tooltip;

                        graphicCanvas.Children.Add(r);

                        //double y = maxCanvasHeigth - (ex.Weight * (maxCanvasHeigth - 20) / maxWeight);
                        double y = maxCanvasHeigth - paddingBotton - (ex.Weight * adjustHeight / maxWeight);

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

        //La llamamos desde la ventana principal para actualizar los datos de esta ventana, secondaryExecutions
        public void UpdateData(Exercises ex)
        {
            this.exercise = ex;
            TableExecutions.ItemsSource = exercise.ListExecution;

            if (exercise.ListExecution.Count > 0)
            {
                Delete_Button.IsEnabled = true;
                Modify_Button.IsEnabled = true;
            }
            else
            {
                Delete_Button.IsEnabled = false;
                Modify_Button.IsEnabled = false;
            }

            graphicCanvas.Children.Clear();
            DrawGraph();
            DrawAxis();
        }

        private void TableExecutions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableExecutions.SelectedItem != null)
            {
                DateTime selectedDate = ((Executions)TableExecutions.SelectedItem).Date;
                OnExecutionDataSelected?.Invoke(this, new ExecutionDateChangedEventArgs(selectedDate));
            }
        }
    }

}
