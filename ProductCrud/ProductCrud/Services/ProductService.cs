using ProductCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace ProductCrud.Services
{
    public class ProductService
    {
        private DatabaseContext getContext()
        {
            return new DatabaseContext();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Products.ToListAsync();
            return res;
        }

        public async Task<int> UpdateProduct(Product obj)
        {
            var _dbContext = getContext();
            _dbContext.Products.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int InsertProduct(Product obj)
        {
            var _dbContext = getContext();
            _dbContext.Products.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeleteProduct(Product obj)
        {

            var _dbContext = getContext();
            _dbContext.Products.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}