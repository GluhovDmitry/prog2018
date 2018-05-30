using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TelephoneRef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool DoesNotExist()
        {
            bool f = false;
            foreach (string str in File.ReadLines("DATA.txt"))
            {
                string[] splitStr = str.Split(new Char[] { ' ' });
                if (textBox1.Text != string.Empty && splitStr.Contains(textBox1.Text) || textBox2.Text != string.Empty && splitStr.Contains(textBox2.Text))
                {
                    f = true;
                }
            }
            return f;
        }
        public bool EmpyTextBoxException()
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                return false;
            else return true;
        }
        public bool BigNumber()
        {
            bool f = true;

            string t = textBox2.Text;
            //for (int i = 0; i < t.Length; i++)
            //{
            //if (char.IsNumber(t[i]) & textBox2.Text != string.Empty && double.Parse(textBox2.Text) > 99999999999)
            if (t.Length > 11)
            {
                f = false;
            }
            //}
            return f;
        }
        public bool NameIsNumberOrNumberIsLetter()
        {
            bool f = true;
            char[] Arr1 = textBox1.Text.ToCharArray();
            char[] Arr2 = textBox2.Text.ToCharArray();
            for (var i = 0; i < Arr1.Length - 1; i++)
            {
                if (char.IsNumber(Arr1[i]) == true || char.IsLetter(Arr2[i]) == true)
                    f = false;
            }
            return f;
        }
        public bool RepeatException()
        {
            string Line = textBox1.Text + ' ' + textBox2.Text;
            bool f = true;
            foreach (string str in File.ReadLines("DATA.txt"))
            {
                string[] splitStr = str.Split(new Char[] { ' ' });
                if (splitStr.Contains(textBox1.Text))
                {
                    f = false;
                }
                else if (splitStr.Contains(textBox2.Text))
                {
                    f = false;
                }
            }
            return f;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void NoWhitePlace()
        {
            string[] fileLines = File.ReadAllLines("DATA.txt");
                int k = 0;
                foreach (var str in fileLines)
                {
                    string[] splitedLine = str.Split(' ');
                    if (splitedLine[0] == String.Empty)
                    {
                        for (var i = k; i < fileLines.Length - 1; i++)
                        {
                            fileLines[i] = fileLines[i + 1];
                        }
                        fileLines[fileLines.Length - 1] = String.Empty;
                    }
                    k++;
                }
                File.WriteAllLines("DATA.txt", fileLines);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Line = textBox1.Text + ' ' + textBox2.Text + Environment.NewLine;
            if (!File.Exists("DATA.txt"))
                File.Create("DATA.txt").Close();
            if (EmpyTextBoxException() == true && NameIsNumberOrNumberIsLetter() == true && RepeatException() == true && BigNumber() == true)
            {
                File.AppendAllText("DATA.txt", Line);
                NoWhitePlace();
            }
            else
            {
                //Ошибочка f = new Ошибочка();
                //f.Show();
                MessageBox.Show("Товарищ! Вы ничего не написали, либо написали что-то не то");
            }
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (BigNumber() && DoesNotExist())
            {
                foreach (string str in File.ReadLines("DATA.txt"))
                {
                    string[] splitStr = str.Split(new Char[] { ' ' });
                    if (splitStr.Contains(textBox1.Text))
                    {
                        textBox2.Text = splitStr[1];
                    }
                    else if (splitStr.Contains(textBox2.Text))
                    {
                        textBox1.Text = splitStr[0];
                    }
                }
            }
            else
            {
                MessageBox.Show("Товарищ! Таких данных нет, либо Вы написали что-то не то");
                //Ошибочка f = new Ошибочка();
                //f.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NameIsNumberOrNumberIsLetter() == true && BigNumber() && DoesNotExist())
            {
                string[] fileLines = File.ReadAllLines("DATA.txt");
                int k = 0;
                foreach (var str in fileLines)
                {
                    string[] splitedLine = str.Split(' ');
                    if (splitedLine[0] == textBox1.Text)
                    {
                        for (var i = k; i < fileLines.Length - 1; i++)
                        {
                            fileLines[i] = fileLines[i + 1];
                        }
                        fileLines[fileLines.Length - 1] = String.Empty;
                    }
                    k++;
                }
                File.WriteAllLines("DATA.txt", fileLines);
            }

            else
            {
                //Ошибочка f = new Ошибочка();
                //f.Show();
                MessageBox.Show("Товарищ! Таких данных нет, либо Вы написали что-то не то");
            }
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}
