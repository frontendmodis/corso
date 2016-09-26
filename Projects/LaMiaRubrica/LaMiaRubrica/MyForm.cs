using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaMiaRubrica
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            //List<Persona> persone = new List<Persona>();
            //persone.Add(new Persona("Mario", "Rossi", "123"));
            //persone.Add(new Persona("Giuseppe", "Verdi", "456"));

            List<Persona> persone = new List<Persona>()
            {
                new Persona("Mario", "Rossi", "123"),
                new Persona("Giuseppe", "Verdi", "456")
            };

            this.listBox1.DataSource = persone;
            this.listBox1.DisplayMember = "NomeCompleto";
            //this.label1.Text = persone.Count().ToString();
            this.label1.Text = Persona.TotalePersone.ToString();
        }
    }
}
