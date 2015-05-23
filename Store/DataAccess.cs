using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Store
{
    public class DataAccess
    {
        internal List<OrderModel> GetPendingOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();

            // TODO: Query the database to get all the orders that are pending, but no need to get line item info.

            // Remove the following lines in your final version, for testing only.
            orders.Add(new OrderModel()
            {
                OrderID = 1,
                OrderDate = DateTime.Now,
                BillingAddress = "123 Main St",
                BillingInfo = "Cash",
                Customer = new CustomerModel() { CustomerID = 1, Name = "Bob", Email = "Bob@Imcool.com" },
                ShippingAddress = "123 Main St",
                TotalCost = 1000,
                Status = "NEW"
            });

            orders.Add(new OrderModel()
            {
                OrderID = 2,
                OrderDate = DateTime.Now,
                BillingAddress = "123 Main St",
                BillingInfo = "Check",
                Customer = new CustomerModel() { CustomerID = 2, Name = "Kevin", Email = "kfleming@uw.edu" },
                ShippingAddress = "123 Main St",
                TotalCost = 100,
                Status = "SHIPPED"
            });

            return orders;  
        }

        internal List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();

            // TODO: Query the database to get all the products.

            // Remove the following lines in your final version, for testing only.

            products.Add(new ProductModel()
            {
                ProductID = 1,
                Name = "Sweet Candy",
                Description = "The best candy ever!",
                InStock = 10,
                Price = 5,
                Relevance = 0
            });

            products.Add(new ProductModel()
            {
                ProductID = 2,
                Name = "Sour Candy",
                Description = "Definitely not the sweetest.",
                InStock = 40,
                Price = 2,
                Relevance = 0
            });

            return products;
        }

        internal List<CustomerModel> GetCustomers()
        {

            List<CustomerModel> customers = new List<CustomerModel>();

            // TODO:  Query the database to get all the customers.
            // Remove the following lines in your final version, it is for testing only.
            customers.Add(new CustomerModel() { CustomerID = 1, Name = "Bob", Email = "Bob@Imcool.com" });
            customers.Add(new CustomerModel() { CustomerID = 2, Name = "Kevin", Email = "kfleming@uw.edu" });

            return customers;
        }

        internal List<LineItemModel> GetLineItemsForOrder(OrderModel orderModel)
        {
            List<LineItemModel> lineItems = new List<LineItemModel>();
            // TODO: Query the database for the line items for the given order.

            // Remove the following lines in your final version, it is for testing only.
            lineItems.Add(new LineItemModel()
            {
                Quantity = 2,
                PricePaid = 10,
                Product =
                    new ProductModel()
                    {
                        ProductID = 1,
                        Name = "Sweet Candy",
                        Description = "The best candy ever!",
                        InStock = 10,
                        Price = 5,
                        Relevance = 0
                    }
            });

            return lineItems;
        }

        internal List<string> GetUserComments(ProductModel product)
        {

            List<string> comments = new List<string>();

            // TODO: Query the database to get the comments for a product

            // Remove the following lines in your final version, it is for testing only.

            comments.Add("A sweet candy item");
            comments.Add("I love this candy!");

            return comments;
        }

        internal List<OrderModel> GetOrdersForCustomer(CustomerModel customer)
        {
            List<OrderModel> orders = new List<OrderModel>();

            // TODO: Query the database to find all the orders for a given customer

            // Remove the following lines in your final version, it is for testing only.

            if (customer.CustomerID == 1)
            {
                orders.Add(new OrderModel()
                {
                    OrderID = 1,
                    OrderDate = DateTime.Now,
                    BillingAddress = "123 Main St",
                    BillingInfo = "Cash",
                    Customer = new CustomerModel() { CustomerID = 1, Name = "Bob", Email = "Bob@Imcool.com" },
                    ShippingAddress = "123 Main St",
                    TotalCost = 1000,
                    Status = "NEW"
                });
            }

            if (customer.CustomerID == 2)
            {
                orders.Add(new OrderModel()
                {
                    OrderID = 2,
                    OrderDate = DateTime.Now,
                    BillingAddress = "123 Main St",
                    BillingInfo = "Check",
                    Customer = new CustomerModel() { CustomerID = 2, Name = "Kevin", Email = "kfleming@uw.edu" },
                    ShippingAddress = "123 Main St",
                    TotalCost = 100,
                    Status = "SHIPPED"
                });
            }

            return orders;
        }

        internal List<ProductModel> SearchProductReviews(string query)
        {
            List<ProductModel> products = new List<ProductModel>();
            // TODO: Query the database using FULLTEXT searching to find products that best match the item.  The list
            // needs to be sorted most relavant first.

            // Remove the following lines in your final version, for testing only.

            products.Add(new ProductModel()
            {
                ProductID = 1,
                Name = "Sweet Candy",
                Description = "The best candy ever!",
                InStock = 10,
                Price = 5,
                Relevance = 0.8
            });

            products.Add(new ProductModel()
            {
                ProductID = 2,
                Name = "Sour Candy",
                Description = "Definitely not the sweetest.",
                InStock = 40,
                Price = 2,
                Relevance = 0.6
            });


            return products;
        }

        internal void MakeOrder(CustomerModel customer, List<LineItemModel> lineItems)
        {
            // TODO: Create the order and line items in the database.  

            MessageBox.Show("Create an order for " + customer.Name + " with the " + lineItems.Count + " line items.");

        }

    }
}
