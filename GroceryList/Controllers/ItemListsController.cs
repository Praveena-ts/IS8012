using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryList.Data;
using GroceryList.Models;

namespace GroceryList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemListsController : ControllerBase
    {
        private readonly GroceryListContext _context;

        public ItemListsController(GroceryListContext context)
        {
            _context = context;
        }

        // GET: api/ItemLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemList>>> GetItemList()
        {
            return await _context.ItemList.ToListAsync();
        }

        // GET: api/ItemLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemList>> GetItemList(int id)
        {
            var itemList = await _context.ItemList.FindAsync(id);

            if (itemList == null)
            {
                return NotFound();
            }

            return itemList;
        }

        // PUT: api/ItemLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemList(int id, ItemList itemList)
        {
            if (id != itemList.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItemLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemList>> PostItemList(ItemList itemList)
        {
            _context.ItemList.Add(itemList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemList", new { id = itemList.Id }, itemList);
        }

        // DELETE: api/ItemLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemList>> DeleteItemList(int id)
        {
            var itemList = await _context.ItemList.FindAsync(id);
            if (itemList == null)
            {
                return NotFound();
            }

            _context.ItemList.Remove(itemList);
            await _context.SaveChangesAsync();

            return itemList;
        }

        private bool ItemListExists(int id)
        {
            return _context.ItemList.Any(e => e.Id == id);
        }
    }
}
