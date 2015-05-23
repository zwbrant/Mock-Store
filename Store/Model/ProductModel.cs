using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class ProductModel
    {
        public int ProductID;
        public int InStock;
        public String Name;
        public double Price;
        public String Description;

        public double Relevance; // Used for fulltext searching.
	
    }
}
