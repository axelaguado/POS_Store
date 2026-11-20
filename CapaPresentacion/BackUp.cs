using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class BackUp : Form
    {
        public Principal principal; 

        public BackUp(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
        }


    }
}
