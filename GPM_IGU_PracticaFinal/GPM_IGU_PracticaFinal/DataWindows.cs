using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPM_IGU_PracticaFinal
{
    public static class DataWindows
    {
        private static List<Exercises> dataSelectionInternal;
        public static List<Exercises> dataSelection
        {
            get
            {
                if (dataSelectionInternal == null)
                {
                    dataSelectionInternal = new List<Exercises>();
                }
                return dataSelectionInternal;
            }
            set { dataSelectionInternal = value; }
        }

        public static List<Executions> getAllExecutionsPerExercise(string exerciseName)
        {
            Exercises exercise = dataSelectionInternal.Find(e => e.Name == exerciseName);
            return exercise?.ListExecution.ToList() ?? new List<Executions>();
        }

        public static List<Executions> getAllExecutionsPerDay(string exerciseName, DateTime date)
        {
            List<Executions> allExecutions = getAllExecutionsPerExercise(exerciseName) ?? new List<Executions>();

            List<Executions> allExecutionsPerDay = allExecutions
            .GroupBy(e => e.Date.Date)
            .Where(g => g.Key == date.Date)
            .Select(g => g.First())
            .ToList();

            return allExecutionsPerDay;
        }
    }
}
