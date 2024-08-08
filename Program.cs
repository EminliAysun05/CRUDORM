using System;

namespace Practice2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AppDbContext db = new AppDbContext();
            ProductService productService = new ProductService();
            CategoryService categoryService = new CategoryService();
            
            //create new category
            Category newCategory = new Category { Name = "Electornics" };
            await categoryService.CreateCategory(newCategory);
            Console.WriteLine($"category {newCategory.Name} created with Id: {newCategory.Id} ");
            await db.SaveChangesAsync();


            //all categories

            List<Category> categories = await categoryService.GettAllAsync();
            await Console.Out.WriteLineAsync("All categories: ");
            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.Name},{category.Id}");
            }

            //get categories by id

            Category category1 = await categoryService.GetById(3);
           
            //yeni product

            Product newProduct  = new Product { Name = "Laptop", CategoryId = category1.Id };   
            await productService.CreateProduct(newProduct);
            Console.WriteLine($"{newProduct.Name} created");

            //all products
            List<Product> products = await productService.GetAllProduct();
            Console.WriteLine("All products: ");
            foreach(Product product in products)
            {
                Console.WriteLine($"{product.Name},{product.Id}");
            }

           

        }
    }
}
