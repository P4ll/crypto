using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto_test.Utils {
    public class TextProgressBar {
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public int Step { get; set; }
        public int CurrentValue { get; private set; }
        object lockObj = new object();

        public TextProgressBar() {
        }

        public TextProgressBar(int startValue, int endValue, int step) {
            StartValue = startValue;
            EndValue = endValue;
            Step = step;
        }

        public void PerformStep() {
            lock (lockObj) {
                if (CurrentValue < EndValue)
                    CurrentValue += Step;
            }
        }

        public override string ToString() {
            return $"Progress: {CurrentValue}\\{EndValue}";
        }
    }
}
