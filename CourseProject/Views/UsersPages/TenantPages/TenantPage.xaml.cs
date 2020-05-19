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
using CourseProject.Views.UsersPages.TenantPages;

namespace CourseProject.Views.UsersPages
{
    /// <summary>
    /// Логика взаимодействия для TenantPage.xaml
    /// </summary>
    public partial class TenantPage : Page
    {
        private string _login;

        public TenantPage(string login)
        {
            InitializeComponent();

            _login = login;

            using (var user = new CourceProjectDbContext())
            {
                InfoTextBox.Text = UserViewModel.GetInfoForUser(login);
            }
        }

        private void ReauthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void ArendetPremisesButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArendetPremisesPageGenerationViewModel.CheckPlaceOnNull(_login))
            {
                TenantMenuFrame.Navigate(new ArendetPremisesPage(_login));
            }
            else
            {
                MessageBox.Show("No rental premises");
            }
        }

        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            TenantMenuFrame.Navigate(new BasketPage(_login));
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChengePasswordPage(_login));
        }

        private void FreePremises_Click(object sender, RoutedEventArgs e)
        {
            if (FreePremisesPageGenerationViewModel.CheckPlaceOnNull())
            {
                TenantMenuFrame.Navigate(new FreePremisesPage(_login));
            }
            else
            {
                MessageBox.Show("No free rental premises");
            }
        }
    }
}
