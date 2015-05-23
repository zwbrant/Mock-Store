using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Store
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
            : base()
        {
            PendingOrders = new ObservableCollection<MainWindowOrderViewModel>();
            PendingOrderLineItems = new ObservableCollection<MainWindowLineItemViewModel>();
            Products = new ObservableCollection<MainWindowProductViewModel>();
            Customers = new ObservableCollection<MainWindowCustomerViewModel>();
            HighlightedProductComments = new ObservableCollection<string>();
        }

        public ObservableCollection<MainWindowOrderViewModel> PendingOrders { get; private set; }
        public ObservableCollection<MainWindowLineItemViewModel> PendingOrderLineItems { get; private set; }
        public ObservableCollection<MainWindowProductViewModel> Products { get; private set; }
        public ObservableCollection<MainWindowCustomerViewModel> Customers { get; private set; }
        public ObservableCollection<string> HighlightedProductComments { get; private set; }

        public MainWindowCustomerViewModel SelectedCustomer
        {
            get { return internalSelectedCustomer; }
            set { internalSelectedCustomer = value; OnPropertyChanged("SelectedCustomer"); }
        }
				
        public MainWindowProductViewModel SelectedProduct
        {
            get { return internalSelectedProduct; }
            set { internalSelectedProduct = value; OnPropertyChanged("SelectedProduct"); }
        }			

        public MainWindowOrderViewModel SelectedPendingItem
        {
            get { return internalSelectedPendingItem; }
            set { internalSelectedPendingItem = value; OnPropertyChanged("SelectedPendingItem"); }
        }

        public MainWindowLineItemViewModel SelectedLineItem
        {
            get { return internalSelectedLineItem; }
            set { internalSelectedLineItem = value; OnPropertyChanged("SelectedLineItem"); }
        }

        public string ReviewSearchText
        {
            get { return internalReviewSearchText; }
            set { internalReviewSearchText = value; OnPropertyChanged("ReviewSearchText"); }
        }

        public MainWindowProductViewModel HighlightedProduct
        {
            get { return internalHighlightedProduct; }
            set { internalHighlightedProduct = value; OnPropertyChanged("HighlightedProduct"); }
        }

        public bool IsPopupOpen
        {
            get { return internalIsPopupOpen; }
            set { internalIsPopupOpen = value; OnPropertyChanged("IsPopupOpen"); }
        }


        private bool internalIsPopupOpen;
        private MainWindowProductViewModel internalHighlightedProduct;
        private MainWindowCustomerViewModel internalSelectedCustomer;
        private MainWindowProductViewModel internalSelectedProduct;
        private string internalReviewSearchText;				
        private MainWindowLineItemViewModel internalSelectedLineItem;			
        private MainWindowOrderViewModel internalSelectedPendingItem;
				
    }
}
