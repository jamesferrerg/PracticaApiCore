using System;
using System.Collections.Generic;

namespace PracticaApi.EFModels
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
