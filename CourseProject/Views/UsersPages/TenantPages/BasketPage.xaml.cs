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
using CourseProject.ViewModels;

namespace CourseProject.Views.UsersPages.TenantPages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public BasketPage(string login)
        {
            InitializeComponent();
            InfoTextBlock.Text = BasketGenerationPageViewModel.GetRentalPramses(login);
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            BasketGenerationPageViewModel.AcceptRentalPramses();
            MessageBox.Show("Done!");
            InfoTextBlock.Text = "Cart is empty";
        }

        private void СancelButton_Click(object sender, RoutedEventArgs e)
        {
            BasketGenerationPageViewModel.СancelButton();
            MessageBox.Show("Canceled");
            InfoTextBlock.Text = "Cart is empty";
        }
    }
}
