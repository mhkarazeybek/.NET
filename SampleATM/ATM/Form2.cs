using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using BusinessLayer;
using DataAccessLAyer;

namespace ATM
{
    public partial class Form2 : Form
    {
        private Customers item;
        int counter = 0;
        public Form2()
        {
            InitializeComponent();
        }

        AtmEntities ent = new AtmEntities();
        List<Accounts> actList = new List<Accounts>();
        Accounts choosedAccount = null;
        public Form2(Customers item)
        {
            InitializeComponent();
            
            actList = ent.Accounts.Where(t => t.CustomerId == item.CustomerId).ToList();
            foreach (Accounts act in actList)
            {
                lblMoney.Text = act.Money.ToString();
                choosedAccount = act;
            }
           
            this.item = item;
            
            lblCustomer.Text = item.CustomerName;
        }
        private void btnNumbers_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int number = int.Parse(clickedBtn.Text);
            if (rdbWithdraw.Checked)
            {
                cmbAmount.Text += number;
            }
            else if (rdbTransfer.Checked)
            {
                if (counter==0)
                {
                    lblCardNo.Text += number;
                }
                else
                {
                    cmbAmount.Text += number;
                }
            }
            else
            {
                MessageBox.Show("Please choose a operation");
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (rdbTransfer.Checked)
            {
                if (lblCardNo.Text!="")
                {
                    lblCardNo.Text = lblCardNo.Text.Substring(0, lblCardNo.Text.Length - 1);
                }
            }
            else if (rdbWithdraw.Checked)
            {
                if (cmbAmount.Text != "")
                {
                    cmbAmount.Text = cmbAmount.Text.Substring(0, cmbAmount.Text.Length - 1);
                }
            }
        }

        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rdbTransfer.Checked)
            {
                if (counter==0)
                {
                    counter = 1;
                }
                else
                {
                    bool sonuc = Check.ControlCustomer(lblCardNo.Text);
                    if (sonuc)
                    {

                        List<Customers> csList = GetCustomer.GetAllCustomers();
                        foreach (Customers item in csList)
                        {
                            if (item.CardNo == lblCardNo.Text)
                            {
                                List<Accounts> actList = ent.Accounts.Where(t => t.CustomerId == item.CustomerId).ToList();
                                foreach (Accounts act in actList)
                                {
                                    if (cmbAmount.Text != "")
                                    {
                                        int amount = int.Parse(cmbAmount.Text);
                                        act.Money += amount;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please choose a amount");
                                    }
                                }
                                int result = ent.SaveChanges();
                                if (result > 0)
                                {
                                    MessageBox.Show("Successful");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Error");
                                }
                            }
                        }
                    }
                }
            }
            else if (rdbWithdraw.Checked)
            {
                if (choosedAccount!=null)
                {
                    int amount = int.Parse(cmbAmount.Text);
                    bool sonuc = Check.ControlMoney(choosedAccount,amount);
                    if (sonuc)
                    {
                        choosedAccount.Money -= amount;
                    }
                    else
                    {
                        MessageBox.Show("Not enough money");
                    }

                    int result = ent.SaveChanges();
                    if (result > 0)
                    {
                        MessageBox.Show("Successful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a operation");
            }
        }
    }
}