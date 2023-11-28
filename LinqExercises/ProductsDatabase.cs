﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercises
{
    public static class ProductsDatabase
    {
        private static Func<int> Increment()
        {
            int id = 0;
            return () => ++id;
        }

        private static Func<int> NewId = Increment();

        public static IEnumerable<Category> AllCategories()
        {
            yield return new Category(1, "Laptopuri");
            yield return new Category(2, "Telefoane");
            yield return new Category(3, "Tablete");

            // category without products
            yield return new Category(20, "Imbracaminte");
        }

        public static IEnumerable<Product> AllProducts()
        {
            // Laptopuri
            yield return new Product(NewId(), "Lenovo IdeaPad", 1);
            yield return new Product(NewId(), "HP Envy", 1);
            yield return new Product(NewId(), "Dell Latitude", 1);

            // Telefoane
            yield return new Product(NewId(), "Samsung Galaxy Phone", 2);
            yield return new Product(NewId(), "Huawei Phone", 2);
            yield return new Product(NewId(), "Xiaomi Phone", 2);
            yield return new Product(NewId(), "Nokia Phone", 2);
            yield return new Product(NewId(), "iPhone", 2);

            // Tablete
            yield return new Product(NewId(), "Samsung Galaxy Tab", 3);
            yield return new Product(NewId(), "Huawei Tablet", 3);
            yield return new Product(NewId(), "Lenovo Tablet", 3);
            yield return new Product(NewId(), "iPad", 3);

            // Product without category
            yield return new Product(NewId(), "Frigider", 100);
        }
    }
}
