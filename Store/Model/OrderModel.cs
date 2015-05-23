using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class OrderModel
    {
        public int OrderID;
        public DateTime OrderDate;
        public String Status;
        public CustomerModel Customer;

        public double TotalCost;

        public String ShippingAddress;
        public String BillingAddress;
        public String BillingInfo; 		// Like Credit Card #, etc...	
	
    }
}
