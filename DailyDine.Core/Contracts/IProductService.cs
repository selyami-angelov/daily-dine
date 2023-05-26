﻿using DailyDine.Core.Dtos;

namespace DailyDine.Core.Contracts
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<ICollection<ProductDto>> GetAll();

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        Task Add(ProductDto productDto);

        /// <summary>
        /// Delete a product by its ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Task</returns>
        Task Delete(Guid id);
    }
}
