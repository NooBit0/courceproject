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
    /// Логика взаимодействия для ArendetPremisesPagecs.xaml
    /// </summary>
    public partial class ArendetPremisesPage : Page
    {
        private string _login;

        private int _rentalPremisesId;

        private int _tenantRentalPremisesId;

        public ArendetPremisesPage(string login)
        {
            InitializeComponent();
            _login = login;
            _rentalPremisesId = ArendetPremisesPageGenerationViewModel.GetFirstId(_login);
            _tenantRentalPremisesId = _rentalPremisesId;
            InfoTextBlock.Text = ArendetPremisesPageGenerationViewModel.GetRentalPremises(_rentalPremisesId);
            (string rentalPremisesImage, string buildingImage) images = ArendetPremisesPageGenerationViewModel.GetImages(_rentalPremisesId);
            BuildingImage.Source = new BitmapImage(new Uri($"/Resources/{images.buildingImage}.jpg", UriKind.Relative));
            RentalPremisesImage.Source = new BitmapImage(new Uri($"/Resources/{images.rentalPremisesImage}.jpg", UriKind.Relative));
            if (ArendetPremisesPageGenerationViewModel.CheckRentalStatus(_login, _rentalPremisesId))
            {
                RentaStatusLabel.Text = "Leased by you";
                RentaStatusLabel.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                RentaStatusLabel.Text = "Awaiting approval";
                RentaStatusLabel.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (ArendetPremisesPageGenerationViewModel.CheckNextPlaceId(_login, _tenantRentalPremisesId))
            {
                NextButton.Visibility = Visibility.Visible;
            }
            else
            {
                BackButton.Visibility = Visibility.Hidden;
                NextButton.Visibility = Visibility.Hidden;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _rentalPremisesId = ArendetPremisesPageGenerationViewModel.GetBackIdformDataBase(_login, _tenantRentalPremisesId);
            _tenantRentalPremisesId = _rentalPremisesId;
            InfoTextBlock.Text = ArendetPremisesPageGenerationViewModel.GetRentalPremises(_rentalPremisesId);
            (string rentalPremisesImage, string buildingImage) images = ArendetPremisesPageGenerationViewModel.GetImages(_rentalPremisesId);
            BuildingImage.Source = new BitmapImage(new Uri($"/Resources/{images.buildingImage}.jpg", UriKind.Relative));
            RentalPremisesImage.Source = new BitmapImage(new Uri($"/Resources/{images.rentalPremisesImage}.jpg", UriKind.Relative));
            if (ArendetPremisesPageGenerationViewModel.CheckRentalStatus(_login, _rentalPremisesId))
            {
                RentaStatusLabel.Text = "Leased by you";
                RentaStatusLabel.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                RentaStatusLabel.Text = "Awaiting approval";
                RentaStatusLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (ArendetPremisesPageGenerationViewModel.CheckBackPlaceId(_login, _tenantRentalPremisesId))
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

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _rentalPremisesId = ArendetPremisesPageGenerationViewModel.GetNextIdformDataBase(_login, _tenantRentalPremisesId);
            _tenantRentalPremisesId = _rentalPremisesId;
            InfoTextBlock.Text = ArendetPremisesPageGenerationViewModel.GetRentalPremises(_rentalPremisesId);
            (string rentalPremisesImage, string buildingImage) images = ArendetPremisesPageGenerationViewModel.GetImages(_rentalPremisesId);
            BuildingImage.Source = new BitmapImage(new Uri($"/Resources/{images.buildingImage}.jpg", UriKind.Relative));
            RentalPremisesImage.Source = new BitmapImage(new Uri($"/Resources/{images.rentalPremisesImage}.jpg", UriKind.Relative));
            if (ArendetPremisesPageGenerationViewModel.CheckRentalStatus(_login, _rentalPremisesId))
            {
                RentaStatusLabel.Text = "Leased by you";
                RentaStatusLabel.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                RentaStatusLabel.Text = "Awaiting approval";
                RentaStatusLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (ArendetPremisesPageGenerationViewModel.CheckNextPlaceId(_login, _tenantRentalPremisesId))
            {
                NextButton.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                NextButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
