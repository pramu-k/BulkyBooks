using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Product productObj)
        {
            var productFromDb = _dbContext.Products.FirstOrDefault(u=>u.Id==productObj.Id);
            if (productFromDb != null)
            {
                productFromDb.Title = productObj.Title;
                productFromDb.ISBN = productObj.ISBN;
                productFromDb.Author = productObj.Author;
                productFromDb.Price = productObj.Price;
                productFromDb.ListPrice = productObj.ListPrice;
                productFromDb.Price50= productObj.Price50;
                productFromDb.Price100= productObj.Price100;
                productFromDb.Description = productObj.Description;
                productFromDb.CategoryId = productObj.CategoryId;
                if (productFromDb.ImageUrl!=null)
                {
                    productFromDb.ImageUrl = productObj.ImageUrl;
                }

            }
        }
    }
}
