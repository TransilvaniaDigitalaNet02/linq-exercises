namespace LinqExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonsDatabase.ReadFromXml("Persons.xml");

            /*
            var query = from category in ProductsDatabase.AllCategories()
                        join product in ProductsDatabase.AllProducts() on category.Id equals product.CategoryId into categoryGroup
                        select new
                        {
                            CategoryId = category.Id,
                            CategoryName = category.Name,
                            Products = categoryGroup
                        };
            
            */

            var query = ProductsDatabase.AllCategories()
                    .GroupJoin(
                        ProductsDatabase.AllProducts(),
                        category => category.Id,
                        product => product.CategoryId,
                        (category, categoryGroup) => new
                        {
                            CategoryId = category.Id,
                            CategoryName = category.Name,
                            Products = categoryGroup.DefaultIfEmpty(new Product(1, "N/A", category.Id))
                        });

            foreach (var fullCategoryDefinition in query)
            {
                Console.WriteLine($"{fullCategoryDefinition.CategoryName}");
                foreach (Product p in fullCategoryDefinition.Products)
                {
                    Console.WriteLine($"{p.Id} - {p.Name}");
                }
                
            }
        }
    }

    public class PersonWithIndex
    {
        public Person Person { get; set; }

        public int Index { get; set; }
    }
}