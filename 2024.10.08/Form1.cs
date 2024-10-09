using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024._10._08
{
    public partial class Form1 : Form
    {
       public  databasehandler db;
        public Form1()
        {
            InitializeComponent();
            
            start();
            
        }
        void start()
        {
            db = new databasehandler();
            readinfo();
            guna2Button1.Click += addbuttonclick;
            guna2Button2.Click += deletebuttonclick;
            guna2Button3.Click += alldelete;
           
        }
        void alldelete(object s,EventArgs e)
        {
            db.deleteall();
            readinfo();
        }
        void deletebuttonclick(object s, EventArgs e)
        {
            int temp = listBox1.SelectedIndex;
            if (temp <0)
            {
                return;
            }
            db.delete(car.cars[temp]);
            car.cars.RemoveAt(temp);
            readinfo();
        }
        void addbuttonclick(object s,EventArgs e)
        {
            car onecar = new car();
            onecar.name = guna2TextBox1.Text;
            onecar.hp = Convert.ToInt32(guna2TextBox2.Text);
            db.insert(onecar);
            readinfo();
        }
       
        void readinfo()
        {
            listBox1.Items.Clear();
            db.Readall();
            foreach (car item in car.cars)
            {
                listBox1.Items.Add($"AUTÓ: {item.name}, LÓERŐ: {item.hp}");
            }
        }
    }
}
