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
           
            
        }

        private bool verificar(string nombre, int valor)
        {
            if (nombre=="PSN")
            {
               if(valor==10|| valor == 20|| valor == 30)
                return true;
                else
                {
                    return false;
                }
            }
           else if (nombre == "GOOGLE")
            {
                if (valor == 10 || valor == 20 || valor == 25 || valor == 50 || valor == 15)
                    return true;
                else
                {
                    return false;
                }
            }
            else if (nombre == "STEAM")
            {
                if (valor == 10 || valor == 20 || valor == 5 || valor == 30)
                    return true;
                else
                {
                    return false;
                }
            }
            MessageBox.Show("Revisa el nombre de la tarjeta");
            return false;

        }
        private void guardarcode(string tarjeta, string plata, string code)
        {
            JObject chico = new JObject();
            chico.Add("codigo", code);
            chico.Add("usuario", "-");
            chico.Add("fecha de compra", DateTime.Today.Date);
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
            if (verificar(comboBox1.Text, Convert.ToInt32(textBox2.Text)))
            {
                guardarcode(comboBox1.Text, textBox2.Text, textBox1.Text);
            }
            else
            {
                MessageBox.Show("No existe un valor para esa tarjeta");
            }
           
        

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string json = System.IO.File.ReadAllText("JSON.json");
            procesado = JObject.Parse(json);
        }
    }
}
