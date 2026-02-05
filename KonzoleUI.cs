using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Utulek.Model;
using Utulek.Services;

namespace Utulek.UI
{
    public class KonzoleUI
    {
        private EvidenceService evidence;

        public KonzoleUI(EvidenceService e)
        {
            evidence = e;
        }

        public void Spust()
        {
            while (true)
            {
                Console.WriteLine("===== ÚTULEK PRO ZVÍŘATA =====");
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat všechna zvířata");
                Console.WriteLine("0) Konec");
                Console.Write("Volba: ");

                string volba = Console.ReadLine() ?? "";

                switch (volba)
                {
                    case "1":
                        PridatZvire();
                        break;
                    case "2":
                        VypisZvirata();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Neplatná volba");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void PridatZvire()
        {
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine() ?? "";

            Console.Write("Druh: ");
            string druh = Console.ReadLine() ?? "";

            Console.Write("Věk: ");
            int vek = int.TryParse(Console.ReadLine(), out int v) ? v : 0;

            evidence.Pridat(jmeno, druh, vek);

            Console.WriteLine("Zvíře přidáno.");
        }

        private void VypisZvirata()
        {
            Console.WriteLine("=== SEZNAM ZVÍŘAT ===");

            var seznam = evidence.Vsechna();

            if (seznam.Count == 0)
            {
                Console.WriteLine("Žádná zvířata v evidenci.");
                return;
            }

            foreach (var z in seznam)
            {
                Console.WriteLine($"{z.Id} | {z.Jmeno} | {z.Druh} | {z.Vek} let");
            }
        }
    }
}
