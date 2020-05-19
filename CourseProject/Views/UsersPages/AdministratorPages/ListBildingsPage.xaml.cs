using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace CourseProject.Views.UsersPages.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для ListBildingsPage.xaml
    /// </summary>
    public partial class ListBildingsPage : Page
    {
        private AdministratorViewModel _viewModels;

        public ListBildingsPage()
        {
            InitializeComponent();
            _viewModels = new AdministratorViewModel();
        }

        private void BildingsButton_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = "Bildings";
            BuildingIDColumn.Header = "ID";
            CourseProjectDataGrid.ItemsSource = _viewModels.GetBildings().ToBindingList();
            BuildingIDColumn.Visibility = Visibility.Visible;
            AdressColumn.Visibility = Visibility.Visible;
            ImageColumn.Visibility = Visibility.Visible;

            RentalCheckColumn.Visibility = Visibility.Hidden;
            PriceColumn.Visibility = Visibility.Hidden;
            RentalBeginDateColumn.Visibility = Visibility.Hidden;
            RentalEndDateColumn.Visibility = Visibility.Hidden;
            RentalNumberColumn.Visibility = Visibility.Hidden;
            AreaColumn.Visibility = Visibility.Hidden;
        }

        private void RentalPremisesButton_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = "Rental Premises";
            CourseProjectDataGrid.ItemsSource = _viewModels.GetRentalPremises().ToBindingList();
            AdressColumn.Visibility = Visibility.Hidden;
            PriceColumn.Visibility = Visibility.Hidden;

            RentalCheckColumn.Visibility = Visibility.Visible;
            PriceColumn.Visibility = Visibility.Visible;
            RentalBeginDateColumn.Visibility = Visibility.Visible;
            RentalEndDateColumn.Visibility = Visibility.Visible;
            BuildingIDColumn.Header = "BuildingID";
            BuildingIDColumn.Visibility = Visibility.Visible;
            RentalNumberColumn.Visibility = Visibility.Visible;
            AreaColumn.Visibility = Visibility.Visible;
            ImageColumn.Visibility = Visibility.Visible;
        }

        private void SaveBdButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModels.CourseProjectDbSave();
        }
    }
}
