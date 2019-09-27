using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLAyer;
using EntityLayer;
using BusinessLayer;

namespace ATM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int counter = 0;
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (counter==0)
            {
                counter = 1;
            }
            else
            {
                bool cntrlCard = Check.ControlCustomer(lblCardNo.Text);
                bool cntrlPass = Check.ControlPassword(lblPassword.Text, lblCardNo.Text);
                if (cntrlCard && cntrlPass)
                {
                    List<Customers> csList = GetCustomer.GetAllCustomers();
                    foreach (Customers item in csList)
                    {
                        if (item.CardNo == lblCardNo.Text)
                        {

                            Form2 frm = new Form2(item);
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password or CardNo is wrong");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtmEntities db = new AtmEntities();
            db.Database.CreateIfNotExists();
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int number = int.Parse(clickedBtn.Text);
            if (counter==0)
            {
                lblCardNo.Text += number;
            }
            else
            {
                lblPassword.Text += number;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (counter==0)
            {
                if (lblCardNo.Text!="")
                {
                    lblCardNo.Text = lblCardNo.Text.Substring(0, lblCardNo.Text.Length - 1);
                }
            }
            else
            {
                if (lblPassword.Text!="")
                {
                    lblPassword.Text = lblPassword.Text.Substring(0, lblPassword.Text.Length - 1);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            counter = 0;
        }
    }
}
