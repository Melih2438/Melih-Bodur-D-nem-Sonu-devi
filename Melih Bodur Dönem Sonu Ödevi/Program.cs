internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
        int ogrenciSayisi = int.Parse(Console.ReadLine());

        string[,] ogrenciBilgileri = new string[ogrenciSayisi, 7];

        for (int i = 0; i < ogrenciSayisi; i++)
        {
            Console.WriteLine($"{i + 1}. Öğrencinin bilgilerini giriniz:");

            Console.Write("Numarasını giriniz (11 hane): ");
            ogrenciBilgileri[i, 0] = Console.ReadLine();

            Console.Write("Adını giriniz: ");
            ogrenciBilgileri[i, 1] = Console.ReadLine();

            Console.Write("Soyadını giriniz: ");
            ogrenciBilgileri[i, 2] = Console.ReadLine();

            Console.Write("Vize notunu giriniz (0-100): ");
            int vize = int.Parse(Console.ReadLine());
            ogrenciBilgileri[i, 3] = vize.ToString();

            Console.Write("Final notunu giriniz (0-100): ");
            int final = int.Parse(Console.ReadLine());
            ogrenciBilgileri[i, 4] = final.ToString();

            double ortalama = (vize * 0.4) + (final * 0.6);
            ogrenciBilgileri[i, 5] = ortalama.ToString("F2");

            string[] harfNotlari = { "FF", "FD", "DD", "DC", "CC", "CB", "BB", "BA", "AA" };
            int indeks = (int)Math.Min(Math.Max((ortalama - 10) / 10, 0), 8);
            ogrenciBilgileri[i, 6] = harfNotlari[indeks];
        }

        Console.WriteLine("\nNumara\tAd\tSoyad\tVize Notu\tFinal Notu\tOrtalama\tHarf Notu");
        for (int i = 0; i < ogrenciSayisi; i++)
        {
            Console.WriteLine($"{ogrenciBilgileri[i, 0]}\t{ogrenciBilgileri[i, 1]}\t{ogrenciBilgileri[i, 2]}\t" +
                              $"{ogrenciBilgileri[i, 3]}\t\t{ogrenciBilgileri[i, 4]}\t\t{ogrenciBilgileri[i, 5]}\t\t{ogrenciBilgileri[i, 6]}");
        }
    }
}
