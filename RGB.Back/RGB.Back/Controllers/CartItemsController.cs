﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RGB.Back.Models;

namespace RGB.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly RizzContext _context;

        public CartItemsController(RizzContext context)
        {
            _context = context;
        }


        // GET: api/CartItems/5
        [HttpGet("{MemberId}")]
        public async Task<List<CartItem>> GetCartItem(int memberId)
        {
            var cartItem = await _context.CartItems.AsNoTracking().Where(x=> x.MemberId == memberId).ToListAsync();
            return cartItem;
        }

        // POST: api/CartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task DeleteCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

        }

		// DELETE: api/CartItems/5
		[HttpDelete("delete/{memberId}")]
		public async Task DeleteAllCartItem(int memberId)
		{
			var cartItems = await _context.CartItems.Where(x=> x.MemberId == memberId).ToListAsync();
			foreach (var cartItem in cartItems)
				_context.CartItems.Remove(cartItem);
			await _context.SaveChangesAsync();

		}

		private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
