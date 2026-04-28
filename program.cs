using System;
using System.IO;
using System.Collections.Generic;

namespace NotTakipSistemi
{
    class Program
    {
        static string dosyaYolu = "notlar.txt";

        static void Main(string[] args)
        {
            bool calisiyor = true;

            while (calisiyor)
            {
                Console.Clear();
                Console.WriteLine("=== OĞRENCİ NOT TAKİP SİSTEMİ ===");
                Console.WriteLine("1. Not Ekle");
                Console.WriteLine("2. Notları Listele");
                Console.WriteLine("3. Not Güncelle");
                Console.WriteLine("4. Not Sil");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seciminiz (1-5): ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        NotEkle();
                        break;
                    case "2":
                        NotlariListele();
                        break;
                    case "3":
                        NotGuncelle();
                        break;
                    case "4":
                        NotSil();
                        break;
                    case "5":
                        calisiyor = false;
                        break;
                    default:
                        Console.WriteLine("Hatali secim yaptiniz.");
                        break;
                }

                if (calisiyor)
                {
                    Console.WriteLine("\nDevam etmek icin bir tusa basin...");
                    Console.ReadKey();
                }
            }
        }

        static void NotEkle()
        {
            Console.Clear();
            Console.WriteLine("--- NOT EKLE ---");
            Console.Write("Ogrenci Ad Soyad: ");
            string adSoyad = Console.ReadLine();
            Console.Write("Ders: ");
            string ders = Console.ReadLine();
            Console.Write("Not: ");
            string not = Console.ReadLine();

            string kayit = $"{adSoyad},{ders},{not}";

            try
            {
                File.AppendAllText(dosyaYolu, kayit + Environment.NewLine);
                Console.WriteLine("Kayit basariyla eklendi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }

        static void NotlariListele()
        {
        }

        static void NotGuncelle()
        {
        }

        static void NotSil()
        {
        }
    }
}