using System;
using System.IO;

string dosyaYolu = "notlar.txt";

while (true)
{
    Console.WriteLine("\n--- NOT TAKİP SİSTEMİ ---");
    Console.WriteLine("1. Yeni Not Ekle");
    Console.WriteLine("2. Notları Oku");
    Console.WriteLine("3. Notları Temizle (Tümünü Sil)");
    Console.WriteLine("4. Ortalama Göster");
    Console.WriteLine("5. Çıkış");
    Console.Write("Seçiminiz (1/2/3/4/5): ");

    string secim = Console.ReadLine();

    if (secim == "1")
    {
        NotEkle(dosyaYolu);
    }
    else if (secim == "2")
    {
        NotlariOku(dosyaYolu);
    }
    else if (secim == "3")
    {
        NotlariSil(dosyaYolu);
    }
    else if (secim == "4")
    {
        OrtalamaGoster(dosyaYolu);
    }
    else if (secim == "5")
    {
        Console.WriteLine("Sistemden çıkılıyor.");
        break;
    }
    else
    {
        Console.WriteLine("Hatalı bir tuşa bastınız, tekrar deneyin.");
    }
}

static void NotEkle(string yol)
{
    Console.Write("Ders adı: ");
    string dersAdi = Console.ReadLine();

    Console.Write("Not: ");
    int notDegeri = Convert.ToInt32(Console.ReadLine());

    if (notDegeri < 0 || notDegeri > 100)
    {
        Console.WriteLine("Hata: Not 0 ile 100 arasında olmalıdır!");
    }
    else
    {
        File.AppendAllText(yol, dersAdi + "|" + notDegeri + Environment.NewLine);
        Console.WriteLine("Not başarıyla eklendi.");
    }
}

static void NotlariOku(string yol)
{
    if (File.Exists(yol))
    {
        string[] satirlar = File.ReadAllLines(yol);
        
        if (satirlar.Length == 0)
        {
            Console.WriteLine("Henüz girilen not bulunamadı.");
            return;
        }

        Console.WriteLine("\n--- KAYITLI NOTLAR ---");
        for (int i = 0; i < satirlar.Length; i++)
        {
            string[] parcalar = satirlar[i].Split('|');
            Console.WriteLine((i + 1) + "- Ders: " + parcalar[0] + " | Not: " + parcalar[1]);
        }
    }
    else
    {
        Console.WriteLine("Henüz girilen not bulunamadı.");
    }
}

static void NotlariSil(string yol)
{
    if (File.Exists(yol))
    {
        File.Delete(yol);
        Console.WriteLine("Tüm notlar başarıyla silindi.");
    }
    else
    {
        Console.WriteLine("Silinecek herhangi bir not yok.");
    }
}

static void OrtalamaGoster(string yol)
{
    if (File.Exists(yol))
    {
        string[] satirlar = File.ReadAllLines(yol);
        
        if (satirlar.Length == 0)
        {
            Console.WriteLine("Henüz girilen not bulunamadı.");
            return;
        }

        int toplamNot = 0;
        
        for (int i = 0; i < satirlar.Length; i++)
        {
            string[] parcalar = satirlar[i].Split('|');
            toplamNot = toplamNot + Convert.ToInt32(parcalar[1]);
        }

        double ortalama = (double)toplamNot / satirlar.Length;
        Console.WriteLine("\nGenel Ortalama: " + ortalama);
    }
    else
    {
        Console.WriteLine("Henüz girilen not bulunamadı.");
    }
}