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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db=new DbEntityUrunEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label1.Text=db.Tbl_Kategori.Count().ToString();
            label4.Text=db.Tbl_Urun.Count().ToString();
            label6.Text=db.Tbl_Musteri.Count(x=>x.MusteriDurum==true).ToString();
            label8.Text = db.Tbl_Musteri.Count(x => x.MusteriDurum == false).ToString();
            label16.Text=db.Tbl_Urun.Count(x=>x.UrunKategori==1).ToString();
            label14.Text = db.Tbl_Urun.Count(x => x.UrunKategori == 2).ToString();
            label12.Text = db.Tbl_Urun.Count(x => x.UrunKategori == 6).ToString();
            label20.Text= db.Tbl_Urun.Sum(y=>y.UrunStok).ToString();
            label22.Text = db.Tbl_Satıs.Sum(x => x.SatısFiyat).ToString() + "TL";
            label10.Text=(from x in db.Tbl_Urun orderby x.UrunSatıs descending select x.UrunAd).FirstOrDefault();
            label24.Text= (from x in db.Tbl_Urun orderby x.UrunSatıs ascending select x.UrunAd).FirstOrDefault();
            label18.Text=db.MARKAGETIR().FirstOrDefault();
        }
    }
}
