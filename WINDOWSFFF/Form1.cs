using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINDOWSFFF
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поля ввода чисел", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            try
            {


                 
                              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                int a = int.Parse(textBox1.Text);
                int b = a % 10;
                int c = a % 100 / 10;
                int d = a / 100;
                int s = b + c + d;
                textBox2.Text = (a * a).ToString();
                textBox3.Text = (s).ToString();

                if (s == a*a)
                {
                    textBox4.Text = "Квадрат числа равен кубу";
                }
                else
                {
                    textBox4.Text = "Квадрат числа не равен кубу";
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
