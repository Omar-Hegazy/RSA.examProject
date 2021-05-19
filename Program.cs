using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
namespace RSA2
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptor = new Encrypt();
            var generator = new KeyGenerator();
            var keys = generator.GenerateKeys();
           
            for(; ; ) {
                Console.WriteLine("Choose your operation:");
                Console.WriteLine("1. Encrypt");
                Console.WriteLine("2. Decrypt");
                Console.WriteLine("3. Exit");
                var answer = Console.ReadKey();
                if (answer.KeyChar == '1')
                {
                    Console.WriteLine("Enter text:");
                    var text = Console.ReadLine();
                    //Calls encryption method
                    var encryptedText = encryptor.EncryptText(text, keys);
                    Console.WriteLine("Encrypted text:" + encryptedText);
                    Console.WriteLine("Decryption key:" + keys.d);
                    Console.WriteLine("Private key:" + keys.n);

                }
                else if (answer.KeyChar == '2')
                {
                    Console.WriteLine("Enter text:");
                    var text = Console.ReadLine();
                    Console.WriteLine("Please enter The Decryption key:");
                    var decryptionKey = Console.ReadLine();
                    Console.WriteLine("Please enter The Private key:");
                    var privateKey = Console.ReadLine();
                    var decKeys = new Keys(0, int.Parse(decryptionKey), int.Parse(privateKey));
                    //Calls decryption method with new keys
                    var decryptedMessage = encryptor.DecryptText(text, decKeys);
                    Console.WriteLine("Decrypted text:" + decryptedMessage);
                }
                else if (answer.KeyChar == '3')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unvailed input, enter numbers from 1 to 3 to select your oppration");
                }
                     
            }
        }
    }
}