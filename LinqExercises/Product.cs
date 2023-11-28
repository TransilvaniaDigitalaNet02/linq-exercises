﻿namespace LinqExercises
{
    public class Product
    {
        public Product(int id, string name, int categoryId)
        {
            this.Id = id;
            this.Name = name;
            this.CategoryId = categoryId;
        }

        public int Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public int CategoryId
        {
            get;
        }
    }
}
