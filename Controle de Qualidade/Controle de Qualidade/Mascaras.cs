using nameSpaceWF;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Controle_de_Qualidade
{
    public partial class Mascaras : Form
    {
        CLS_BDCONECTA Conn = new CLS_BDCONECTA();

        DataTable Data = new DataTable();

        CQ pai = new CQ();
        public Mascaras(CQ call)
        {
            pai = call;

            InitializeComponent();

            CriaGrid();
            AtualizaGrid();
        }

        #region Botao       
        private void btCOP_Click(object sender, EventArgs e)
        {            
           string prd= Interaction.InputBox("Insira o codigo do produto novo", "Codigo", "");

            int a = dataGridView1.SelectedCells[0].RowIndex;
            string prod = dataGridView1.Rows[a].Cells[0].Value.ToString();

            INFOS chama = new INFOS(prod, prd);
            chama.Show();
        }

        #endregion

        #region Açao
        #region GRID
        public void CriaGrid()
        {
            Data.Columns.Add("PRODUTO", typeof(string));
            Data.Columns.Add("DESCRIÇÃO", typeof(string));

        }
        public void AtualizaGrid()
        {
            string where = "";
            if (txCOD.Text != "") { where = " and cod_prod_et9631 like '%" + txCOD.Text + "%'"; }
            string[,] select = Conn.FastSelect("select cod_prod_et9631,descr_prd_pr5030 from et9631 " +
                "left join pr5030 on cod_prd_pr5030 = cod_prod_et9631 where prd_ativo_pr5030='S' " + where +
                " group by cod_prod_et9631, descr_prd_pr5030");

            if (select[0, 0] != "" && select[0, 0] != null)
            {
                for (int i = 0; i < select.GetLength(0); i++)
                {
                    Data.Rows.Add(select[i, 0], select[i, 1]);
                }
            }

            dataGridView1.DataSource = Data;
        }
        public void RemoveGrid()
        {
            for (int i = Data.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = Data.Rows[i];
                dr.Delete();
            }

            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        #endregion


        #endregion

        #region Magia
        private void txCOD_KeyPress(object sender, KeyPressEventArgs e)//PESQUISA
        {
            if (e.KeyChar == (char)Keys.Enter)//ENTER
            {
                e.Handled = true;
                RemoveGrid();
                AtualizaGrid();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)// ABRE INFOS DA PEÇA
        {
            int a = dataGridView1.SelectedCells[0].RowIndex;
            string prod = dataGridView1.Rows[a].Cells[0].Value.ToString();

            INFOS chama = new INFOS(prod,"");
            chama.Show();
        }        
        private void Mascaras_FormClosing(object sender, FormClosingEventArgs e)
        {
            pai.Show();
        }        

        #endregion


    }
}
