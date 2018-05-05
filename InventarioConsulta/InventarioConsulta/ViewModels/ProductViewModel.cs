namespace InventarioConsulta.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Models;

    public class ProductViewModel: BaseViewModel
    {
        //#region Attributes
        //private ObservableCollection<Border> borders;
        //private ObservableCollection<Currency> currencies;
        //private ObservableCollection<Language> languages;
        //#endregion

        #region Propperties
        public Product Product
        {
            get;
            set;
        }

        //public ObservableCollection<Border> Borders
        //{
        //    get { return this.borders; }
        //    set { this.SetValue(ref this.borders, value); }
        //}

        //public ObservableCollection<Currency> Currencies
        //{
        //    get { return this.currencies; }
        //    set { this.SetValue(ref this.currencies, value); }
        //}

        //public ObservableCollection<Language> Languages
        //{
        //    get { return this.languages; }
        //    set { this.SetValue(ref this.languages, value); }
        //}
        #endregion

        #region Constructors
        public ProductViewModel(Product product)
        {
            this.Product = product;
            //this.Currencies = new ObservableCollection<Currency>(this.Product.Currencies);
            //this.Languages = new ObservableCollection<Language>(this.Product.Languages);
        }
        #endregion

    }
}
