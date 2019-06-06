using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoTraider
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        Stock stock = new Stock();
        Random rnd = new Random();
        List<Client> clients = new List<Client>();
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            stock.BTCCourse = rnd.Next(8000, 8600);
            stock.Notify();
            label9.Text = stock.BTCCourse.ToString();
            ShowClientInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double temp = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You must enter name!");
                return;
            }
            Client client = new Client();
            client.Login = textBox1.Text;
            if (double.TryParse(textBox2.Text, out temp))
                client.BTC = temp;
            else
            {
                MessageBox.Show("You must enter sum of BTC!");
                return;
            }
            if (double.TryParse(textBox3.Text, out temp))
                client.USD = temp;
            else
            {
                MessageBox.Show("You must enter sum of USD!");
                return;
            }
            if (double.TryParse(textBox4.Text, out temp))
                client.CourseForBuy = temp;
            else
            {
                MessageBox.Show("You must enter course for buy!");
                return;
            }
            if (double.TryParse(textBox5.Text, out temp))
                client.SumForBuy = temp;
            else
            {
                MessageBox.Show("You must enter sum for buy!");
                return;
            }
            if (double.TryParse(textBox6.Text, out temp))
                client.CourseForSell = temp;
            else
            {
                MessageBox.Show("You must enter course for sell!");
                return;
            }
            if (double.TryParse(textBox7.Text, out temp))
                client.SumForSell = temp;
            else
            {
                MessageBox.Show("You must enter sum for sell!");
                return;
            }
            clients.Add(client);
            stock.AddObserver(client);

            comboBox1.Items.Add(client.ToString());
        }

        

        void ShowClientInfo()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Client client = clients[comboBox1.SelectedIndex];
                textBox1.Text = client.Login;
                textBox2.Text = client.BTC.ToString();
                textBox3.Text = client.USD.ToString();
                textBox4.Text = client.CourseForBuy.ToString();
                textBox5.Text = client.SumForBuy.ToString();
                textBox6.Text = client.CourseForSell.ToString();
                textBox7.Text = client.SumForSell.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowClientInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client client = clients[comboBox1.SelectedIndex];
            client.SumForBuy = Convert.ToDouble(textBox5.Text);
            client.SumForSell = Convert.ToDouble(textBox7.Text);
            client.CourseForBuy = Convert.ToDouble(textBox4.Text);
            client.CourseForSell = Convert.ToDouble(textBox6.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
        }
    }
}
