using System.Data;
using System.Data.SqlClient;

namespace SMBD2023
{
    public partial class tipo : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader lector;
        DataTable tabla;
        Type tip;
        public int valor;
        public tipo()
        {
            InitializeComponent();
        }
        /*
        public int val
        {
            get { return this.val; }
            set { this.val = valor; }
        }
        */

        public int valor1 { get; set; }




        private void groupBox1_Enter(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (radioButton2.Checked = true)
            {
                valor = 1;
            }
            else if (radioButton3.Checked = true)
            {
                valor = 2;
            }
            else if (radioButton4.Checked = true)
            {
                valor = 3;
            }
            else { valor = 4; }

            this.Close();

        }
    }
}
