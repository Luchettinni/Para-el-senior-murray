using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormKevin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Environment.SpecialFolder path in Enum.GetValues( typeof( Environment.SpecialFolder ) ) )
            {
                cmbUbicacion.Items.Add(path);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath((Environment.SpecialFolder)cmbUbicacion.SelectedItem);
                StreamWriter saveFile = new StreamWriter(path + @"\" + txtNombre.Text + ".txt");
                saveFile.Write(txtContenido.Text);
                saveFile.Close();
            }
            catch (Exception ex)
            {
                txtNombre.Text = "OCURRIO UN ERROR";
                txtContenido.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath((Environment.SpecialFolder)cmbUbicacion.SelectedItem);
                StreamReader loadFile = new StreamReader(path + @"\" + txtNombre.Text + ".txt");
                txtContenido.Text = loadFile.ReadLine();
            }
            catch (Exception ex)
            {
                txtNombre.Text = "OCURRIO UN ERROR";
                txtContenido.Text = ex.Message;
            }
        }
    }
}
