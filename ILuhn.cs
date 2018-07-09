namespace DhlBarcodeGenerator
{
    public interface ILuhn
    {
        string GenerateLuhnCheckDigit(string number);
        bool CheckLuhnNumber(string data);
    }
}