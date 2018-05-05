namespace InventarioConsulta.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    //using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    class ProductsViewModel : BaseViewModel
    {
        //#region Services
        //private ApiService apiService;
        //#endregion

        #region Attributes
        private ObservableCollection<ProductItemViewModel> products;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<ProductItemViewModel> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public ProductsViewModel()
        {
            //this.apiService = new ApiService();
            this.LoadProducts();
        }
        #endregion

        #region Methods
        private async void LoadProducts()
        {
            this.IsRefreshing = true;
            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    this.IsRefreshing = false;
            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error",
            //        connection.Message,
            //        "Accept");
            //    await Application.Current.MainPage.Navigation.PopAsync();
            //    return;
            //}

            //var response = await this.apiService.GetList<Product>(
            //    "http://restcountries.eu",
            //    "/rest",
            //    "/v2/all");

            //if (!response.IsSuccess)
            //{
            //    this.IsRefreshing = false;
            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error",
            //        response.Message,
            //        "Accept");
            //    await Application.Current.MainPage.Navigation.PopAsync();
            //    return;
            //}

            MainViewModel.GetInstance().ProductsList = (List<Product>)response.Result;
            this.Products = new ObservableCollection<ProductItemViewModel>(
                this.ToProductItemViewModel());
            this.IsRefreshing = false;
        }
        #endregion

        #region Methods
        private IEnumerable<ProductItemViewModel> ToProductItemViewModel()
        {
            return MainViewModel.GetInstance().ProductsList.Select(l => new ProductItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadProducts);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Products = new ObservableCollection<ProductItemViewModel>(
                    this.ToProductItemViewModel());
            }
            else
            {
                this.Products = new ObservableCollection<ProductItemViewModel>(
                    this.ToProductItemViewModel().Where(
                        l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}