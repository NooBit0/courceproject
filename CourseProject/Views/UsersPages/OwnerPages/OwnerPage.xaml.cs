using System;
using System.Collections.Generic;
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
using CourseProject.Models;
using CourseProject.ViewModels;

namespace CourseProject.Views.UsersPages
{
    /// <summary>
    /// Логика взаимодействия для OwnerPage.xaml
    /// </summary>
    public partial class OwnerPages : Page
    {
        public OwnerPages(string login)
        {
            InitializeComponent();
            InfoTextBox.Text = UserViewModel.GetInfoForUser(login);
        }

        private void ShowStatsButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerMenuFrame.Navigate(new UsersPages.OwnerPage.StatsPage());
        }

        private void ReauthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
