using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class MainWindowLineItemViewModel
    {
        public LineItemModel LineItem { get; set; }

        public string Name
        {
            get
            {
                return LineItem != null && LineItem.Product != null ? LineItem.Product.Name : "Unknown";
            }
        }

        public string Quantity
        {
            get
            {
                return LineItem != null ? LineItem.Quantity.ToString() : "Unknown";
            }
        }

        public string PricePaid
        {
            get
            {
                return LineItem != null ? LineItem.PricePaid.ToString("C") : "Unknown";
            }
        }

        public string Description
        {
            get
            {
                return LineItem != null && LineItem.Product != null ? LineItem.Product.Description : "Unknown";
            }
        }
    }
}
