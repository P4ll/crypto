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
        private RichTextBox _textBox;
        private Form _form;
        private int _pos;
        private MenuStrip _menu;

        public void run(ref Form form, ref RichTextBox textBox) {
            _textBox = textBox;
            _form = form;

            _menu = (MenuStrip)form.Controls[1];
            ToolStripMenuItem item = new ToolStripMenuItem("Crypto test");

            StdGenerator stdGen = new StdGenerator(ref _textBox);
            YarrowGenerator yGen = new YarrowGenerator(ref _textBox);
            GeffeGenerator geffeGen = new GeffeGenerator(ref _textBox);
            SquareGenerator squareGen = new SquareGenerator(ref _textBox);
            Tester tester = new Tester(ref _textBox);
            MD5Hash md5Hash = new MD5Hash(ref _textBox, ref _form);
            
            item.DropDownItems.Add("Стандартный генератор");
            item.DropDownItems.Add("Квадратный конгруэнтный генератор");
            item.DropDownItems.Add("Генератор Геффа");
            item.DropDownItems.Add("Генератор Yarrow-160");
            item.DropDownItems.Add("Тестирование последовательности");
            item.DropDownItems.Add("MD5 хеш");

            item.DropDownItems[0].Click += stdGen.GenerateSequence;
            item.DropDownItems[1].Click += squareGen.GenerateSequence;
            item.DropDownItems[2].Click += geffeGen.GenerateSequence;
            item.DropDownItems[3].Click += yGen.GenerateSequence;
            item.DropDownItems[4].Click += tester.Test;
            item.DropDownItems[5].Click += md5Hash.WindowHashing;

            _menu.Items.Add(item);
            _pos = _menu.Items.Count - 1;
        }

        public void stop() {
            _menu.Items.RemoveAt(_pos);
        }
    }
}
