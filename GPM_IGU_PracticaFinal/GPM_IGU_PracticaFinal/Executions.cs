using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GPM_IGU_PracticaFinal 
{
    public class Executions : INotifyPropertyChanged
    {
        int reps;
        int weight;
        DateTime date;

        public event PropertyChangedEventHandler PropertyChanged;

        public Executions(int reps, int weight, DateTime date)
        {
            this.reps = reps;
            this.weight = weight;
            this.date = date;
        }


        public int Reps { get { return reps; } set { reps = value; OnPropertyChanged("Reps"); } }
        public int Weight { get { return weight; } set { weight = value; OnPropertyChanged("Weight"); } }
        public DateTime Date { get { return date; } set { date = value; OnPropertyChanged("Date"); } }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return date.Day.ToString() + " " + date.Month.ToString() + " " + date.Year.ToString();
        }
    }
}
