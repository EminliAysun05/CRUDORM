using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class ProductService
    {

        public async Task CreateProduct(Product product)
        {
            AppDbContext appContext = new AppDbContext();
            await appContext.Products.AddAsync(product);
            await appContext.SaveChangesAsync();    
        }

        public async Task<List<Product>> GetAllProduct()
        {
            AppDbContext appContext = new AppDbContext();
          var products =  await appContext.Products.Include(p => p.Category).AsNoTracking().ToListAsync();
            return products;

        }
        public async Task<Product> GetByIdProduct(int id)
        {
            AppDbContext appContext = new AppDbContext();
            var products = await appContext.Products.FirstOrDefaultAsync(p => p.Id ==id);
            if(products == null)
            {
                throw new Exception($"This{id} not found...");
            }
            return products;
        }

        public async Task DeleteProduct(int id)
        {
            AppDbContext appContext = new AppDbContext();

            var products = await appContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(products == null )
            {
                throw new Exception($"Not found {id} for removing...");
            }
            appContext.Products.Remove(products);
            await appContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            AppDbContext appDbContext = new AppDbContext();
            // appDbContext.Update(product);
            //await appDbContext.SaveChangesAsync();

            var existProduct = await GetByIdProduct(product.Id);

            var IsExist  = await appDbContext.Products.AnyAsync(x =>x.Name.ToLower() == product.Name.ToLower());
            if (IsExist)
            {
                Console.WriteLine("This procut is already exist");
                return;
            }
            existProduct.Name = product.Name;
            existProduct.CategoryId = product.CategoryId;
            existProduct.Category = product.Category;
            
        }



        
    }
}
