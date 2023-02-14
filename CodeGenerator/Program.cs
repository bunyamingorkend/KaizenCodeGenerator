// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

//Kodun üretileceği karakterler
const string Characters = "ACDEFGHKLMNPRTXYZ234579";

//Geçerliliğinin kontrol edilmesi için regex
const string Pattern = "^[ACDEFGHKLMNPRTXYZ234579]+$";

//Üretilecek kodun uzunluğu
const int size = 8;

while (true)
{
    var code = CodeGenerator();
    if (CodeValidation(code))
    {
        Console.WriteLine(code);
    }
    else
    {
        Console.WriteLine("Code Is Not Valid");
        return;
    }
}



string CodeGenerator()
{
    //Kodun üretileceği karakterler için liste
    char[] chars = new char[23];

    chars = Characters.ToCharArray();

    byte[] data = new byte[size];
  
    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

    //Random sayılar oluşturulur
    crypto.GetNonZeroBytes(data);

    StringBuilder result = new StringBuilder(size);

    foreach (byte b in data)
    {
        //Oluşturulan random sayıların modu alınarak chars dizisinden eleman seçilir
        result.Append(chars[b % (chars.Length)]);
    }
    return result.ToString();

}

bool CodeValidation(string code)
{
    //Üretilen kodun regex ile eşleşmesi kontrol edilir.
    if (Regex.IsMatch(code, Pattern))
    {
        return true;
    }
    else
    {
        return false;
    }

}
