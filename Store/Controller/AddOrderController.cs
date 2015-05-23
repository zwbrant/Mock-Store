using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class AddOrderController : IController
    {
        public AddOrderController(AddOrderViewModel viewModel, AppController appController)
        {
            ViewModel = viewModel;
            this.appController = appController;
            InitializeCustomerList();
            InitializeProductList();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ViewModel.Commands.AddCommand("AddProduct", AddProductCommandExecuted);
            ViewModel.Commands.AddCommand("CreateOrder", CreateOrderCommandExecuted);
        }

        private void InitializeProductList()
        {
            List<ProductModel> products = appController.DataAccess.GetProducts();
            foreach (var product in products)
                ViewModel.Products.Add(new MainWindowProductViewModel() { Product = product });
        }

        private void InitializeCustomerList()
        {
            var customers = appController.DataAccess.GetCustomers();
            foreach (var customer in customers)
            {
                ViewModel.Customers.Add(new MainWindowCustomerViewModel() { Customer = customer, Name = customer.Name });
            }
        }

        private void AddProductCommandExecuted(object param)
        {
            ViewModel.LineItems.Add(new AddWindowLineItemViewModel() { Quantity = 1 });
        }

        private void CreateOrderCommandExecuted(object param)
        {
            if (ViewModel.SelectedCustomer != null)
            {
                List<LineItemModel> lineItems = new List<LineItemModel>();
                foreach (var lineItemVM in ViewModel.LineItems)
                {
                    if (lineItemVM.SelectedProduct != null && lineItemVM.Quantity > 0)
                    {
                        lineItems.Add(new LineItemModel()
                        {
                            Product = lineItemVM.SelectedProduct.Product,
                            Quantity = lineItemVM.Quantity,
                            PricePaid = lineItemVM.Quantity * lineItemVM.SelectedProduct.Product.Price
                        });
                    }
                }
                appController.DataAccess.MakeOrder(ViewModel.SelectedCustomer.Customer, lineItems);
                appController.CloseWindow(this);
            }
        }

        private AppController appController { get; set; }
        public AddOrderViewModel ViewModel { get; private set; }
    }
}
