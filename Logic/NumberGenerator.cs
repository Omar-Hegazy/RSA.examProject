using System;
using System.Numerics;

namespace Logic
{
    public class Keys
    {
        public Keys(int x, int d, int n)
        {
            this.x = x;
            this.d = d;
            this.n = n;

        }
        public int x;
        public int d;
        public int n;

    }

    public class KeyGenerator
    {
        public Keys GenerateKeys()
        {
            int p, q;

            p = GeneratePrime();
            do
            {
                q = GeneratePrime();
            } while (p == q);
            var f = (p - 1) * (q - 1);

            var n = GenerateN(p, q);
            var x = GenerateX(f, n);
            var d = GenerateD(f, x, n);

            return new Keys(x, d, n);

        }

        private int GeneratePrime()
        {
            var rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int randNumber = rand.Next(2, 100);
                
                if (IsPrimeNumber(randNumber))
                {
                    
                    return randNumber;
                }
            }
            throw new Exception("Prime number not found");
        }
        public bool IsPrimeNumber(int number)
        {
            for (int i = 1; i < number; i++)
            {
                BigInteger y = BigInteger.Pow(i, number - 1);
                BigInteger x = y % number;

                if (x != 1)
                {
                    return false;
                }
            }
            return true;
        }
        private int GenerateN(int p, int q)
        {
            return p * q;
        }

        private int GenerateX(int f, int n)
        {
            for(int i = 2; i < f; i++)
            {
                var gcdn = GCD(i, n);
                var gcdf = GCD(i, f);
                if (gcdn == 1 && gcdf == 1)
                    return i;
            }
            throw new Exception("Can not generate X");
        }

        private  int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        private int GenerateD(int f, int x, int n)
        {
            for (int i = 1; ; i++)
            {
                if (i != x && (x * i % f) == 1)
                {
                    return i;
                }
            }
            throw new Exception("Can not generate D");

        }
    }


}