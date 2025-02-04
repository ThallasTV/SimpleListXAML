using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleListXaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> simpleList = new List<string>();
        private string myListFileLocation = "myList.txt";
        public MainWindow()
        {
            InitializeComponent();
            loadListFromFile();
        }

        private void loadListFromFile()
        {
            if(File.Exists(myListFileLocation))
                simpleList = new List<string>(File.ReadLines(myListFileLocation));
        }

        private void saveListToFile()
        {
            File.WriteAllLines(myListFileLocation, simpleList);
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TaskInput.Text))
            {
                simpleList.Add(TaskInput.Text);
                TaskInput.Clear();
                RefreshList();
                saveListToFile();
            }
        }

        private void RemoveTask_Click(Object sender, RoutedEventArgs e)
        {
            if(TaskListBox.SelectedIndex >= 0)
            {
                simpleList.RemoveAt(TaskListBox.SelectedIndex);
                RefreshList();
                saveListToFile();
            }
        }

        private void RefreshList()
        {
            TaskListBox.ItemsSource = null;
            TaskListBox.ItemsSource = simpleList;
        }
    }
}
