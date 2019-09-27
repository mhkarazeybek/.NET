using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmLibraryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Models.FilmEntities db = new Models.FilmEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Filmler.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }
        private void RefreshGrid()
        {
            dataGridView1.DataSource = db.Filmler.ToList();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}