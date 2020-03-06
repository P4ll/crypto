using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace crypto_test.Utils {
    public static class BigNumbersHelper {
        public static int[] SmallPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,
            47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103 };

        public static BigInteger Rand(int bitsLen) {
            BigInteger res = new BigInteger(0);
            BigInteger rad = new BigInteger(2);
            Random rand = new Random();
            for (int i = 0; i < bitsLen; ++i) {
                res += BigInteger.Pow(rad, i) * rand.Next(0, 2);
            }
            res += BigInteger.Pow(rad, bitsLen - 1);
            return res;
        }

        public static BigInteger Rand(BigInteger rb) {
            --rb;
            Random rand = new Random();
            string rbInStr = rb.ToString();
            StringBuilder res = new StringBuilder();

            res.Append(rand.Next(rbInStr[0] - '0' + 1));
            bool f = res[0] == rbInStr[0];
            for (int i = 1; i < rbInStr.Length; ++i) {
                if (f) {
                    res.Append(rand.Next(rbInStr[i] - '0' + 1));
                }
                else {
                    res.Append(rand.Next(10));
                }
            }
            return BigInteger.Parse(res.ToString());
        }

        public static int Log2(BigInteger num) {
            int res = 0;
            while (num > 0) {
                num /= 2;
                ++res;
            }
            return res;
        }

        public static BigInteger Rand(BigInteger lb, BigInteger rb) {
            BigInteger delta = rb - lb;
            return lb + Rand(delta);
        }

        public static bool IsPrime(BigInteger a) {
            if (a == 0 || a == 1) return false;

            for (int i = 0; i < SmallPrimes.Length; ++i) {
                if (a == SmallPrimes[i]) {
                    return true;
                }
                if (a % SmallPrimes[i] == 0) {
                    return false;
                }
            }

            int s = 0;
            var t = a - 1;
            while (t % 2 == 0) {
                t /= 2;
                s++;
            }

            BigInteger bound = Log2(a);
            for (int i = 0; i < bound; ++i) {

                var n = Rand(new BigInteger(2), a - 1);

                var x = BigInteger.ModPow(n, t, a);
                if (x == 1 || x == a - 1) {
                    continue;
                }

                bool prime = false;
                for (int j = 0; j < s - 1; j++) {
                    x = (x * x) % a;
                    if (x == 1) {
                        return false;
                    }

                    if (x == a - 1) {
                        prime = true;
                        break;
                    }
                }

                if (!prime) {
                    return false;
                }
            }

            return true;
        }

        public static BigInteger RandPrime(int bitsLen) {
            BigInteger num = Rand(bitsLen);
            while (!IsPrime(num)) {
                num = Rand(bitsLen);
            }
            return num;
        }

        public static void Swap(ref BigInteger a, ref BigInteger b) {
            BigInteger c = a;
            a = b;
            b = c;
        }

        public static BigInteger Gcd(BigInteger a, BigInteger b) {
            while (b != 0) {
                a %= b;
                Swap(ref a, ref b);
            }
            return a;
        }
    }
}
