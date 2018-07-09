using System;

namespace DhlBarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter you Post Number");
            var input = Console.ReadLine();
            var barcodeNumberGenerator = new BarcodeNumberGenerator(new Luhn());
            var barcodeNumber = barcodeNumberGenerator.GenerateBarcodeNumber(input);
            Console.WriteLine("Your barcode number is:");
            Console.WriteLine(barcodeNumber);
            Console.ReadLine();
        }
    }
}
