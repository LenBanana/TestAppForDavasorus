using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAppForDavasorus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileSearcher searcher = new FileSearcher();
            var textBoxes = searcher.FileReader();
            textBoxes.ForEach(box => panel1.Controls.Add(box));            
        }
    }
}
