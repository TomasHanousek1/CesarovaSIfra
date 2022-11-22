using System;

namespace CesarovaSIfra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Klíč: ");
            string k = Console.ReadLine();
            Console.WriteLine("Text: ");
            string t = Console.ReadLine();

            Sifra sifra = new Sifra(k, t);
            Console.WriteLine("šifrované");
            Console.WriteLine(sifra.CryptedMessage);
            Console.WriteLine("zpět po šifrování");
            Console.WriteLine(sifra.Message);
            Console.ReadLine();
        }
    }
    public class Sifra //Vigenerova šifra
    {
        public Sifra(string key, string message)
        {
            Key = key.ToUpper();
            Message = message.ToUpper();
            Sifrovani();
            DESifrovani();
        }

        public string Key { get; set; }
        public string Message { get; set; }
        public string CryptedMessage { get; set; }

        public void Sifrovani()
        {
            string s = "";
            int i = 0;
            foreach (char c in Message)
            {
                int unicode = c;
                int myKey = Key[i] - 65;
                // Console.WriteLine(unicode < 128 ? "ASCII: {0}" : "Non-ASCII: {0}", unicode);
                if ((unicode + myKey) <= 90)
                {
                    unicode += myKey;
                }
                else
                {
                    unicode = (unicode + myKey) - 90 + 65 - 1;
                }
                s += (char)unicode;
                if (i == Key.Length - 1)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }

            }
            CryptedMessage = s;
            Message = "";
        }
        public void DESifrovani()
        {
            string s = "";
            int i = 0;
            foreach (char c in CryptedMessage)
            {

                int unicode = c;
                int myKey = Key[i] - 65;
                // Console.WriteLine(unicode < 128 ? "ASCII: {0}" : "Non-ASCII: {0}", unicode);
                if ((unicode - myKey) >= 65)
                {
                    unicode -= myKey;
                }
                else
                {
                    unicode = (unicode - myKey) + 90 - 65 + 1;
                }
                s += (char)unicode;
                if (i == Key.Length - 1)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }

            }
            Message = s;
        }
    }

    /*public class Sifra // Cesarova šifra
    {
        public Sifra(int key, string message)
        {
            Key = key;
            Message = message.ToUpper(); 
            Sifrovani();
            DESifrovani();
        }

        public int Key { get; set; }
        public string Message { get; set; }
        public string CryptedMessage { get; set; }

        public void Sifrovani()
        {
            string s = "";
            foreach (char c in Message)
            {
                int unicode = c;
               // Console.WriteLine(unicode < 128 ? "ASCII: {0}" : "Non-ASCII: {0}", unicode);
                if ((unicode + Key) <= 90)
                {
                    unicode += Key;
                }
                else
                {
                    unicode = (unicode + Key) - 90 + 65 - 1;
                }
                s += (char)unicode;
            }
            CryptedMessage = s;
            Message = "";
        }
        public void DESifrovani()
        {
            string s = "";
            foreach (char c in CryptedMessage)
            {
                int unicode = c;
                if ((unicode - Key) >= 65)
                {
                    unicode -= Key;
                }
                else
                {
                    unicode = (unicode - Key) + 90 - 65 + 1;
                }
                s += (char)unicode;
            }
            Message = s;
        }
    }*/
}
