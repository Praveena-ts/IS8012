using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList.Models
{
    public class ItemList
    {
        public int Id { get; set; }
        public DateTime? Billingdate { get; set; }
        public string ItemName { get; set; }

        public int Billamount { get; set; }
        public Boolean IsBillingComplete { get; set; }

    }
}
