using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceryList.Models;

namespace GroceryList.Data
{
    public class GroceryListContext : DbContext
    {
        public GroceryListContext (DbContextOptions<GroceryListContext> options)
            : base(options)
        {
        }

        public DbSet<GroceryList.Models.ItemList> ItemList { get; set; }
    }
}
