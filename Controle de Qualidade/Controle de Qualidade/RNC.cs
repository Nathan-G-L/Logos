using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nameSpaceWF;

namespace Controle_de_Qualidade
{
    public partial class RNC : Form
    {
        CLS_BDCONECTA Conn = new CLS_BDCONECTA();
        public RNC(string NUMOF,int qtd)
        {
            InitializeComponent();

            txDESC.Text = DateTime.Now.ToString()+"\n";

        }

        private void btSALVA_Click(object sender, EventArgs e)
        {

        }

        public void cbATU()
        {
            string[,] prob = Conn.FastSelect("select * from rnc5031");
            for(int i = 0; i < prob.GetLength(0); i++)
            {
                cbPROB.Items.Add(prob[0, i] + "-" + prob[1, i]);
            }

            string[,] classe = Conn.FastSelect("select * from rnc5032");
            for (int i = 0; i < classe.GetLength(0); i++)
            {
                cbCLASS.Items.Add(classe[0, i] + "-" + classe[1, i]);
            }

            string[,] setor = Conn.FastSelect("select * from rnc5035 where ativo_rnc5035=0");
            for (int i = 0; i < setor.GetLength(0); i++)
            {
                cbCLASS.Items.Add(setor[0, i] + "-" + setor[1, i]);
            }
        }
    }
}
