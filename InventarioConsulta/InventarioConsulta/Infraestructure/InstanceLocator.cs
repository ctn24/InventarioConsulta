
namespace InventarioConsulta.Infraestructure
{
    using InventarioConsulta.ViewModels;

    class InstanceLocator
    {
        #region Properties
        public MainViewModel Main
        {
            get;
            set;
        } 
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        } 
        #endregion
    }
}
