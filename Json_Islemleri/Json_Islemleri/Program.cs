using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Islemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            //JsonOlusturma();
            JsonOkuma();
        }


        private static void JsonOlusturma()
        {

            List<Kullanici> Kullaniciler = new List<Kullanici>();

            Kullanici k1 = new Kullanici();
            k1.ID = Guid.NewGuid();
            k1.Isim = "Salih";
            k1.Soyisim = "SEKER";
            k1.Numara = 1;
            k1.Github = "github.com/salihseker";

            Kullaniciler.Add(k1);

            Kullanici k2 = new Kullanici();
            k2.ID = Guid.NewGuid();
            k2.Isim = "Kerami";
            k2.Soyisim = "Ozsoy";
            k2.Numara = 2;
            k2.Github = "github.com/keramiozsoy";

            Kullaniciler.Add(k2);

            Console.WriteLine(@"Bilgileriniz Json Formatında D:\JsonIslemlerim\Kullaniciler.json olarak kayıt edilecektir.");

            if (Directory.Exists(@"D:\JsonIslemlerim\"))
            {
                // ilgili klasor var ise herhangi bir işlem yapmıyoruz. 
            }
            else
            {
                Directory.CreateDirectory(@"D:\JsonIslemlerim\");
            }

            string JsonKullaniciler = Newtonsoft.Json.JsonConvert.SerializeObject(Kullaniciler);
            File.WriteAllText(@"D:\JsonIslemlerim\Kullaniciler.json", JsonKullaniciler);

            Console.WriteLine("Json Export işlemi tamamlandı");

        }

        private static void JsonOkuma()
        {

            string JsonOkunanData = File.ReadAllText(@"D:\JsonIslemlerim\Kullaniciler.json");
          
            List<Kullanici> okunanJson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kullanici>>(JsonOkunanData);

            foreach (var item in okunanJson)
            {
                Console.WriteLine("ID : " + item.ID);
                Console.WriteLine("Isim : " + item.Isim);
                Console.WriteLine("Soyisim : " + item.Soyisim);
                Console.WriteLine("Numara : " + item.Numara);
                Console.WriteLine("Github : " + item.Github);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
