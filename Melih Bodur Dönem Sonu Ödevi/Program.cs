class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
            if (!int.TryParse(Console.ReadLine(), out int ogrenciSayisi) || ogrenciSayisi <= 0)
            {
                Console.WriteLine("Geçerli bir pozitif tam sayı giriniz.");
                return;
            }

            string[,] ogrenciBilgileri = new string[ogrenciSayisi, 7];
            double[] ortalamalar = new double[ogrenciSayisi];

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"{i + 1}. Öğrencinin bilgilerini giriniz:");

                Console.Write("Numarasını giriniz: ");
                ogrenciBilgileri[i, 0] = Console.ReadLine();

                Console.Write("Adını giriniz: ");
                ogrenciBilgileri[i, 1] = Console.ReadLine();

                Console.Write("Soyadını giriniz: ");
                ogrenciBilgileri[i, 2] = Console.ReadLine();

                int vize;
                while (true)
                {
                    Console.Write("Vize notunu giriniz (0-100): ");
                    if (int.TryParse(Console.ReadLine(), out vize) && vize >= 0 && vize <= 100)
                        break;
                    Console.WriteLine("Geçersiz değer. 0-100 arasında bir sayı giriniz.");
                }
                ogrenciBilgileri[i, 3] = vize.ToString();

                int final;
                while (true)
                {
                    Console.Write("Final notunu giriniz (0-100): ");
                    if (int.TryParse(Console.ReadLine(), out final) && final >= 0 && final <= 100)
                        break;
                    Console.WriteLine("Geçersiz değer. 0-100 arasında bir sayı giriniz.");
                }
                ogrenciBilgileri[i, 4] = final.ToString();

                double ortalama = (vize * 0.4) + (final * 0.6);
                ortalamalar[i] = ortalama;
                ogrenciBilgileri[i, 5] = ortalama.ToString("F2");
                ogrenciBilgileri[i, 6] = HarfNotuHesapla(ortalama);
            }

            double sinifOrtalamasi = 0;
            double enDusukNot = double.MaxValue;
            double enYuksekNot = double.MinValue;

            foreach (double ortalama in ortalamalar)
            {
                sinifOrtalamasi += ortalama;
                if (ortalama < enDusukNot) enDusukNot = ortalama;
                if (ortalama > enYuksekNot) enYuksekNot = ortalama;
            }

            sinifOrtalamasi /= ogrenciSayisi;

            Console.WriteLine("\nNumara\tAd\tSoyad\tVize Notu\tFinal Notu\tOrtalama\tHarf Notu");
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"{ogrenciBilgileri[i, 0]}\t{ogrenciBilgileri[i, 1]}\t{ogrenciBilgileri[i, 2]}\t" +
                                  $"{ogrenciBilgileri[i, 3]}\t\t{ogrenciBilgileri[i, 4]}\t\t{ogrenciBilgileri[i, 5]}\t\t{ogrenciBilgileri[i, 6]}");
            }

            Console.WriteLine($"\nSınıf Ortalaması: {sinifOrtalamasi:F2}");
            Console.WriteLine($"En düşük not: {enDusukNot:F2}");
            Console.WriteLine($"En yüksek not: {enYuksekNot:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Beklenmeyen bir hata oluştu: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nProgram tamamlandı. Çıkmak için bir tuşa basın.");
            Console.ReadKey();
        }
    }

    static string HarfNotuHesapla(double ortalama)
    {
        if (ortalama >= 85) return "AA";
        if (ortalama >= 75) return "BA";
        if (ortalama >= 60) return "BB";
        if (ortalama >= 50) return "CB";
        if (ortalama >= 40) return "CC";
        if (ortalama >= 30) return "DC";
        if (ortalama >= 20) return "DD";
        if (ortalama >= 10) return "FD";
        return "FF";
    }
}