using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class MainWindowProductViewModel
    {
        public ProductModel Product { get; set; }

        public string Relevance
        {
            get
            {
                return Product != null ? Product.Relevance.ToString() : "0";
            }
        }

        public string Name
        {
            get
            {
                return Product != null ? Product.Name : "Unknown";
            }
        }

        public string Description
        {
            get
            {
                return Product != null ? Product.Description : "Unknown";
            }
        }

        public string InStock
        {
            get
            {
                return Product != null ? Product.InStock.ToString() : "Unknown";
            }
        }

        public string Price
        {
            get
            {
                return Product != null ? Product.Price.ToString("C"): "Unknown";
            }
        }
    }
}
