using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class MainWindowOrderViewModel : BaseViewModel
    {
        public OrderModel Order { get; set; }

        public string Date
        {
            get
            {
                if (Order != null)
                    return Order.OrderDate.ToShortDateString();
                return "Unknown";
            }
        }

        public string Customer
        {
            get
            {
                if (Order != null && Order.Customer != null)
                    return Order.Customer.Name;
                return "Unknown";
            }
        }

        public string Status
        {
            get
            {
                if (Order != null)
                    return Order.Status;
                return "Unknown";
            }
        }

        public string Total
        {
            get
            {
                if (Order != null)
                    return Order.TotalCost.ToString("C");
                return "Unknown";
            }
        }

        public string ShipTo
        {
            get
            {
                if (Order != null)
                    return Order.ShippingAddress;
                return "Unknown";
            }
        }
    }
}
