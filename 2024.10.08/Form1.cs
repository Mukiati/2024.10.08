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
        databasehandler db;
        public Form1()
        {
            InitializeComponent();
            db = new databasehandler();
            start();
        }
        void start()
        {
            db.Readall();

            //db.delete(car.cars[1]);

            //db.deleteall();

            //db.insert();
        }
    }
}
