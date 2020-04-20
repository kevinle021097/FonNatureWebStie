﻿using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IClientServices
{
    public interface IProductServices
    {
        List<Product> ListAll();
        Product GetDetail(long id);
        List<Product> ListByCategory(int idCategory);
        SEO GetProductSeo();
        string GetCategoryName(long categoryId);
        List<string> GetImagesList(long id);
        List<Product> GetRelatedProduct(Product product);
    }
}
