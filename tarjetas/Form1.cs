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
            if (tipotarjeta.SelectedItem.ToString() == "STEAM")
            {
                radioButton7.Visible = false;
                radioButton6.Visible = true;
                radioButton5.Visible = false;
                radioButton4.Visible = true;
                radioButton3.Visible = false;
                radioButton2.Visible = true;
                radioButton1.Visible = true;
                radioButton7.Text = "50";
                radioButton6.Text = "30";//5555
                radioButton5.Text = "25";
                radioButton4.Text = "20";
                radioButton3.Text = "15";
                radioButton2.Text = "10";
                radioButton1.Text = "5";
            }
            else
                if (tipotarjeta.SelectedItem.ToString() == "PSN")
            {
                radioButton7.Visible = false;
                radioButton6.Visible = true;
                radioButton5.Visible = false;
                radioButton4.Visible = true;
                radioButton3.Visible = false;
                radioButton2.Visible = true;
                radioButton1.Visible = false;
                radioButton7.Text = "50";
                radioButton6.Text = "30";
                radioButton5.Text = "25";
                radioButton4.Text = "20";
                radioButton3.Text = "15";
                radioButton2.Text = "10";
                radioButton1.Text = "5";
            }
            else
                if (tipotarjeta.SelectedItem.ToString() == "GOOGLE")
            {
                radioButton7.Visible = true;
                radioButton6.Visible = false;
                radioButton5.Visible = true;
                radioButton4.Visible = true;
                radioButton3.Visible = true;
                radioButton2.Visible = true;
                radioButton1.Visible = false;
                radioButton7.Text = "50";
                radioButton6.Text = "30";
                radioButton5.Text = "25";
                radioButton4.Text = "20";
                radioButton3.Text = "15";
                radioButton2.Text = "10";
                radioButton1.Text = "5";
            }



        }





        private string eleccion()  //me devuelve el valor del boton que eligio 
        {
            string titi = "";
            if (radioButton1.Checked)
            {
                titi = radioButton1.Text;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    titi = radioButton2.Text;
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        titi = radioButton3.Text;

                    }
                    else
                    {
                        if (radioButton4.Checked)
                        {
                            titi = radioButton4.Text;
                        }
                        else
                        {
                            if (radioButton5.Checked)
                            {
                                titi = radioButton5.Text;
                            }
                            else
                            {
                                if (radioButton6.Checked)
                                {
                                    titi = radioButton6.Text;
                                }
                                else
                                {
                                    if (radioButton7.Checked)
                                    {
                                        titi = radioButton7.Text;
                                    }
                                }
                            }
                        }
                    }
                }



            }


            return titi;


        }
        private int santi()
        {
            string nombre = tipotarjeta.Text;
            string valortarjeta = eleccion();
            int cantidad;
            JArray a = (JArray)procesado[nombre][valortarjeta];
            cantidad = a.Count;

            return cantidad;



        }




        private void buscarcod_Click(object sender, EventArgs e) // me busca el o los codigos
        {
            listBox1.Items.Clear();
            int cantidad = Convert.ToInt32(comboBox1.SelectedItem);
            string nombre = tipotarjeta.Text;
            string valortarjeta = eleccion();
            listBox1.Text = Convert.ToString(santi());
            JArray a = (JArray)procesado[nombre][valortarjeta];
            textBox1.Text = Convert.ToString(santi());
            if ((a != null) && (cantidad < santi()))
                for (int i = 0; i <= cantidad; i++)//88
                {
                    string codigo = Convert.ToString(procesado[nombre][valortarjeta][i]["codigo"]);

                    listBox1.Items.Add(codigo);
                }
            else
            {
                MessageBox.Show("No hay tantos");
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
            {//888888
                A = A + (Convert.ToString(listBox1.Items[i]));
                A = A + "\r\n";
                i = i - 1;
            }
            Clipboard.SetText(A);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
