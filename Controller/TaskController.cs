using SimpleListWinUI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;

namespace SimpleListWinUI.Controllers
{
    public class TaskController
    {
        private readonly string myListFileLocation = Path.Combine(ApplicationData.Current.LocalFolder.Path, "simpleList.txt");
        public List<TaskModel> Tasks { get; private set; } = new List<TaskModel>();

        public TaskController()
        {
            LoadTasksFromFile();
        }
        private void LoadTasksFromFile()
        {


            if (File.Exists(myListFileLocation))
            {
                var readLines = File.ReadAllLines(myListFileLocation);
                Tasks = readLines.Select(line => new TaskModel(line)).ToList();

            }

        }
        public void SaveTasksToFile()
        {


            var taskDescriptions = Tasks.Select(task => task.TaskDescription).ToList();
            File.WriteAllLines(myListFileLocation, taskDescriptions);


        }
        public void AddTask(string taskDescription)
        {
            if (!string.IsNullOrWhiteSpace(taskDescription))
                Tasks.Add(new TaskModel(taskDescription.Trim()));
        }

        public void RemoveTask(int index)
        {
            if (index >= 0 && index < Tasks.Count)
                Tasks.RemoveAt(index);
        }
    }
}