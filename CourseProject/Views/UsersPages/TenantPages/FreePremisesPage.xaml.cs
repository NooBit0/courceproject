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
    /// Логика взаимодействия для FreePremisesPage.xaml
    /// </summary>
    public partial class FreePremisesPage : Page
    {
        private string _login;
        private int _rentalPremises;

        public FreePremisesPage(string login)
        {
            _login = login;
            _rentalPremises = FreePremisesPageGenerationViewModel.GetId();
            InitializeComponent();
            InfoTextBlock.Text = FreePremisesPageGenerationViewModel.GetRentalPremises(_rentalPremises);
            (string rentalPremisesImage, string buildingImage) images = FreePremisesPageGenerationViewModel.GetImages(_rentalPremises);
            BuildingImage.Source = new BitmapImage(new Uri($"/Resources/{images.buildingImage}.jpg", UriKind.Relative));
            RentalPremisesImage.Source = new BitmapImage(new Uri($"/Resources/{images.rentalPremisesImage}.jpg", UriKind.Relative));
            if (FreePremisesPageGenerationViewModel.CheckNextPlaceId(_rentalPremises))
            {
                NextButton.Visibility = Visibility.Visible;
            }
            else
            {
                BackButton.Visibility = Visibility.Hidden;
                NextButton.Visibility = Visibility.Hidden;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _rentalPremises = FreePremisesPageGenerationViewModel.GetNextIdformDataBase(_rentalPremises);
            InfoTextBlock.Text = FreePremisesPageGenerationViewModel.GetRentalPremises(_rentalPremises);
            (string rentalPremisesImage, string buildingImage) images = FreePremisesPageGenerationViewModel.GetImages(_rentalPremises);
            BuildingImage.Source = new BitmapImage(new Uri($"/Resources/{images.buildingImage}.jpg", UriKind.Relative));
            RentalPremisesImage.Source = new BitmapImage(new Uri($"/Resources/{images.rentalPremisesImage}.jpg", UriKind.Relative));
            if (FreePremisesPageGenerationViewModel.CheckNextPlaceId(_rentalPremises))
            {
                NextButton.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                NextButton.Visibility = Visibility.Hidden;
                BackButton.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _rentalPremises = FreePremisesPageGenerationViewModel.GetBackIdformDataBase(_rentalPremises);
            InfoTextBlock.Text = FreePremisesPageGenerationViewModel.GetRentalPremises(_rentalPremises);
            (string rentalPremisesImage, string buildingImage) images = FreePremisesPageGenerationViewModel.GetImages(_rentalPremises);
            BuildingImage.Source = new BitmapImage(new Uri($"/Resources/{images.buildingImage}.jpg", UriKind.Relative));
            RentalPremisesImage.Source = new BitmapImage(new Uri($"/Resources/{images.rentalPremisesImage}.jpg", UriKind.Relative));
            if (FreePremisesPageGenerationViewModel.CheckBackPlaceId(_rentalPremises))
            {
                NextButton.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                NextButton.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Hidden;
            }
        }

        private void RentalEndDateBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (RentalEndDateBox.Text == "dd/mm/yyyy" || RentalEndDateBox.Text == string.Empty)
            {
                RentalEndDateBox.Text = string.Empty;
            }
        }

        private void RentalEndDateBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (RentalEndDateBox.Text == "dd/mm/yyyy" || RentalEndDateBox.Text == string.Empty)
            {
                RentalEndDateBox.Text = "dd/mm/yyyy";
            }
        }

        private void RentalEndDateBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FreePremisesPageGenerationViewModel.CheckInputRentalEndDate(RentalEndDateBox.Text))
            {
                if ((DateTime.Now.Day <= DateTime.Parse(RentalEndDateBox.Text).Day &&
                    DateTime.Now.Month < DateTime.Parse(RentalEndDateBox.Text).Month) ||
                    DateTime.Now.Year < DateTime.Parse(RentalEndDateBox.Text).Year)
                {
                    RentalEndDateBox.Foreground = new SolidColorBrush(Colors.Green);
                    ToRentButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                RentalEndDateBox.Foreground = new SolidColorBrush(Colors.Red);
                ToRentButton.Visibility = Visibility.Hidden;
            }
        }

        private void ToRentButton_Click(object sender, RoutedEventArgs e)
        {
            FreePremisesPageGenerationViewModel.AddToBasket(_login, _rentalPremises, DateTime.Now.ToString("dd/MM/yyyy"), RentalEndDateBox.Text);
            NavigationService.Navigate(new FreePremisesPage(_login));
            MessageBox.Show("Added to basket!");
        }
    }
}
