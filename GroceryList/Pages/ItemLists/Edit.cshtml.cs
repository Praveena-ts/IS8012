using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryList.Data;
using GroceryList.Models;

namespace GroceryList.Pages.ItemLists
{
    public class EditModel : PageModel
    {
        private readonly GroceryList.Data.GroceryListContext _context;

        public EditModel(GroceryList.Data.GroceryListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemList ItemList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemList = await _context.ItemList.FirstOrDefaultAsync(m => m.Id == id);

            if (ItemList == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ItemList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemListExists(ItemList.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ItemListExists(int id)
        {
            return _context.ItemList.Any(e => e.Id == id);
        }
    }
}
