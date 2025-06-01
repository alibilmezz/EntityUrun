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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        void Temizle()
        {
            TxtAd.Text= string.Empty;   
            TxtFiyat.Text= string.Empty;
            TxtID.Text= string.Empty;
            TxtMarka.Text= string.Empty;
            TxtStok.Text= string.Empty;
            comboBox1.Text= string.Empty;   
            checkBox1.Checked= false;
            checkBox2.Checked=false;
        }

        void Listele()
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.UrunID,
                                            x.UrunAd,
                                            x.UrunSatıs,
                                            x.UrunMarka,
                                            x.UrunStok,
                                            x.UrunDurum,
                                            x.Tbl_Kategori.KategoriAd,

                                        }).ToList();
        }
        DbEntityUrunEntities db=new DbEntityUrunEntities(); 
        private void FrmUrun_Load(object sender, EventArgs e)
        {
          
            Listele();
            var kategori=(from x in db.Tbl_Kategori select new {x.KategoriID,x.KategoriAd}).ToList();
            comboBox1.ValueMember = "KategoriID";
            comboBox1.DisplayMember = "KategoriAd";
            comboBox1.DataSource=kategori;
        }


        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAd.Text)||
                string.IsNullOrWhiteSpace(TxtFiyat.Text) ||
                string.IsNullOrWhiteSpace(TxtMarka.Text) ||
                string.IsNullOrWhiteSpace(TxtStok.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            try
            {
                Tbl_Urun t = new Tbl_Urun();
                t.UrunAd = TxtAd.Text;
                t.UrunMarka = TxtMarka.Text;
                t.UrunStok = short.Parse(TxtStok.Text);
                t.UrunKategori = int.Parse(comboBox1.SelectedValue.ToString());
                t.UrunSatıs = decimal.Parse(TxtFiyat.Text);
                if (checkBox1.Checked == true)
                {
                    t.UrunDurum = true;
                }
                else
                {
                    t.UrunDurum = false;
                }
                
                db.Tbl_Urun.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ürün Eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAd.Text) ||
                string.IsNullOrWhiteSpace(TxtID.Text) ||
                string.IsNullOrWhiteSpace(TxtFiyat.Text) ||
                string.IsNullOrWhiteSpace(TxtMarka.Text) ||
                string.IsNullOrWhiteSpace(TxtStok.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            try
            {
                int X=Convert.ToInt32(TxtID.Text);
                
                var urun = db.Tbl_Urun.Find(X);
                db.Tbl_Urun.Remove(urun);
                db.SaveChanges();
                MessageBox.Show("Ürün Silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAd.Text) ||
                string.IsNullOrWhiteSpace(TxtID.Text) ||
                string.IsNullOrWhiteSpace(TxtFiyat.Text) ||
                string.IsNullOrWhiteSpace(TxtMarka.Text) ||
                string.IsNullOrWhiteSpace(TxtStok.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurun.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                int X = Convert.ToInt32(TxtID.Text);
                var urun = db.Tbl_Urun.Find(X);
                urun.UrunAd = TxtAd.Text;
                urun.UrunStok = short.Parse(TxtStok.Text);
                urun.UrunMarka = TxtMarka.Text;
                urun.UrunKategori=int.Parse(comboBox1.SelectedValue.ToString());
                urun.UrunSatıs=decimal.Parse(TxtFiyat.Text);
                if (checkBox1.Checked == true)
                {
                    urun.UrunDurum = true;
                }
                else
                {
                    urun.UrunDurum = false;
                }
                db.SaveChanges();
                MessageBox.Show("Ürün Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtMarka.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtStok.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtFiyat.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string durum= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (durum == "True")
            {
                checkBox1.Checked=true;
            }
            else
            {
                checkBox1.Checked=false;    
            }
            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
