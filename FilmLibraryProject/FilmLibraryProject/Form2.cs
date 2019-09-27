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
    public partial class Form2 : Form
    {
        Models.FilmEntities db = new Models.FilmEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Models.Film newFilm = new Models.Film();
            newFilm.FilmName = txtFilmAdi.Text;
            db.Filmler.Add(newFilm);
            int result = db.SaveChanges();
            if (result>0)
            {
                MessageBox.Show("Added");
            }
            else
            {
                MessageBox.Show("Not Added");
            }
            this.Close();
        }
    }
}
