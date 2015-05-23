using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class MainWindowController : IController
    { 
        public MainWindowController(MainWindowViewModel viewModel, AppController appController)
        {
            ViewModel = viewModel;
            ViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ViewModel_PropertyChanged);
            AppController = appController;
            InitializeCustomerList();
            InitializePendingOrders();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ViewModel.Commands.AddCommand("AddOrder", AddOrderCommandExecuted);
            ViewModel.Commands.AddCommand("ViewProduct", ViewProductCommandExecuted);
            ViewModel.Commands.AddCommand("FindReviewedProducts", FindReviewedProductsCommandExecuted);
            ViewModel.Commands.AddCommand("ClosePopup", ClosePopupCommandExecuted);
        }

        private void ClosePopupCommandExecuted(object param)
        {
            ViewModel.IsPopupOpen = false;
        }

        private void AddOrderCommandExecuted(object param)
        {
            AppController.ShowAddOrder();
        }

        private void ViewProductCommandExecuted(object param)
        {
            ProductModel product = null;
            if (param is MainWindowLineItemViewModel)
                product = ((MainWindowLineItemViewModel)param).LineItem.Product ;

            if (param is MainWindowProductViewModel)
                product = ((MainWindowProductViewModel)param).Product;

            if (product != null)
            {
                ViewModel.HighlightedProduct = new MainWindowProductViewModel() { Product = product };
                ViewModel.HighlightedProductComments.Clear();
                List<string> comments = AppController.DataAccess.GetUserComments(product);
                foreach (string comment in comments)
                    ViewModel.HighlightedProductComments.Add(comment);
                ViewModel.IsPopupOpen = true;
            }
        }

        private void FindReviewedProductsCommandExecuted(object param)
        {
            List<ProductModel> products = AppController.DataAccess.SearchProductReviews(ViewModel.ReviewSearchText);
            ViewModel.Products.Clear();
            foreach (var product in products)
            {
                ViewModel.Products.Add(new MainWindowProductViewModel() { Product = product });
            }
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedPendingItem": UpdateLineItemList(); break;
                case "SelectedCustomer": FilterListToSelectedCustomer(); break;
            }
        }

        private void FilterListToSelectedCustomer()
        {
            if (ViewModel.SelectedCustomer != null && ViewModel.SelectedCustomer.Customer != null)
            {
                ViewModel.PendingOrders.Clear();
                ViewModel.PendingOrderLineItems.Clear();
                List<OrderModel> orders = AppController.DataAccess.GetOrdersForCustomer(ViewModel.SelectedCustomer.Customer);
                foreach (OrderModel order in orders)
                    ViewModel.PendingOrders.Add(new MainWindowOrderViewModel() { Order = order });
            }
            else
            {
                InitializePendingOrders();
            }
        }

        private void UpdateLineItemList()
        {
            ViewModel.PendingOrderLineItems.Clear();
            if (ViewModel.SelectedPendingItem != null)
            {
                List<LineItemModel> lineItems = AppController.DataAccess.GetLineItemsForOrder(ViewModel.SelectedPendingItem.Order);
                foreach (LineItemModel lineItem in lineItems)
                {
                    ViewModel.PendingOrderLineItems.Add(new MainWindowLineItemViewModel() { LineItem = lineItem });
                }
            }
        }

        private void InitializePendingOrders()
        {
            ViewModel.PendingOrders.Clear();
            List<OrderModel> orders = AppController.DataAccess.GetPendingOrders();
            foreach (OrderModel order in orders)
            {
                ViewModel.PendingOrders.Add(new MainWindowOrderViewModel() { Order = order });
            }
        }

        private void InitializeCustomerList()
        {
            ViewModel.Customers.Add(new MainWindowCustomerViewModel() { Name = "All Customers" });
            ViewModel.SelectedCustomer = ViewModel.Customers.First();

            List<CustomerModel> customers = AppController.DataAccess.GetCustomers();
            foreach (CustomerModel customer in customers)
            {
                ViewModel.Customers.Add(new MainWindowCustomerViewModel() { Customer = customer, Name = customer.Name });
            }
        }

        public AppController AppController { get; private set; }
        public MainWindowViewModel ViewModel { get; private set; }
    }
}
