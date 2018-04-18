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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        //create intitial list of stocks
        List<Stock> stockList = new List<Stock>();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //print labels
            textBox3.AppendText("Date\t\tOpen\t\tHigh\t\tLow\t\tClose\t\tAdjusted\t\tVolume\n");

            //set initital dates
            DateTime date = Convert.ToDateTime("01/03/2017");
            monthCalendar1.SetDate(date);
            monthCalendar2.SetDate(date);

            string fileName = "FB.csv";

            //set default colors
            this.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            textBox3.ForeColor = Color.Black;


            if (File.Exists(fileName))
            {
                //open file
                StreamReader inputFile = new StreamReader(fileName);

                if (inputFile != null)
                {
                    inputFile.ReadLine();
                    String line;
                    //read file into stockList
                    while ((line = inputFile.ReadLine()) != null)
                    {

                        string[] values = line.Split(',');

                        Date dtObject = new Date(values[0]);
                        double open = Double.Parse(values[1]);
                        double high = Double.Parse(values[2]);
                        double low = Double.Parse(values[3]);
                        double close = Double.Parse(values[4]);
                        double adjClose = Double.Parse(values[5]);
                        double volume = Double.Parse(values[6]);

                        Stock stock = new Stock();
                        stock.Date = dtObject;
                        stock.Open = open;
                        stock.High = high;
                        stock.Low = low;
                        stock.Close = close;
                        stock.AdjClose = adjClose;
                        stock.Volume = volume;

                        stockList.Add(stock);


                    }
                    inputFile.Close();
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
            
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create list to filter out data that is not in the range
            List<Stock> stockList2 = new List<Stock>();
            textBox3.Clear();
            //create labels
            textBox3.AppendText("Date\t\tOpen\t\tHigh\t\tLow\t\tClose\t\tAdjusted\t\tVolume\n");
            //start date on calendar
            DateTime startDate = monthCalendar1.SelectionRange.Start.Date;
            //end date on calendar
            DateTime endDate = monthCalendar2.SelectionRange.Start.Date;
            //for loop to add data into stocklist2
            for (int i = 0; i < stockList.Count; i++)
            {
                //date of stock object
                DateTime currentDate = Convert.ToDateTime(stockList[i].Date.getDate());
                //how stock object date compares to start date
                int condition1 = DateTime.Compare(currentDate, startDate);
                //how stock object date compares to end date
                int condition2 = DateTime.Compare(currentDate, endDate);
                //if stock object date is after start date and before end date
                if (condition1 >= 0 && condition2 <= 0)
                {
                    //add to new list
                    stockList2.Add(stockList[i]);
                }
            }
                //for loop to print stock data
                for (int i = 0; i < stockList2.Count; i++)
                {
                    textBox3.AppendText(stockList2[i].Date.getDate() + "\t" + stockList2[i].Open.ToString("0.00") + "\t\t" + stockList2[i].High.ToString("0.00") + "\t\t" + stockList2[i].Low.ToString("0.00")
                       + "\t\t" + stockList2[i].Close.ToString("0.00") + "\t\t" + stockList2[i].AdjClose.ToString("0.00") + "\t\t" + stockList2[i].Volume.ToString() + "\n");
                }

        }
        //method for when date is changed
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }
        //method for when date is changed
        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.textBox2.Text = monthCalendar2.SelectionRange.Start.Date.ToShortDateString();
        }
        //the following are methods to change background colors and background colors
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            textBox1.BackColor = Color.Black;
            textBox2.BackColor = Color.Black;
            textBox3.BackColor = Color.Black;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
            textBox1.BackColor = Color.Blue;
            textBox2.BackColor = Color.Blue;
            textBox3.BackColor = Color.Blue;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            textBox1.BackColor = Color.Red;
            textBox2.BackColor = Color.Red;
            textBox3.BackColor = Color.Red;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            textBox1.BackColor = Color.Green;
            textBox2.BackColor = Color.Green;
            textBox3.BackColor = Color.Green;
        }

        private void blackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            textBox3.ForeColor = Color.Black;

        }

        private void whiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            textBox1.ForeColor = Color.White;
            textBox2.ForeColor = Color.White;
            textBox3.ForeColor = Color.White;

        }

        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Blue;
            label2.ForeColor = Color.Blue;
            textBox1.ForeColor = Color.Blue;
            textBox2.ForeColor = Color.Blue;
            textBox3.ForeColor = Color.Blue;
        }

        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
            textBox1.ForeColor = Color.Red;
            textBox2.ForeColor = Color.Red;
            textBox3.ForeColor = Color.Red;
        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Green;
            label2.ForeColor = Color.Green;
            textBox1.ForeColor = Color.Green;
            textBox2.ForeColor = Color.Green;
            textBox3.ForeColor = Color.Green;
        }
    }
}
