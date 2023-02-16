using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace multithreadingForm
{
    public partial class Form1 : Form
    {
        public delegate void ThreadStart();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int p1 = Convert.ToInt32(textBox1.Text);
            int p2 = Convert.ToInt32(textBox2.Text);

            Random random = new Random(); // рандом задержки
            Thread myThread1 = new Thread(Print); // создаем новый поток
            Thread myThread2 = new Thread(Print2); // создаем новый поток
            myThread1.Start(); // запускаем поток myThread1
            myThread2.Start(); // запускаем поток myThread2

            void Print2()
            {
                for (int i = 0; i < p1; i++) // действия, выполняемые в главном потоке
                {
                    int a = random.Next(100, 500); // рандом задержки 100-500
                    listBox1.Invoke(new Action(() => { listBox1.Items.Add($"Главный поток - {i}, Задержка - {a}"); }));
                    Thread.Sleep(a);
                }
            }
            void Print()
            {
                for (int i = 0; i < p2; i++) // действия, выполняемые во втором потокке 
                {
                    int a = random.Next(100, 500); // рандом задержки 100-500
                    listBox2.Invoke(new Action(() => { listBox2.Items.Add($"Второй поток - {i}, Задержка - {a}"); }));
                    Thread.Sleep(a);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
    }
}
