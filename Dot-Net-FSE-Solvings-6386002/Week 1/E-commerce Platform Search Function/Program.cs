using System;

class Product
{
    public int productId;
    public string productName;
    public string category;

    public Product(int id, string name, string cat)
    {
        productId = id;
        productName = name;
        category = cat;
    }
}

class Program
{
    static void Main()
    {
        Product[] products = {
            new Product(1, "Phone", "Electronics"),
            new Product(2, "Shirt", "Clothing"),
            new Product(3, "Watch", "Accessories")
        };

        var linearResult = LinearSearch(products, "Phone");
        if (linearResult != null)
            Console.WriteLine(linearResult.productName);
        else
            Console.WriteLine("Not found");

        Array.Sort(products, (a, b) => a.productName.CompareTo(b.productName));
        var binaryResult = BinarySearch(products, "Phone");
        if (binaryResult != null)
            Console.WriteLine(binaryResult.productName);
        else
            Console.WriteLine("Not found");
    }

    static Product LinearSearch(Product[] arr, string name)
    {
        foreach (var p in arr)
            if (p.productName == name)
                return p;
        return null;
    }

    static Product BinarySearch(Product[] arr, string name)
    {
        int l = 0, r = arr.Length - 1;
        while (l <= r)
        {
            int m = (l + r) / 2;
            int cmp = string.Compare(arr[m].productName, name, true);
            if (cmp == 0) return arr[m];
            if (cmp < 0) l = m + 1;
            else r = m - 1;
        }
        return null;
    }
}
