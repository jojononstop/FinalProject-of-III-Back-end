﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RGB.Back.DTOs;
using RGB.Back.Models;
using RGB.Back.Service;

namespace RGB.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly RizzContext _context;
		private readonly GameService _service;

		public CommentsController(RizzContext context)
        {
            _context = context;
			_service = new GameService(context);
		}

        // GET: api/Comments
        //[HttpGet]
        //public async Task<IEnumerable<Comment>> GetComments()
        //{
        //    return await _context.Comments.ToListAsync();
        //}

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<CommentDTO>> GetComment(int id)
        {
            return _service.GetComments(id);
		}

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutComment(int id, Comment comment)
        {         
            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return "修改失敗";
                }
                else
                {
                    throw;
                }
            }

            return "修改成功";
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Comment> PostComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return "刪除失敗";
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return "刪除成功";
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
