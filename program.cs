using System;
using System.IO;

namespace NotTakipProjesi
{
    class Program
    {
        static string dosyaYolu = "notlar.txt";

        static void Main(string[] args)
        {
        }

        static void NotGuncelle(string ogrenciAdi, string yeniNot)
        {
            if (File.Exists(dosyaYolu) == false)
            {
                Console.WriteLine("Hata: Dosya bulunamadi.");
                return;
            }

            string[] satirlar = File.ReadAllLines(dosyaYolu);
            bool bulundu = false;

            for (int i = 0; i < satirlar.Length; i++)
            {
                if (satirlar[i].StartsWith(ogrenciAdi + ","))
                {
                    satirlar[i] = ogrenciAdi + "," + yeniNot;
                    bulundu = true;
                    break; 
                }
            }

            if (bulundu == true)
            {
                File.WriteAllLines(dosyaYolu, satirlar);
            }
            
            Console.WriteLine("finished");
        }

        static void NotSil(string ogrenciAdi)
        {
            if (File.Exists(dosyaYolu) == false)
            {
                Console.WriteLine("Hata: Dosya bulunamadi.");
                return;
            }

            string[] satirlar = File.ReadAllLines(dosyaYolu);
            int silinecekIndex = -1;

            for (int i = 0; i < satirlar.Length; i++)
            {
                if (satirlar[i].StartsWith(ogrenciAdi + ","))
                {
                    silinecekIndex = i;
                    break;
                }
            }

            if (silinecekIndex != -1)
            {
                string[] yeniSatirlar = new string[satirlar.Length - 1];
                int sayac = 0;

                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (i != silinecekIndex)
                    {
                        yeniSatirlar[sayac] = satirlar[i];
                        sayac++;
                    }
                }

                File.WriteAllLines(dosyaYolu, yeniSatirlar);
            }
            
            Console.WriteLine("finished");
        }
    }
}