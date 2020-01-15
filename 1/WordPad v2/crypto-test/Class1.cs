using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using crypto_test;

namespace Plugin {
    public class Class1 {
        public const string Name = "Crypto";
        private RichTextBox textBox;
        Form form;
        private int _pos;
        private MenuStrip _menu;

        public void run(ref Form form, ref RichTextBox textBox) {
            this.textBox = textBox;
            this.form = form;

            _menu = (MenuStrip)form.Controls[1];
            ToolStripMenuItem item = new ToolStripMenuItem("Crypto test");

            GeneratorStd stdGen = new GeneratorStd(ref this.textBox);
            GeneratorYarrow yGen = new GeneratorYarrow(ref this.textBox);
            Tester tester = new Tester(ref this.textBox);
            
            item.DropDownItems.Add("Генерация");
            item.DropDownItems.Add("Генерация Yarrow-160");
            item.DropDownItems.Add("Тестирование последовательности");

            item.DropDownItems[0].Click += stdGen.generate;
            item.DropDownItems[1].Click += yGen.generate;
            item.DropDownItems[2].Click += tester.test;
            
            _menu.Items.Add(item);
            _pos = _menu.Items.Count - 1;
        }

        public void stop() {
            _menu.Items.RemoveAt(_pos);
        }
    }
}
