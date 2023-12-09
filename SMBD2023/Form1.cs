using Db4objects.Db4o;
using System.Data;
using System.Data.SqlClient;

namespace SMBD2023
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader lector;
        DataTable tabla;
        tipo tip;
        IObjectContainer db;


        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=localhost;Initial Catalog=Netflix;Integrated Security=True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    com = new SqlCommand();
                    com.CommandText = "insert into Contenido1 values(" +
                        Convert.ToInt32(textBox1.Text) + ",'" +
                        textBox2.Text + "','" +
                        comboBox1.Text + "','" +
                        textBox4.Text + "'," +
                        Convert.ToInt32(textBox5.Text) + "," +
                        Convert.ToInt32(textBox6.Text) + "," +
                        Convert.ToInt32(textBox7.Text) + ")";
                    com.CommandType = CommandType.Text;
                    com.Connection = con;
                    try
                    {
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        MessageBox.Show("Se ha insertado correctamente");
                        clearTB();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al insertar: " + ex.Message);
                        Console.WriteLine(ex.Message);

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 3)
            {

                db = Db4oEmbedded.OpenFile("SMBDOO.dat");
                Contenido c = new Contenido();
                c.Guardar(Convert.ToInt32(textBox1.Text),
                    textBox2.Text, comboBox1.Text, textBox4.Text,
                    Convert.ToInt32(textBox5.Text),
                    Convert.ToInt32(textBox6.Text),
                    Convert.ToInt32(textBox7.Text));
                db.Store(c);
                MessageBox.Show("Datos registrados");
                db.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            tip = new tipo();
            tip.ShowDialog();
            int v = tip.valor;


            comboBox1.SelectedIndex = v;

            if (v == 0 || v == 2)
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    com = new SqlCommand();
                    com.CommandText = "select * from Contenido1 where Id_Con =" + Convert.ToInt32(textBox1.Text);

                    com.CommandType = CommandType.Text;
                    com.Connection = con;
                    try
                    {
                        lector = com.ExecuteReader();
                        if (lector.Read())
                        {
                            textBox2.Text = lector.GetString(1);
                            comboBox1.Text = lector.GetString(2);
                            textBox4.Text = lector.GetString(3);

                            textBox5.Text = lector.GetInt32(4).ToString();
                            textBox6.Text = lector.GetInt32(5).ToString();
                            textBox7.Text = lector.GetInt32(6).ToString();


                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se encontraron datos");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else if (v == 1 || v == 3)
            {
                db = Db4oEmbedded.OpenFile("SMBDOO.dat");
                Contenido con = new Contenido(Convert.ToInt32(textBox1.Text));
                IObjectSet<Contenido> res = db.QueryByExample(con);
                foreach (Contenido obj in res)
                {
                    textBox2.Text = obj.VerTtulo();
                    comboBox1.Text = obj.VerTipo();
                    textBox4.Text = obj.VerGenero();
                    textBox5.Text = obj.VerTemporadas().ToString();
                    textBox6.Text = obj.VerCapitulos().ToString();
                    textBox7.Text = obj.VerDuracion().ToString();
                }
                db.Close();

                if (textBox2.Text == "")
                {
                    clearTB();
                    MessageBox.Show("No se encontraron datos");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    com = new SqlCommand();
                    com.CommandText = "UPDATE Contenido1 SET " +
                    "Titulo = '" + textBox2.Text + "', " +
                    "Genero = '" + textBox4.Text + "', " +
                    "Duracion = " + Convert.ToInt32(textBox5.Text) + " " +
                    "WHERE Id_Con = " + Convert.ToInt32(textBox1.Text);

                    com.CommandType = CommandType.Text;
                    com.Connection = con;

                    try
                    {
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        MessageBox.Show("Se ha insertado correctamente");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al insertar: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                db = Db4oEmbedded.OpenFile("SMBDOO.dat");
                Contenido con = new Contenido(Convert.ToInt32(textBox1.Text));
                IObjectSet<Contenido> res = db.QueryByExample(con);
                foreach (Contenido obj in res)
                {
                    obj.Actualizar(textBox2.Text, comboBox1.Text,
                        textBox4.Text, Convert.ToInt32(textBox5.Text),
                        Convert.ToInt32(textBox6.Text),
                        Convert.ToInt32(textBox7.Text));
                    db.Store(obj);
                }
                db.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    com = new SqlCommand();
                    com.CommandText = "delete from Contenido1 where id_Con = " + Convert.ToInt32(textBox1.Text) + "";

                    com.CommandType = CommandType.Text;
                    com.Connection = con;
                    try
                    {
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        MessageBox.Show("Se ha eliminado correctamente");
                        clearTB();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                db = Db4oEmbedded.OpenFile("SMBDOO.dat");
                Contenido con = new Contenido(Convert.ToInt32(textBox1.Text));
                IObjectSet<Contenido> res = db.QueryByExample(con);
                foreach (Contenido obj in res)
                {
                    db.Delete(obj);
                }
                db.Close();
            }
        }


        //funtion to clear the textboxes
        private void clearTB()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}