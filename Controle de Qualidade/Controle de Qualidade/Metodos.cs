using nameSpaceWF;
using System;
using System.Windows.Forms;

namespace Controle_de_Qualidade
{
    public partial class Metodos : Form
    {
        CLS_BDCONECTA Conn = new CLS_BDCONECTA();
        string prd;

        INFOS Chama;
        string[,] Altera;
        public Metodos(string PRODUTO, INFOS pai, string[,] info)
        {

            Chama = pai;
            InitializeComponent();

            prd = PRODUTO;
            Altera = info;
            

            atuGB();

            if (Altera != null)
            {
                altera();
            }
        }

        #region Botoes
        private void btADICIONA_Click(object sender, EventArgs e)
        {
            if (cbCOD.Text!="" && cbPROC.Text!=""&& cbMETODO.Text!=""&& txSEQ.Text!="000") 
            {
                if (Altera == null)
                {
                    Chama.Data.Rows.Add(txSEQ.Text, cbPROC.Text, cbCOD.Text.Split('-')[0].Trim(), cbCOD.Text.Split('-')[1].Trim()
                    , txINICIO.Text.Replace(",", "."), txFIM.Text.Replace(",", "."), txDESVIO.Text, cbMETODO.Text.Split('-')[1].Trim());
                }
                else
                {
                    Chama.Data.Rows.RemoveAt(int.Parse(Altera[0, 8]));

                    Chama.Data.Rows.Add(txSEQ.Text, cbPROC.Text, cbCOD.Text.Split('-')[0].Trim(), cbCOD.Text.Split('-')[1].Trim()
                    , txINICIO.Text.Replace(",", "."), txFIM.Text.Replace(",", "."), txDESVIO.Text, cbMETODO.Text.Split('-')[1].Trim());
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Faltam informações!!!");
            }
        }

        #endregion

        #region AÇAO
        public void atuGB()//COMBOBOX
        {
            string[,] processo = Conn.FastSelect("select desc_me9030 from me9030 where tipo_me9030='04' ");
            for (int i = 0; i < processo.GetLength(0); i++)
            {
                cbPROC.Items.Add(processo[i, 0]);
            }
            string[,] propriedade = Conn.FastSelect("select cod_prop_et9630+' - '+ nome_prop_et9630 from et9630 ");
            for (int i = 0; i < propriedade.GetLength(0); i++)
            {
                cbCOD.Items.Add(propriedade[i, 0]);
            }
            string[,] metodo = Conn.FastSelect("select cod_metodo_et9636+' - '+ nome_metodo_et9636 from et9636 ");
            for (int i = 0; i < metodo.GetLength(0); i++)
            {
                cbMETODO.Items.Add(metodo[i, 0]);
            }
        }

        private void altera()
        {
            txSEQ.Text = Altera[0, 0];
            cbPROC.SelectedIndex = cbPROC.FindString(Altera[0, 1]);
            cbCOD.SelectedIndex = cbCOD.FindString(Altera[0, 2] + " - " + Altera[0, 3]);

            txINICIO.Text = Altera[0, 4];
            txFIM.Text = Altera[0, 5];
            txDESVIO.Text = Altera[0, 6];

            string[,] met = Conn.FastSelect("select cod_metodo_et9636+' - '+ nome_metodo_et9636 from et9636 where nome_metodo_et9636 like '%" + Altera[0, 7] + "'");
            cbMETODO.SelectedIndex = cbMETODO.FindString(met[0,0]);

        }

        #endregion

        #region Magica
        private void txSEQ_Leave(object sender, EventArgs e)//SEQUENCIA NO PADRAO BD
        {
            txSEQ.Text = txSEQ.Text.ToString().PadLeft(3, '0');
        }
        private void Metodos_FormClosing(object sender, FormClosingEventArgs e)//CHAMA ANTERIOR
        {
            //Chama.Show();
        }
        #endregion


    }
}
