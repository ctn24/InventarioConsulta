using System;
using System.Collections.Generic;
using System.Text;

namespace InventarioConsulta.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class ProductItemViewModel : Product
    {
        #region Commands
        public ICommand SelectProductCommand
        {
            get
            {
                return new RelayCommand(SelectProduct);
            }
        }

        private async void SelectProduct()
        {
            MainViewModel.GetInstance().Product = new ProductViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
        #endregion
    }
}
