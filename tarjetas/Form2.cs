using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;



namespace tarjetas
{
    public partial class Form2 : Form
    {
        JObject  procesado;
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "STEAM")
            {
                radioButton7.Visible = false;
                radioButton6.Visible = true;
                radioButton5.Visible = false;
                radioButton4.Visible = true;
                radioButton3.Visible = false;
                radioButton2.Visible = true;
                radioButton1.Visible = true;
                radioButton7.Text = "50";
                radioButton6.Text = "30";
                radioButton5.Text = "25";
                radioButton4.Text = "20";
                radioButton3.Text = "15";
                radioButton2.Text = "10";
                radioButton1.Text = "5";
                
            }
            else
               if (comboBox1.SelectedItem.ToString() == "PSN")
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
               if (comboBox1.SelectedItem.ToString() == "GOOGLE")
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
        private string eleccion ()
        {
            string titi="";
            if ( radioButton1.Checked)
            {
              titi =  radioButton1.Text;
            }
            else {
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
                                titi =radioButton5.Text;
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


        private void guardarcode(string tarjeta, string plata, string code)
        {
            JObject chico = new JObject();
            chico.Add("codigo", code);
            chico.Add("usuario", "-");
            chico.Add("fecha de compra", DateTime.Today);
            chico.Add("fecha de entrega", "-");
            JObject objeto = (JObject)procesado[tarjeta];
            JArray lista = (JArray)objeto[plata];
            lista.Add(chico);
            objeto.Remove(plata);
            objeto.Add(plata,lista);
            procesado.Remove(tarjeta);
            procesado.Add(tarjeta,objeto);
            string patch = System.IO.Directory.GetCurrentDirectory();
            System.IO.File.WriteAllText("JSON.json", procesado.ToString());
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            guardarcode(comboBox1.Text, eleccion(),textBox1.Text);
        

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string json = System.IO.File.ReadAllText("JSON.json");
            procesado = JObject.Parse(json);
        }
    }
}
