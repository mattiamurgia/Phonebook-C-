using System;
using System.Collections.Generic;
using static RubricaTelefonica.Program;
using RubricaTelefonica;

namespace RubricaTelefonica
{
    class Program
    {public enum Etichetta {Casa, Cellulare, Ufficio };

        public class Contatto
        {
            public string? Nome { get; set; }
            public string? Numero { get; set; }
            public Etichetta Etichetta { get; set; }
                      
            public override string ToString()
            {
                return $"Nome: {Nome}, Numero: {Numero}, Etichetta:{Etichetta}";               
            }
        }

        public class Rubrica
        {
            private List<Contatto> contatti;

            public Rubrica()
            {
                contatti = new List<Contatto>();
            }

            //Aggiungi Contatti
            public void aggiungiContatto(Contatto nuovoContatto)
            {
                contatti.Add(nuovoContatto);
            }

            //Rimuovi Contatti
            public void rimuoviContatto(Contatto contatto)
            {
                contatti.Remove(contatto);
            }

            //Contatti in ordine
            public void contattiInOrdine()
            {
                contatti.Sort((a, b) => a.Nome.CompareTo(b.Nome));
                foreach(Contatto contatto in contatti )
                {
                    Console.WriteLine(contatto);
                }
            }

            //Cerca contatti
            public void cercaContatto(string lettera)
            {
                List<Contatto> listaTrovati = new List<Contatto>();

                foreach(Contatto contatto in contatti)
                {
                    if (contatto.Nome.Contains(lettera))
                    {
                        listaTrovati.Add(contatto);
                        listaTrovati.ForEach(c => Console.WriteLine(c.ToString()));
                    }
                }

                if (listaTrovati.Count == 0)
                {
                    Console.WriteLine("Contatto non trovato");
                }

                else
                {
                    listaTrovati.ForEach(c => Console.WriteLine(c.ToString()));                                         
                }
            }

            //Unisci contatti
            public void unisciContatti(Contatto contatto1, Contatto contatto2)
                
            { List<Contatto> contattoUnito = new List<Contatto>();

                if(contatto1.Nome == contatto2.Nome && contatto1.Etichetta != contatto2.Etichetta)
                {
                    
                }
               
            }
        }

        //Main
        static void Main(string[] args)
        {
            //GestioneRubrica
            bool start = true;
            Rubrica rubrica1 = new Rubrica();

            while(start)
            {
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("1 Stampare la rubrica in ordine alfabetico");
                Console.WriteLine("2 Aggiungi un contatto");
                Console.WriteLine("3 Rimuovi un contatto");
                Console.WriteLine("4 Trova i contatti");
                Console.WriteLine("5 Unisci contatti");
                Console.WriteLine("0 Esci");

                int scelta = Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Stampa rubrica in ordine per nome");
                        rubrica1.contattiInOrdine();
                        break;

                    case 2:
                        Console.WriteLine("Inserisci il nome ");
                        string Nome = Console.ReadLine();

                        Console.WriteLine("Inserisci il numero ");
                        string Numero = Console.ReadLine();

                        Console.WriteLine("Inserisci l'etichetta ");
                        string Etichetta = Console.ReadLine();

                        Contatto contatto = new Contatto (Nome, Numero, Etichetta);
                        rubrica1.aggiungiContatto(contatto);
                        break;

                    case 3:
                        Console.WriteLine("Inserisci il contatto da rimuovere");
                        string nome = Console.ReadLine();
                        rubrica1.rimuoviContatto(nome);
                        break;

                    case 4:
                        Console.WriteLine("Inserisci il contatto da cercare");
                        string parola = Console.ReadLine();
                        rubrica1.cercaContatto("parola");
                        break;

                    case 0:
                    start = false;
                    break;

                    default:
                    Console.WriteLine("Opzione non valida");
                    break;                       
                }
            }

            Contatto contatto1 = new Contatto { Nome = "Mattia", Numero = "330000", Etichetta= Etichetta.Casa };
            Contatto contatto2 = new Contatto { Nome = "Alessio", Numero = "34948", Etichetta = Etichetta.Cellulare };

            Console.WriteLine("Crea e stampa contatti");
            Console.WriteLine(contatto1.ToString());
            Console.WriteLine(contatto2.ToString());
            Console.WriteLine(" ");
            
            Contatto contatto3 = new Contatto { Nome = "Filippo", Numero = "330000", Etichetta = Etichetta.Casa };
            Contatto contatto4 = new Contatto { Nome = "Alessiuuuuu", Numero = "34948", Etichetta = Etichetta.Ufficio };
            Contatto contatto5 = new Contatto { Nome = "Aiancarlo", Numero = "330000", Etichetta = Etichetta.Casa };
            Contatto contatto6 = new Contatto { Nome = "Zima", Numero = "34948", Etichetta = Etichetta.Ufficio };
            Contatto contatto7 = new Contatto { Nome = "Baba", Numero = "330000", Etichetta = Etichetta.Casa };
            Contatto contatto8 = new Contatto { Nome = "Mush", Numero = "34948", Etichetta = Etichetta.Ufficio };

            Rubrica rubrica = new Rubrica();

            //Aggiungi contatto in rubrica
            rubrica.aggiungiContatto(contatto3);
            rubrica.aggiungiContatto(contatto4);
            rubrica.aggiungiContatto(contatto5);
            rubrica.aggiungiContatto(contatto6);
            rubrica.aggiungiContatto(contatto7);
            rubrica.aggiungiContatto(contatto8);

            //Visualizza in ordine alfabetico
            Console.WriteLine("Stampa rubrica in ordine per nome");
            rubrica.contattiInOrdine();
            Console.WriteLine(" ");

            //Rimuovi contatto
            rubrica.rimuoviContatto(contatto4);

            //Visualizza i contatti trovati
            Console.WriteLine("I contatti trovati sono");
            rubrica.cercaContatto("A");

            //Console ReadKey
            Console.ReadKey();
        }
    }
}