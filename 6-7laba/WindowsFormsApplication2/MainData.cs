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

namespace WindowsFormsApplication2
{
    public partial class MainData : Form
    {
        public MainData()
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
            };
        }
        private void SetModelToUI(UserInfo dto)
        {
            textBox1.Text = dto.Name;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ComboBox1()
        {
            comboBox1.Items.Add(Country.Россия);
            comboBox1.Items.Add(Country.Украина);
            comboBox1.Items.Add(Country.Беларусь);

        }
        private void ComboBox2()
        {
            comboBox2.Items.Add(Gender.Male);
            comboBox2.Items.Add(Gender.Female);
            comboBox2.Items.Add(Gender.Agender);
            comboBox2.Items.Add(Gender.Cisgender);
            comboBox2.Items.Add(Gender.Laminat);
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new (new WayPoint());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                listBox1.Items.Add(form.wp);
                RecalculatePrice();
            }
        }

        private Label label1;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // MainData
            // 
            this.ClientSize = new System.Drawing.Size(347, 332);
            this.Controls.Add(this.label1);
            this.Name = "MainData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Файлы заявок|*.Feuncoki" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = GetModelFromUI();
                SerializeHelper.WriteToFile(sfd.FileName, dt

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                var form = new SubData();
                var res = form.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    listBox1.Items.Add(form.or);
                }
            }
        }o);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл заявок|*.Feuncoki" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = SerializeHelper.LoadFromFile(ofd.FileName);
                SetModelToUI(dto);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
