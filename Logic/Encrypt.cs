using System;
using System.Numerics;
using System.Text;

namespace Logic
{
    public class Encrypt
    {
        public string EncryptText(string message, Keys keys)
        {
            var encryptedMessage = "";
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            for (int i = 0; i < bytes.Length; i++)
            {
                BigInteger c = bytes[i] - 96;
                encryptedMessage = encryptedMessage + "," + (BigInteger.Pow(c, keys.x) % keys.n);
            }
            return encryptedMessage.Remove(0,1);
        }

        public string DecryptText(string message, Keys keys)
        {
            var decryptedMessage = "";
            var bytes = message.Split(',');
            for (int i = 0; i < bytes.Length; i++)
            {
                if (string.IsNullOrEmpty(bytes[i]))
                    continue;
                BigInteger c = new BigInteger(int.Parse(bytes[i]));
                decryptedMessage = decryptedMessage + (char)((int)(BigInteger.Pow(c, keys.d) % keys.n) +96);
            }
            return decryptedMessage;

        }
    }


}