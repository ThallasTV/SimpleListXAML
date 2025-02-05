using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using System.Collections.ObjectModel;
using SimpleListWinUI.Controllers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SimpleListWinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TaskController TaskController = new TaskController();

        public MainPage()
        {
            this.InitializeComponent();
            RefreshList();
        }

        private void RefreshList()
        {
            ListViewTask.ItemsSource = null;
            ListViewTask.ItemsSource = TaskController.Tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputTask.Text))
            {
                
                TaskController.AddTask(InputTask.Text);
                InputTask.Text = string.Empty;
                RefreshList();
                
            }
        }
        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewTask.SelectedIndex >= 0)
            {
                TaskController.RemoveTask(ListViewTask.SelectedIndex);
                RefreshList();
            }
        }
        private void SaveTasks_Click(object sender, RoutedEventArgs e)
        {
            TaskController.SaveTasksToFile();
        }

        private void Task_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            var task = checkBox.Content.ToString();
            
            //int index = (int)checkBox.Tag;
            //simpleList[index] = simpleList[index].Insert(0, "? ");
            //RefreshList();
        }

        private void Task_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            var task = checkBox.Content.ToString();
        }
    }
}
