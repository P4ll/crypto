using System;
using System.Collections.Generic;
using System.Text;
using crypto_test;

namespace Testers {
    public static class GeneratorsTester {
        static public void Test(Generator gen, int len) {
            for (int i = 0; i < len; ++i) {
                Console.Write("{0} ", gen.Generate());
            }
        }
    }
}
