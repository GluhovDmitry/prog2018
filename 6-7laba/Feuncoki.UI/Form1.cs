using _5laba;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _5laba.Orientation;

namespace Feuncoki.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboBox1();
            ComboBox2();
        }
        UserInfo GetModelFromUI()
        {
            return new UserInfo()
            {
                Name = textBox1.Text,
                Age = numericUpDown1.Value,
                Region = textBox2.Text,
                City = textBox3.Text,    
                //addGoal = listBox1.Items.OfType<string>().ToList()
            };
        }
        private void ComboBox1()
        {
            comboBox1.Items.Add(Country.Россия);
            comboBox1.Items.Add(Country.Украина);
            comboBox1.Items.Add(Country.Беларусь);

        }
        private void Saver1(UserInfo o)
        {
            if (comboBox1.SelectedIndex == 0)
                o.Country = Country.Россия;
            if (comboBox1.SelectedIndex == 1)
                o.Country = Country.Украина;
            if (comboBox1.SelectedIndex == 2)
                o.Country = Country.Беларусь;

        }
        private void ComboBox2()
        {
            comboBox2.Items.Add(Gender.Male);
            comboBox2.Items.Add(Gender.Female);
            comboBox2.Items.Add(Gender.Agender);
            comboBox2.Items.Add(Gender.Cisgender);
            comboBox2.Items.Add(Gender.Laminat);
        }
        private void Saver2(UserInfo o)
        {
            if (comboBox2.SelectedIndex == 0)
                o.Sex = Gender.Male;
            if (comboBox2.SelectedIndex == 1)
                o.Sex = Gender.Female;
            if (comboBox2.SelectedIndex == 2)
                o.Sex = Gender.Agender;
            if (comboBox2.SelectedIndex == 3)
                o.Sex = Gender.Cisgender;
            if (comboBox2.SelectedIndex == 4)
                o.Sex = Gender.Laminat;

        }
        private void Setter1(UserInfo o)
        {
            if (o.Country == Country.Россия)
                comboBox1.SelectedIndex = 0;
            if (o.Country == Country.Украина)
                comboBox1.SelectedIndex = 1;
            if (o.Country == Country.Беларусь)
                comboBox1.SelectedIndex = 2;
        }
        private void Setter2(UserInfo o)
        {
            if (o.Sex == Gender.Male)
                comboBox2.SelectedIndex = 0;
            if (o.Sex == Gender.Female)
                comboBox2.SelectedIndex = 1;
            if (o.Sex == Gender.Agender)
                comboBox2.SelectedIndex = 2;
            if (o.Sex == Gender.Cisgender)
                comboBox2.SelectedIndex = 3;
            if (o.Sex == Gender.Laminat)
                comboBox2.SelectedIndex = 4;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Файлы заявок|*.Feuncoki" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = GetModelFromUI();
                Saver1(dto);
                Saver2(dto);
                Orientation_saver(dto);
                Goal_Saver1(dto);
                Goal_Saver2(dto);
                Goal_Saver3(dto);
                Goal_Saver4(dto);
                SerializeHelper.WriteToFile(sfd.FileName, dto);
            }
        }

        private void SetModelToUI(UserInfo dto)
        {
            textBox1.Text = dto.Name;
            numericUpDown1.Value = dto.Age;
            textBox2.Text = dto.Region;
            textBox3.Text = dto.City;
            //listBox1.Items.Clear();
            //foreach (var i in dto.addGoal)
            //{
            //    listBox1.Items.Add(i);
            //}
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл заявок|*.Feuncoki" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = SerializeHelper.LoadFromFile(ofd.FileName);
                SetModelToUI(dto);
                Setter1(dto);
                Setter2(dto);
                Goal_Getter1(dto);
                Goal_Getter2(dto);
                Goal_Getter3(dto);
                Goal_Getter4(dto);
                Orientation_getter(dto);
            }
        }
        private void Orientation_saver(UserInfo p)
        {
            if (radioButton1.Checked)
            {
                p.SOrientation = TypesOrient.Hetero;
            }
            if (radioButton2.Checked)
            {
                p.SOrientation = TypesOrient.Кошечки;
            }
        }
        private void Orientation_getter(UserInfo p)
        {
            if ((p.SOrientation).Equals(TypesOrient.Hetero))
            {
                radioButton1.Checked = true;
            }
            if ((p.SOrientation).Equals(TypesOrient.Кошечки))
            {
                radioButton2.Checked = true;
            }
        }
        private void Goal_Saver1(UserInfo inf)
        {
            if (checkBox1.Checked )
            {
                inf.Purpose.Add(TypesPurpose.Дружба.ToString());
            }
        }
        private void Goal_Saver2(UserInfo inf)
        {
            if (checkBox2.Checked)
            {
                inf.Purpose.Add(TypesPurpose.Общение.ToString());
            }
        }
        private void Goal_Saver3(UserInfo inf)
        {
            if (checkBox3.Checked)
            {
                inf.Purpose.Add(TypesPurpose.Совместныйэксгибиционизм.ToString());
            }
        }
        private void Goal_Saver4(UserInfo inf)
        {
            if (checkBox4.Checked)
            {
                inf.Purpose.Add(TypesPurpose.Поматроситьибросить.ToString());
            }
        }
        private void Goal_Getter1(UserInfo inf)
        {
            foreach (var e in inf.Purpose)
            {
                if (e == TypesPurpose.Дружба.ToString())
                {
                    checkBox1.Checked = true;
                }
            }
        }
        private void Goal_Getter2(UserInfo inf)
        {
            foreach (var e in inf.Purpose)
            {
                if (e == TypesPurpose.Общение.ToString())
                {
                    checkBox2.Checked = true;
                }
            }
        }
        private void Goal_Getter3(UserInfo inf)
        {
            foreach (var e in inf.Purpose)
            {
                if (e == TypesPurpose.Совместныйэксгибиционизм.ToString())
                {
                    checkBox3.Checked = true;
                }
            }
        }
        private void Goal_Getter4(UserInfo inf)
        {
            foreach (var e in inf.Purpose)
            {
                if (e == TypesPurpose.Поматроситьибросить.ToString())
                {
                    checkBox4.Checked = true;
                }
            }
        }
        //List<string> Goals = new List<string>();
        //public List<string> addGoals()
        //{
        //    var f1 = 0;
        //    var f2 = 0;
        //    var f3 = 0;
        //    var f4 = 0;
        //    if (checkBox1.Checked == true && f1 != 1)
        //    {
        //        Goals.Add(TypesPurpose.Дружба.ToString());
        //        f1 = 1;           
        //    if (checkBox2.Checked == true && f2 != 2)
        //    {
        //        Goals.Add(TypesPurpose.Общение.ToString());
        //        f2 = 2;
        //    }
        //    if (checkBox3.Checked == true && f3 != 3)
        //    {
        //        Goals.Add(TypesPurpose.Совместныйэксгибиционизм.ToString());
        //        f3 = 3;
        //    }
        //    if (checkBox4.Checked == true && f4 != 4)
        //    {
        //        Goals.Add(TypesPurpose.Поматроситьибросить.ToString());
        //        f4 = 4;
        //    }
        //    }
        //    return Goals;
        //}

        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    //listBox1.Items.AddRange(addGoals().ToArray());
        //}
    }
}

