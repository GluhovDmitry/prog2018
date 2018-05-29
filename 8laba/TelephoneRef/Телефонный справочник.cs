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
        public bool EmpyTextBoxException()
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                return false;
            else return true;
        }
        public bool BigNumber()
        {
            bool f = true;
            if (double.Parse(textBox2.Text) > 99999999999)
            {
                f = false;
            }
            return f;
        }
        public bool NameIsNumberOrNumberIsLetter()
        {
            bool f = true;
            char[] Arr1 = textBox1.Text.ToCharArray();
            char[] Arr2 = textBox2.Text.ToCharArray();
            for (var i = 0; i < Arr1.Length; i++)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpyTextBoxException() == true && NameIsNumberOrNumberIsLetter() == true && RepeatException() == true && BigNumber() == true)
            {
                string Line = textBox1.Text + ' ' + textBox2.Text + Environment.NewLine;
                if (!File.Exists("DATA.txt"))
                    File.Create("DATA.txt").Close();
                File.AppendAllText("DATA.txt", Line);
            }
            else
            {
                Ошибочка f = new Ошибочка();
                f.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (NameIsNumberOrNumberIsLetter() == true && BigNumber())
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
                Ошибочка f = new Ошибочка();
                f.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NameIsNumberOrNumberIsLetter()==true && BigNumber())
            {
                string[] fileLines = File.ReadAllLines("DATA.txt");
                int k = 0;
                foreach (string str in fileLines)
                {
                    string[] splitStr = str.Split(new Char[] { ' ' });
                    if (splitStr.Contains(textBox1.Text))
                    {
                        if (k != fileLines.Length - 1)
                            for (var i = k; i < fileLines.Length; i++)
                            {
                                fileLines[i] = fileLines[i + 1];
                            }
                        else fileLines[k] = String.Empty;
                    }
                    else if (splitStr.Contains(textBox2.Text))
                    {
                        if (k != fileLines.Length - 1)
                            for (var i = k; i < fileLines.Length; i++)
                            {
                                fileLines[i] = fileLines[i + 1];
                            }
                        else fileLines[k] = String.Empty;
                    }
                    File.WriteAllLines("DATA.txt", fileLines);
                    k++;
                }
            }
            else
            {
                Ошибочка f = new Ошибочка();
                f.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}
