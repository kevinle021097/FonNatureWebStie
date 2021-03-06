﻿using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IProductAdminRepository
    {
        Product GetDetail(long id);
        List<Product> GetListProduct();
        bool? ChangeStatus(long id);
        long AddProduct(Product product);
        bool EditProduct(Product product);
        bool Delete(long id);
        List<Product> ListSearchProduct(string searchString);
        List<ProductCategory> GetProductCategories();
        bool CheckExits(string name);
        bool SaveImages(string images, long id);
        string GetImagesList(long id);
    }
}
