using Market_is_Back;
using System.ComponentModel.DataAnnotations;
using System.Text;

List<Product> products = new List<Product>
{
    new Product { Location = 1, Producer = "Bornand", ProductName = "Pommes", Quantity = 20,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 1, Producer = "Bornand", ProductName = "Poires", Quantity = 16,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 1, Producer = "Bornand", ProductName = "Pastèques", Quantity = 14,Unit = "pièce", PricePerUnit = 5.50 },
    new Product { Location = 1, Producer = "Bornand", ProductName = "Melons", Quantity = 5,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Noix", Quantity = 20,Unit = "sac", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Raisin", Quantity = 6,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Pruneaux", Quantity = 13,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Myrtilles", Quantity = 12,Unit = "kg", PricePerUnit = 5.50 },

};

var i18n = new Dictionary<string, string>()
{
    { "Pommes","Apples"},
    { "Poires","Pears"},
    { "Pastèques","Watermelons"},
    { "Melons","Melons"},
    { "Noix","Nuts"},
    { "Raisin","Grapes"},    { "Pruneaux","Plums"},
    { "Myrtilles","Blueberries"},
    { "Groseilles","Berries"},
    { "Tomates","Tomatoes"},
    { "Courges","Pumpkins"},
    { "Pêches","Peaches"},
    { "Haricots","Beans"}
};

var produits = products
    .Select(x => (x.Producer
    .Substring(0, 3) + "..." + x.Producer[x.Producer.Length - 1],
    i18n[x.ProductName],
    x.Quantity * x.PricePerUnit))
    .ToList();
produits.ForEach(x => Console.WriteLine("Producer : " + x.Item1 + "| Name : " + x.Item2 + "| CA : " + x.Item3));



//ChatGPT
string filePath = "produits.csv";

using (var writer = new StreamWriter(filePath))
{
    // Entêtes séparées par ";"
    writer.WriteLine("Producer;Product;CA");

    // Lignes de données
    foreach (var p in produits)
    {
        string line = $"\"{p.Item1}\";\"{p.Item2}\";{p.Item3}";
        writer.WriteLine(line);
    }
}

Console.WriteLine($"Export terminé vers {filePath}");