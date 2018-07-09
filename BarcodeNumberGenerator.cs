using System.Linq;

namespace DhlBarcodeGenerator
{
    public class BarcodeNumberGenerator
    {
        private readonly ILuhn luhn;

        public BarcodeNumberGenerator(ILuhn luhn)
        {
            this.luhn = luhn;
        }

        public string GenerateBarcodeNumber(string postNumberInput)
        {
            long postNumber;
            if (!long.TryParse(postNumberInput, out postNumber))
            {
                throw new System.ArgumentException("Please enter a valid integer.");
            }

            var barcodeNumberWithoutCheck = (postNumber * 631).ToString();
            var luhnCheckDigit = this.luhn.GenerateLuhnCheckDigit(barcodeNumberWithoutCheck);
            var barcodeNumberWithCheck = string.Concat(barcodeNumberWithoutCheck, luhnCheckDigit);
            var length = barcodeNumberWithCheck.Length;
            var numberOfPlaceholderZeros = 16 - length - 1;
            var placeholderZeros = string.Concat(Enumerable.Repeat("0", numberOfPlaceholderZeros));
            var finalBarcodeNumber = $"3{placeholderZeros}{barcodeNumberWithCheck}";

            return finalBarcodeNumber;
        }
    }
}