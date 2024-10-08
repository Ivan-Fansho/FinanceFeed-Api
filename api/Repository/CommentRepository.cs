using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;

        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentkModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (commentkModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentkModel);
            await _context.SaveChangesAsync();
            return commentkModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
             return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existComment = await _context.Comments.FindAsync(id);
            if (existComment == null)
            {
                return null;
            }

            existComment.Title = commentModel.Title;
            existComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            return existComment;

        }
    }
}