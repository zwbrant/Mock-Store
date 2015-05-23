using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class AddWindowLineItemViewModel
    {
        public int Quantity { get; set; }
        public MainWindowProductViewModel SelectedProduct { get; set; }
    }
}
