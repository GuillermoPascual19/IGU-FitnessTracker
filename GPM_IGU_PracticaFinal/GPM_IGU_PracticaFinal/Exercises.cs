using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPM_IGU_PracticaFinal
{
    public class Exercises : INotifyPropertyChanged
    {
        string name;
        string description;

        string muscleGroup;
        ObservableCollection<Executions> listExecution = new ObservableCollection<Executions>();

        public Exercises(string name, string description, string muscleGroup)
        {
            this.name = name;
            this.description = description;
            this.muscleGroup = muscleGroup;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } }
        public ObservableCollection<Executions> ListExecution { get { return listExecution; } set { listExecution = value; OnPropertyChanged("ListExecution"); } }
        public string MuscleGroup { get { return muscleGroup; } set { muscleGroup = value; OnPropertyChanged("MuscleGroup"); } }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void ReorderDate()
        {
            Executions aux;
            for(int i = 0; i < listExecution.Count; i++)
            {
                for (int j = 0; j < listExecution.Count - 1; j++)
                {
                    if (DateTime.Compare(listExecution[j].Date, listExecution[i].Date) > 0)
                    {
                        aux = listExecution[j];
                        listExecution[j] = listExecution[i];
                        listExecution[i] = aux;
                    }
                }
            }
        }
    }
}
