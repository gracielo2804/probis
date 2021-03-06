﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Probis
{
    public partial class Home : Form
    {
        OracleConnection conn = form_login.conn;
        OracleDataAdapter da;
        DataSet ds = new DataSet();
        public Home()
        {
            InitializeComponent();
            lbl_user.Text = form_login.nama;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void dgv()
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT tour_id as ID, tour_nama as Nama_Tour,tour_date_awal as Tanggal_Tour,tour_harga as Harga from paket_tour", conn);
            da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            conn.Close();
            da.Fill(ds, "paket");
            dgv_list.DataSource = ds;
            dgv_list.DataMember = "paket";
            dgv_list.Columns[2].DefaultCellStyle.Format = "dd MMMM yyyy";
            dgv_list.Columns[3].DefaultCellStyle.Format = "Rp #,0";
        }
        public static string id="";
        public static int harga;
        private void dgv_list_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                harga = Convert.ToInt32(dgv_list.Rows[e.RowIndex].Cells[3].Value.ToString());
                id = dgv_list.Rows[e.RowIndex].Cells[0].Value.ToString();
                lihatPaket l = new lihatPaket();
                this.Hide();
                l.ShowDialog();
                this.Show();
            }
        }

        private void dgv_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            dgv();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            form_login homeAdmin = new form_login();
            this.Hide();
            homeAdmin.ShowDialog();
            this.Show();
        }
    }
}
