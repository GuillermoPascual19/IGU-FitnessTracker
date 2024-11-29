

using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPM_IGU_PracticaFinal
{
    public class MusclesGroups : INotifyPropertyChanged
    {
        string name;

        //ObservableCollection<Exercises> exercises = new ObservableCollection<Exercises>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MusclesGroups(string name) 
        { 
            this.name = name;
        }


        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        //public ObservableCollection<Exercises> Exercise { get { return exercises; } set { exercises = value; OnPropertyChanged("Exercises"); } }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
