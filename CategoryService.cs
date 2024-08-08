using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class CategoryService
    {
        public async Task CreateCategory(Category category)
        {
            AppDbContext appDbContext = new AppDbContext();
            await appDbContext.AddAsync(category);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GettAllAsync()
        {
            AppDbContext appDbContext = new AppDbContext();
            var categories = await appDbContext.categories.AsNoTracking().ToListAsync();
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            AppDbContext appDbContext = new AppDbContext();
            var categories = await appDbContext.categories.FirstOrDefaultAsync(p => p.Id == id);
            if (categories == null)
            {
                throw new Exception($"This{id} not found...");
            }
            return categories;
        }

        public async Task UpdateCategory(Category category)
        {
            AppDbContext appDbContext = new AppDbContext();
            appDbContext.Update(category);
             await appDbContext.SaveChangesAsync();

        }
    }
}
