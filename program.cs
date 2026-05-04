using System;
using System.IO;

string dosyaYolu = "notlar.txt";

while (true)
{
    Console.WriteLine("\n--- NOT TAKİP SİSTEMİ ---");
    Console.WriteLine("1. Yeni Not Ekle");
    Console.WriteLine("2. Notları ve Ortalamayı Gör");
    Console.WriteLine("3. Not Güncelle");
    Console.WriteLine("4. Notları Temizle (Tümünü Sil)");
    Console.WriteLine("5. Çıkış");
    Console.Write("Seçiminiz (1/2/3/4/5): ");

    string secim = Console.ReadLine();

    if (secim == "1")
    {
        NotEkle(dosyaYolu);
    }
    else if (secim == "2")
    {
        NotlariOkuVeOrtalama(dosyaYolu);
    }
    else if (secim == "3")
    {
        NotGuncelle(dosyaYolu);
    }
    else if (secim == "4")
    {
        NotlariSil(dosyaYolu);
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

static void NotlariOkuVeOrtalama(string yol)
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
        int toplamNot = 0;

        for (int i = 0; i < satirlar.Length; i++)
        {
            string[] parcalar = satirlar[i].Split('|');
            Console.WriteLine((i + 1) + "- Ders: " + parcalar[0] + " | Not: " + parcalar[1]);
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

static void NotGuncelle(string yol)
{
    if (File.Exists(yol))
    {
        string[] satirlar = File.ReadAllLines(yol);
        
        if (satirlar.Length == 0)
        {
            Console.WriteLine("Güncellenecek not bulunamadı.");
            return;
        }

        Console.WriteLine("\n--- HANGİ NOTU GÜNCELLEMEK İSTİYORSUNUZ? ---");
        for (int i = 0; i < satirlar.Length; i++)
        {
            string[] parcalar = satirlar[i].Split('|');
            Console.WriteLine((i + 1) + "- Ders: " + parcalar[0] + " | Not: " + parcalar[1]);
        }

        Console.Write("\nGüncellemek istediğiniz notun numarasını girin: ");
        int guncellenecekNo = Convert.ToInt32(Console.ReadLine());

        // Kullanıcının girdiği numara geçerli mi diye kontrol ediyoruz
        if (guncellenecekNo > 0 && guncellenecekNo <= satirlar.Length)
        {
            Console.Write("Yeni Ders adı: ");
            string yeniDersAdi = Console.ReadLine();

            Console.Write("Yeni Not: ");
            int yeniNotDegeri = Convert.ToInt32(Console.ReadLine());

            if (yeniNotDegeri < 0 || yeniNotDegeri > 100)
            {
                Console.WriteLine("Hata: Not 0 ile 100 arasında olmalıdır!");
            }
            else
            {
                // Diziler 0'dan başladığı için kullanıcının girdiği sayıdan 1 çıkarıyoruz
                satirlar[guncellenecekNo - 1] = yeniDersAdi + "|" + yeniNotDegeri;
                
                // Güncellenmiş listeyi eski dosyanın üzerine komple yazıyoruz
                File.WriteAllLines(yol, satirlar);
                Console.WriteLine("Not başarıyla güncellendi.");
            }
        }
        else
        {
            Console.WriteLine("Hatalı bir numara girdiniz.");
        }
    }
    else
    {
        Console.WriteLine("Güncellenecek not bulunamadı.");
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