using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Store
{
    public class AddOrderViewModel : BaseViewModel
    {
        public AddOrderViewModel()
            : base()
        {
            Customers = new ObservableCollection<MainWindowCustomerViewModel>();
            Products = new ObservableCollection<MainWindowProductViewModel>();
            LineItems = new ObservableCollection<AddWindowLineItemViewModel>();
        }

        public ObservableCollection<MainWindowCustomerViewModel> Customers { get; private set; }
        public ObservableCollection<MainWindowProductViewModel> Products { get; private set; }
        public ObservableCollection<AddWindowLineItemViewModel> LineItems { get; private set; }

        public MainWindowCustomerViewModel SelectedCustomer
        {
            get { return internalSelectedCustomer; }
            set { internalSelectedCustomer = value; OnPropertyChanged("SelectedCustomer"); }
        }

        private MainWindowCustomerViewModel internalSelectedCustomer;
				
    }
}
