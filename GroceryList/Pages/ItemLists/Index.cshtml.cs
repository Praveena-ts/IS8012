using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryList.Data;
using GroceryList.Models;

namespace GroceryList.Pages.ItemLists
{
    public class IndexModel : PageModel
    {
        private readonly GroceryList.Data.GroceryListContext _context;

        public IndexModel(GroceryList.Data.GroceryListContext context)
        {
            _context = context;
        }

        public IList<ItemList> ItemList { get;set; }

        public async Task OnGetAsync()
        {
            ItemList = await _context.ItemList.ToListAsync();
        }
    }
}
