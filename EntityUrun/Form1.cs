using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntityUrun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities(); 
        void Listele()
        {
            var kategori = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = kategori;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          Listele();
            dataGridView1.ForeColor = Color.DarkSlateGray;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TxtAd.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun.","Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                Tbl_Kategori tbl = new Tbl_Kategori();
                tbl.KategoriAd = TxtAd.Text;
                db.Tbl_Kategori.Add(tbl);
                db.SaveChanges();
                MessageBox.Show("Kategori Eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                TxtAd.Text = string.Empty;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAd.Text)||
                string.IsNullOrWhiteSpace(TxtID.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                int x = Convert.ToInt32(TxtID.Text);
                var ktgr = db.Tbl_Kategori.Find(x);
                db.Tbl_Kategori.Remove(ktgr);
                db.SaveChanges();
                MessageBox.Show("Kategori Silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                TxtAd.Text = string.Empty;
                TxtID.Text = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAd.Text) ||
               string.IsNullOrWhiteSpace(TxtID.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                int x = Convert.ToInt32(TxtID.Text);
                var ktgr = db.Tbl_Kategori.Find(x);
                ktgr.KategoriAd = TxtAd.Text;
                db.SaveChanges();
                MessageBox.Show("Kategori Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                TxtAd.Text = string.Empty;
                TxtID.Text = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
