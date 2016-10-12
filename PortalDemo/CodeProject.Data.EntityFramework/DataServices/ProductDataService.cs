using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeProject.Interfaces;
using CodeProject.Business.Entities;
using CodeProject.Business.Common;
using System.Linq.Dynamic;

namespace CodeProject.Data.EntityFramework
{
    /// <summary>
    /// Account Data Service
    /// </summary>
    public class ProductDataService : EntityFrameworkService, IProductDataService
    {

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        public void CreateProduct(Product product)
        {
            dbConnection.Products.Add(product);
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Product GetProduct(int productID)
        {
            Product product = dbConnection.Products.Where(c => c.ProductID == productID).FirstOrDefault();
            return product;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="totalRows"></param>
        /// <returns></returns>
        public List<Product> GetProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out int totalRows)
        {
            totalRows = 0;
          
            sortExpression = sortExpression + " " + sortDirection;

            totalRows = dbConnection.Products.Count();
       
            List<Product> products = dbConnection.Products.OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                   
            return products;

        }


    }

}


