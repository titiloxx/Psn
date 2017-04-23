using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tarjetas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        JObject procesado;
        private void Form1_Load(object sender, EventArgs e)
        {
            string json = System.IO.File.ReadAllText("JSON.json");
            procesado = JObject.Parse(json);

        }

        private void usarcod_Click(object sender, EventArgs e)
        {

        }

        private void tipotarjeta_SelectedIndexChanged(object sender, EventArgs e)//me pone segun el tipo la aparicion de los botones
        {

        }


        private bool verificar(string nombre, int valor)
        {
            if (nombre == "PSN")
            {
                if (valor == 10 || valor == 20 || valor == 30)
                    return true;
                else
                {
                    MessageBox.Show("No hay ese valor de tarjeta para PSN");
                    return false;
                }
            }
            else if (nombre == "GOOGLE")
            {
                if (valor == 10 || valor == 20 || valor == 25 || valor == 50 || valor == 15)
                    return true;
                else
                {
                    MessageBox.Show("No hay ese valor de tarjeta para GOOGLE");
                    return false;
                }
            }
            else if (nombre == "STEAM")
            {
                if (valor == 10 || valor == 20 || valor == 5 || valor == 30)
                    return true;
                else
                {
                    MessageBox.Show("No hay ese valor de tarjeta para STEAM");
                    return false;
                }
            }
            MessageBox.Show("Revisa el nombre de la tarjeta");
            return false;

        }



        private int santi()
        {
            string nombre = tipotarjeta.Text;
            string valortarjeta =textBox2.Text;
            int cantidad;
            JArray a = (JArray)procesado[nombre][valortarjeta];
            cantidad = a.Count;
            return cantidad;
        }




        private void buscarcod_Click(object sender, EventArgs e) // me busca el o los codigos
        {
            if (verificar(tipotarjeta.Text, Convert.ToInt32(textBox2.Text)))
            {
            listBox1.Items.Clear();
            int cantidad = Convert.ToInt32(comboBox1.Text);
            string nombre = tipotarjeta.Text;
            string valortarjeta = textBox2.Text;
            listBox1.Text = Convert.ToString(santi());
            JArray a = (JArray)procesado[nombre][valortarjeta];
            textBox1.Text = Convert.ToString(santi());
            if ((a != null) && (cantidad <= santi()))
                for (int i = 0; i < cantidad; i++)
                {
                    string codigo = Convert.ToString(procesado[nombre][valortarjeta][i]["codigo"]);

                    listBox1.Items.Add(codigo);
                }
            else
            {
                MessageBox.Show("No hay tantos codigos");
            }
            }
        }

        private void bgregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 nuevo = new Form2();

          
            nuevo.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //copiar el codigo
        {
            String A = "";
            int i = (listBox1.Items.Count) - 1;       //Empieza contando en 0 el hdp
            while (i >= 0)
            {
                A = A + (Convert.ToString(listBox1.Items[i]));
                A = A + "\r\n";
                i = i - 1;
            }
            Clipboard.SetText(A);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
