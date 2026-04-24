using nameSpaceWF;
using System;
using System.Data;
using System.Windows.Forms;

namespace Controle_de_Qualidade
{
    public partial class INFOS : Form
    {
        CLS_BDCONECTA Conn = new CLS_BDCONECTA();
        public DataTable Data = new DataTable();
        string prod;
        public INFOS(string PRODUTO,string COPIA)
        {
            InitializeComponent();

            string[,] prd = Conn.FastSelect("select cod_prd_pr5030,descr_prd_pr5030 from pr5030 where cod_prd_pr5030='" + PRODUTO + "'");

            lbPROD.Text = prd[0, 0] + " - " + prd[0, 1];
            prod = PRODUTO;

            CriaGrid();
            AtualizaGrid();

            if (COPIA != "")
            {
                prod = COPIA;

                prd = Conn.FastSelect("select cod_prd_pr5030,descr_prd_pr5030 from pr5030 where cod_prd_pr5030='" + prod + "'");

                lbPROD.Text = prd[0, 0] + " - " + prd[0, 1];
            }
        }

        #region BOTAO
        private void btSalvar_Click(object sender, EventArgs e)
        {
            string insert = "";
            string del = "";

            Cursor.Current = Cursors.WaitCursor;

            del = "delete from et9631 where cod_prod_et9631 = '" + prod + "' ";

            for (int i = 0; i <= Data.Rows.Count - 1; i++)
            {
                string[,] processo = Conn.FastSelect("select codigo_me9030 from me9030 where desc_me9030='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' ");
                string[,] metodo = Conn.FastSelect("select cod_metodo_et9636 from et9636 where nome_metodo_et9636='" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "'");
                string[,] ver = Conn.FastSelect("select versao_et9631 from et9631 where cod_prod_et9631='"+prod+"' group by versao_et9631");

                insert += " insert into et9631 values ('01','01','" + prod + "',"+ver[0,0]+",'" + processo[0, 0] + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "'" +
                    ",'" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "'" +
                    ",'" + metodo[0, 0] + "',null,null,'" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + dataGridView1.Rows[i].Cells[6].Value.ToString() + "" +
                    ",null,null,null,null,null,null,null,null) ";
            }
            Conn.Play("", insert, del);
            string[,] AlteraOF = Conn.FastSelect("select num_of_et9633 from et9633 where " +
                "num_of_et9633 in (select NUM_OF from PCP_Capa_OF where STATUS_OF ='E' and SETOR=7 and COD_PROD='"+prod+"') " +
                "and resultado_et9633 is null group by num_of_et9633");

            insert = "";
            if (AlteraOF[0, 0] != "" && AlteraOF[0, 0] != null)//ATUALIZA AS OFS EM ANDAMENTO
            {
                if(AlteraOF[0,0]!="" && AlteraOF[0, 0] != null)
                {
                    insert += "insert into et9633 values ('01','01',numof,'proc','prop','inicio','fim','metodo',null,'','seq','0043',GETDATE(),GETDATE())";
                }
            }

            Cursor.Current = Cursors.Default;
            MessageBox.Show("Alteraçoes realizadas!");
        }
        private void btIncluir_Click(object sender, EventArgs e)
        {
            Metodos abre = new Metodos(prod, this, null);

            abre.Show();
            //this.Hide();
        }
        private void btAlterar_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.SelectedCells[0].RowIndex;

            string[,] INFO = new string[1, 9];
            for (int i = 0; i <= 7; i++)
            {
                INFO[0, i] = dataGridView1.Rows[a].Cells[i].Value.ToString();                
            }
            INFO[0, 8] = a.ToString();
            Metodos abre = new Metodos(prod, this, INFO);

            abre.Show();
            //this.Hide();
        }

        #endregion

        #region AÇAO
        #region GRID
        public void CriaGrid()
        {
            Data.Columns.Add("SEQ", typeof(string));
            Data.Columns.Add("PROCESSO", typeof(string));
            Data.Columns.Add("PROPRIEDADE", typeof(string));
            Data.Columns.Add("DESCRIÇÃO", typeof(string));
            Data.Columns.Add("ESPECIFICAÇÃO INICIAL", typeof(string));
            Data.Columns.Add("ESPECIFICAÇÃO FINAL", typeof(string));
            Data.Columns.Add("DESVIO", typeof(string));
            Data.Columns.Add("MÉTODO", typeof(string));

        }
        public void AtualizaGrid()
        {
            string[,] select = Conn.FastSelect("select seq_et9631,desc_me9030,cod_prop_et9631,nome_prop_et9630,especif_1_et9631,especif_2_et9631,desvio_et9631,nome_metodo_et9636 from et9631 " +
                "left join et9630 on cod_prop_et9630 = cod_prop_et9631 " +
                "left join et9636 on cod_metodo_et9636 = metodo_et9631 " +
                "left join(select codigo_me9030, desc_me9030  from me9030 where tipo_me9030 = '04') as FORMA on FORMA.codigo_me9030 = cod_proc_et9631 " +
                "where cod_prod_et9631 = '" + prod + "' " +
                "order by seq_et9631");

            if (select[0, 0] != "" && select[0, 0] != null)
            {
                for (int i = 0; i < select.GetLength(0); i++)
                {
                    Data.Rows.Add(select[i, 0], select[i, 1], select[i, 2], select[i, 3], select[i, 4], select[i, 5], select[i, 6], select[i, 7]);
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//ABRE METODOS
        {
            int a = dataGridView1.SelectedCells[0].RowIndex;

            string[,] INFO = new string[1, 9];
            for (int i = 0; i <= 7; i++)
            {
                INFO[0, i] = dataGridView1.Rows[a].Cells[i].Value.ToString();
            }
            INFO[0, 8] = a.ToString();
            Metodos abre = new Metodos(prod, this, INFO);

            abre.Show();
            //this.Hide();
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Data.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
        }
        #endregion

    }
}
