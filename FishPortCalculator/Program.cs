using FishPortCalculator;
using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        List<Purchase> purchases = new List<Purchase>();
        Console.Write("Vendor Name: ");
        string vendorName = Console.ReadLine();

        while (true)
        {
            Console.Write("Product Name (or 'exit' to finish): ");
            string productName = Console.ReadLine();

            if (string.Equals(productName, "exit", StringComparison.OrdinalIgnoreCase))
                break;

            double totalAmount = 0;
            double totalKilograms = 0;
            StringBuilder inputDetails = new StringBuilder();

            while (true)
            {
                Console.Write("Timbang: ");
                if (!double.TryParse(Console.ReadLine(), out double kilograms))
                    break;

                Console.Write("Price: ");
                if (!double.TryParse(Console.ReadLine(), out double pricePerKilo))
                    break;

                double amount = kilograms * pricePerKilo;
                totalAmount += amount;
                totalKilograms += kilograms;

                // Append the input details to a StringBuilder
                inputDetails.AppendLine($"Timbang: {kilograms} | Price: {pricePerKilo} | Amount: {amount}");
            }

            purchases.Add(new Purchase
            {
                VendorName = vendorName,
                ProductName = productName,
                TotalAmount = totalAmount,
                TotalKilograms = totalKilograms,
                InputDetails = inputDetails.ToString()
            });
        }

        Console.WriteLine("\nPurchase Summary:");
        double OverallAmount = 0;
        foreach (var purchase in purchases)
        {
            Console.WriteLine($"Vendor Name: {purchase.VendorName}");
            Console.WriteLine($"Product Name: {purchase.ProductName}");
            Console.WriteLine("Input Details:");
            Console.WriteLine(purchase.InputDetails);
            Console.WriteLine($"Total Kilograms: {purchase.TotalKilograms}");
            Console.WriteLine($"Total Amount: {purchase.TotalAmount}");
            Console.WriteLine("\n");
            Console.WriteLine("**********************************************");
        }

        foreach (var purchase in purchases) 
        {
            OverallAmount += purchase.TotalAmount;
        }

        Console.WriteLine($"Overall Total: {OverallAmount}");

    }
}

