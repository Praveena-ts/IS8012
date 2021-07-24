using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryList.Data;
using GroceryList.Models;

namespace GroceryList.Pages.ItemLists
{
    public class CreateModel : PageModel
    {
        private readonly GroceryList.Data.GroceryListContext _context;

        public CreateModel(GroceryList.Data.GroceryListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ItemList ItemList { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemList.Add(ItemList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
