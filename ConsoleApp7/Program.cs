using System.Collections;

namespace ConsoleApp7
{
    internal class Program
    {
        static public SortedList manav_meyveler = new SortedList();
        static public SortedList manav_sebzeler = new SortedList();

        public static void MeyveStoklariListele()
        {
            Console.WriteLine("\nMeyveler:");
            foreach (string item in manav_meyveler.Keys)
            {
                Console.WriteLine($"{item} - {manav_meyveler[item]} kg");
            }
        }

        public static void SebzeStoklariListele()
        {
            Console.WriteLine("\nSebzeler:");
            foreach (string item in manav_sebzeler.Keys)
            {
                Console.WriteLine($"{item} - {manav_sebzeler[item]} kg");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hale Hosgeldiniz. Meyve İcin M, Sebze İcin S Basin.");
                string Manav_Secim = Console.ReadLine().ToUpper();

                if (Manav_Secim == "M")
                {
                    Toptanci.Meyve_Listele();

                    Console.WriteLine("Hangi meyveyi istersin?");
                    string secim = Console.ReadLine().ToLower();

                    if (Toptanci.Meyveler.ContainsKey(secim))
                    {
                        Console.WriteLine("Kac kilo istersin?");
                        int kilo = Convert.ToInt32(Console.ReadLine());

                        if ((int)Toptanci.Meyveler[secim] >= kilo)
                        {
                            Toptanci.Meyveler[secim] = (int)Toptanci.Meyveler[secim] - kilo;

                            if (manav_meyveler.ContainsKey(secim))
                            {
                                manav_meyveler[secim] = (int)manav_meyveler[secim] + kilo;
                            }
                            else
                            {
                                manav_meyveler.Add(secim, kilo);
                            }

                            Console.WriteLine($"{kilo} kg {secim} manav stoğuna eklendi.");
                        }
                        else
                        {
                            Console.WriteLine("Maalesef yeterli stok yok.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu ürün mevcut değil.");
                    }
                }
                else if (Manav_Secim == "S")
                {
                    Toptanci.Sebze_Listele();

                    Console.WriteLine("Hangi sebzeyi istersin?");
                    string secim = Console.ReadLine().ToLower();

                    if (Toptanci.Sebzeler.ContainsKey(secim))
                    {
                        Console.WriteLine("Kac kilo istersin?");
                        int kilo = Convert.ToInt32(Console.ReadLine());

                        if ((int)Toptanci.Sebzeler[secim] >= kilo)
                        {
                            Toptanci.Sebzeler[secim] = (int)Toptanci.Sebzeler[secim] - kilo;

                            if (manav_sebzeler.ContainsKey(secim))
                            {
                                manav_sebzeler[secim] = (int)manav_sebzeler[secim] + kilo;
                            }
                            else
                            {
                                manav_sebzeler.Add(secim, kilo);
                            }

                            Console.WriteLine($"{kilo} kg {secim} manav stoğuna eklendi.");
                        }
                        else
                        {
                            Console.WriteLine("Maalesef yeterli stok yok.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu ürün mevcut değil.");
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı tuşlama.");
                }

                Console.WriteLine("Baska bir arzunuz var mı? (Evet/Hayır)");
                string cevap = Console.ReadLine().ToLower();

                if (cevap == "hayır")
                {
                    break;
                }
            }

            Müsteri.Müsteri_Alisveris();
        }
    }

    class Toptanci
    {
        public static SortedList Meyveler = new SortedList()
        {
            {"muz", 100 },
            {"cilek", 80},
            {"portakal", 150 },
            {"mandalina", 200 },
            {"elma", 95 }
        };

        public static SortedList Sebzeler = new SortedList()
        {
            {"domates", 250 },
            {"salatalik", 150},
            {"marul", 200 },
            {"kabak", 100 },
            {"patlican", 100 },
            {"brokoli", 150 }
        };

        public static void Meyve_Listele()
        {
            foreach (string item in Meyveler.Keys)
            {
                Console.WriteLine(item);
            }
        }

        public static void Sebze_Listele()
        {
            foreach (string item in Sebzeler.Keys)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Müsteri
    {
        static ArrayList Müsteri_Liste = new ArrayList();

        public static void Müsteri_Alisveris()
        {
            while (true)
            {
                Console.WriteLine("Manava Hosgeldiniz. Meyve İcin M, Sebze İcin S Basin.");
                string Müsteri_Secim = Console.ReadLine().ToUpper();

                if (Müsteri_Secim == "M")
                {
                    Program.MeyveStoklariListele();
                    Console.WriteLine("Bir meyve seçin:");
                    string secim = Console.ReadLine().ToLower();

                    if (Program.manav_meyveler.ContainsKey(secim))
                    {
                        Console.WriteLine("Kaç kilo?");
                        int müs_kilo = Convert.ToInt32(Console.ReadLine());

                        if ((int)Program.manav_meyveler[secim] >= müs_kilo)
                        {
                            Program.manav_meyveler[secim] = (int)Program.manav_meyveler[secim] - müs_kilo;
                            Müsteri_Liste.Add($"{müs_kilo} kg {secim}");
                            Console.WriteLine($"Stoktan {müs_kilo} kg {secim} düşüldü.");
                        }
                        else
                        {
                            Console.WriteLine("Elimizde yeterli stok yok.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu ürün mevcut değil.");
                    }
                }
                else if (Müsteri_Secim == "S")
                {
                    Program.SebzeStoklariListele();
                    Console.WriteLine("Bir sebze seçin:");
                    string secim = Console.ReadLine().ToLower();

                    if (Program.manav_sebzeler.ContainsKey(secim))
                    {
                        Console.WriteLine("Kaç kilo?");
                        int müs_kilo = Convert.ToInt32(Console.ReadLine());

                        if ((int)Program.manav_sebzeler[secim] >= müs_kilo)
                        {
                            Program.manav_sebzeler[secim] = (int)Program.manav_sebzeler[secim] - müs_kilo;
                            Müsteri_Liste.Add($"{müs_kilo} kg {secim}");
                            Console.WriteLine($"Stoktan {müs_kilo} kg {secim} düşüldü.");
                        }
                        else
                        {
                            Console.WriteLine("Elimizde yeterli stok yok.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu ürün mevcut değil.");
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı tuşlama.");
                }

                Console.WriteLine("Başka bir arzunuz var mı? (Evet/Hayır)");
                string cevap = Console.ReadLine().ToLower();

                if (cevap == "hayır")
                {
                    Console.WriteLine("\nAlışveriş Özeti:");
                    foreach (var item in Müsteri_Liste)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                }
            }
        }
    }
}