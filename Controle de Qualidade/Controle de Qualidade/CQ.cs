using Microsoft.VisualBasic;
using nameSpaceWF;
using System;
using System.Data;
using System.Windows.Forms;

namespace Controle_de_Qualidade
{
    public partial class CQ : Form
    {
        CLS_BDCONECTA Conn = new CLS_BDCONECTA();

        DataTable Data = new DataTable();
        public CQ()
        {
            InitializeComponent();

            CriaGrid();
            AtualizaGrid();

            atuCB();
            cbRESP.SelectedIndex = -1;

            lbstat.Text = "";
            lbset.Text = "";
        }

        #region BOTAO
        private void btMASK_Click(object sender, EventArgs e)//ABRE MASCARAS
        {
            Mascaras abr = new Mascaras(this);
            this.Hide();
            abr.Show();
        }
        private void btAPROVA_Click(object sender, EventArgs e)//JOGA INFOS DA QUALIDADE
        {
            string upd = " ";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    string aprovado = "S";
                    if (dataGridView1.Rows[i].Cells[6].Value == "REPROVADO")
                    {
                        aprovado = "N";
                    }
                    upd += "update et9633 set resultado_et9633='" + dataGridView1.Rows[i].Cells[5].Value.ToString().Replace(",", ".") + "',data_laudo_et9633=GETDATE(),hora_laudo_et9633=GETDATE(),status_et9633='" + aprovado +
                        "',usu_laudo_et9633='0043' where num_of_et9633=" + txOF.Text + " and cod_prop_et9633='" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "' \n";
                }
            }

            string SN = "S";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if ((dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[5].Value.ToString() == "") || cbRESP.SelectedItem == null)
                {
                    SN = "N";
                    MessageBox.Show("Faltam valores");
                    break;
                }
            }

            if (SN == "S")
            {
                DialogResult YN = MessageBox.Show("Deseja lançar valores para a OF?", "Tem certeza?", MessageBoxButtons.YesNo);

                if (YN == DialogResult.Yes)
                {
                    string[,] codrespo = Conn.FastSelect("select CODIGO from CADASTRO_FUNCIONARIO where NOME='" + cbRESP.Text + "'");
                    upd += " update et9830 set respons_cq_et9830='" + codrespo[0, 0] + "' where num_of_et9830=" + txOF.Text;

                    Conn.Play(upd, "", "");
                    MessageBox.Show("OF " + txOF.Text + " apontada!");

                    Pesquisa();

                    btAPROVA.Enabled = false;

                    ////ABRE RNC
                    //for (int i = 0; i < dataGridView1.RowCount; i++)
                    //{
                    //    if (dataGridView1.Rows[i].Cells[6].Value == "REPROVADO")
                    //    {
                    //        MessageBox.Show("Lançamento de RNC");

                    //        break;
                    //    }
                    //}
                }
            }
            
        }
        private void btSETOR_Click(object sender, EventArgs e)//APONTA OF NA QUALIDADE
        {
            string query = "update PCP_Capa_OF set APONTAMENTO_CQA = GETDATE(), SETOR = 7 WHERE NUM_OF =" + txOF.Text;
            string[,] STATUS = Conn.FastSelect("select STATUS_OF,APONTAMENTO_ENTR,APONTAMENTO_SAI from PCP_Capa_OF where NUM_OF =" + txOF.Text);
            string Stat = STATUS[0, 0];
            string TRAT;
            if (STATUS[0, 1] == null || STATUS[0, 1] == "") { TRAT = "N"; } else { TRAT = "S"; }
            if (STATUS[0, 2] == null || STATUS[0, 2] == "") { TRAT = "N"; }

            if (Stat == "A")
            {
                MessageBox.Show("OF AINDA NAO LIBERADA PARA PRODUÇÃO");
            }
            else
            {
                if (TRAT == "N")
                {
                    MessageBox.Show("OF AINDA NÃO PASSOU POR TRATAMENTO");
                }
                else
                {
                    DialogResult YN = MessageBox.Show("Deseja apontar a OF " + txOF.Text + " no controle?", "Tem certeza?", MessageBoxButtons.YesNo);
                    if (YN == DialogResult.Yes)
                    {
                        Conn.Play(query, "", "");
                        string[,] apontamentos = Conn.FastSelect($"select " +
                                $"COD_PROD, " +
                                $"descr_prd_pr5030, " +
                                $"QTDE_OF, " +
                                $"CASE WHEN STATUS_OF = 'C' THEN 'CANCELADA' " +
                                $"	WHEN STATUS_OF = 'F' THEN 'FINALIZADA' " +
                                $"	WHEN STATUS_OF = 'E' THEN 'EM ANDAMENTO' " +
                                $"	WHEN STATUS_OF = 'A' THEN 'EM ABERTO' " +
                                $"END, " +
                                $"CASE WHEN APONTAMENTO_ENTR IS NULL AND APONTAMENTO_SAI IS NULL THEN PCP_Setores_Produtivos.NOME " +
                                $"	WHEN APONTAMENTO_ENTR IS NOT NULL AND APONTAMENTO_SAI IS NULL THEN 'TRATAMENTO TÉRMICO' " +
                                $"	WHEN APONTAMENTO_ENTR IS NOT NULL AND APONTAMENTO_SAI IS NOT NULL THEN PCP_Setores_Produtivos.NOME " +
                                $"END, " +
                                $"APONTAMENTO_CQA, " +
                                $"ENTRADA_RECURSO, " +
                                $"APONTAMENTO_SAI " +
                                $",num_rnc0130" +
                                $" from PCP_Capa_OF " +
                                $" LEFT JOIN PCP_Setores_Produtivos ON PCP_Capa_OF.SETOR = PCP_Setores_Produtivos.ID " +
                                $" LEFT JOIN pr5030 on cod_prd_pr5030=COD_PROD " +
                                $"left join rnc0130 on of_rnc0130=NUM_OF" +
                                $"  where NUM_OF =" + txOF.Text);

                        if (apontamentos[0, 0] != null)
                        {
                            
                            lbstat.Text = apontamentos[0, 3];
                            lbset.Text = apontamentos[0, 4] + "   " + apontamentos[0, 5];
                            
                        }

                    }
                }
            }
        }


        private void btDESVIO_Click(object sender, EventArgs e)
        {
            string prd = Interaction.InputBox("Foi aprovado o desvio de peça?", "Responsavel", "");

            string upd = "update et9830 set observ_cq_et9830='" + prd + "' where num_of_et9830=" + txOF.Text ;

            Conn.Play(upd, "", "");

            txDESVIO.Text = prd;

        }
        #endregion

        #region ACAO
        #region GRID
        public void CriaGrid()
        {
            Data.Columns.Add("DESCRIÇÃO", typeof(string));
            Data.Columns.Add("UNIDADE", typeof(string));
            Data.Columns.Add("TIPO", typeof(string));
            Data.Columns.Add("INICIO", typeof(string));
            Data.Columns.Add("FIM", typeof(string));
            Data.Columns.Add("ANALISE", typeof(string));
            Data.Columns.Add("RESULTADO", typeof(string));
            Data.Columns.Add("COD", typeof(string));
        }
        public void AtualizaGrid()
        {
            if (txOF.Text != "")
            {
                string[,] select = Conn.FastSelect("select seq_et9633,cod_prop_et9633,nome_prop_et9630,unidade_prop_et9630,tipo_especif_et9630,especif_1_et9633,especif_2_et9633,resultado_et9633 from et9633 " +
                    "left join et9630 on cod_prop_et9630 = cod_prop_et9633 " +
                    "where num_of_et9633 = " + txOF.Text + " order by seq_et9633");

                if (select[0, 0] != "" && select[0, 0] != null)
                {
                    for (int i = 0; i < select.GetLength(0); i++)
                    {
                        Data.Rows.Add(select[i, 2], select[i, 3], select[i, 4], select[i, 5], select[i, 6], select[i, 7], "", select[i, 1]);
                    }
                }
                if (select[0, 0] == null) { MessageBox.Show("Peça sem cadastro de Mascara!", "Avisar PCP"); }
            }
            dataGridView1.DataSource = Data;
            dataGridView1.Columns[7].Visible = false;


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
        public void atuCB()
        {
            string[,] responsavel = Conn.FastSelect("select NOME from CADASTRO_FUNCIONARIO where COD_CC in (27,18) and ATIVO<>0 or CODIGO='000035'");
            for (int i = 0; i < responsavel.GetLength(0); i++)
            {
                cbRESP.Items.Add(responsavel[i, 0]);
            }
        }
        public void Pesquisa()//INFOS DA PEÇA
        {
            RemoveGrid();
            AtualizaGrid();
            cbRESP.SelectedIndex = -1;

            string[,] apontamentos = Conn.FastSelect($"select " +
                   $"COD_PROD, " +
                   $"descr_prd_pr5030, " +
                   $"QTDE_OF, " +
                   $"CASE WHEN STATUS_OF = 'C' THEN 'CANCELADA' " +
                   $"	WHEN STATUS_OF = 'F' THEN 'FINALIZADA' " +
                   $"	WHEN STATUS_OF = 'E' THEN 'EM ANDAMENTO' " +
                   $"	WHEN STATUS_OF = 'A' THEN 'EM ABERTO' " +
                   $"END, " +
                   $"CASE WHEN APONTAMENTO_ENTR IS NULL AND APONTAMENTO_SAI IS NULL THEN PCP_Setores_Produtivos.NOME " +
                   $"	WHEN APONTAMENTO_ENTR IS NOT NULL AND APONTAMENTO_SAI IS NULL THEN 'TRATAMENTO TÉRMICO' " +
                   $"	WHEN APONTAMENTO_ENTR IS NOT NULL AND APONTAMENTO_SAI IS NOT NULL THEN PCP_Setores_Produtivos.NOME " +
                   $"END, " +
                   $"APONTAMENTO_CQA, " +
                   $"ENTRADA_RECURSO, " +
                   $"APONTAMENTO_SAI " +
                   $",num_rnc0130" +
                   $" from PCP_Capa_OF " +
                   $" LEFT JOIN PCP_Setores_Produtivos ON PCP_Capa_OF.SETOR = PCP_Setores_Produtivos.ID " +
                   $" LEFT JOIN pr5030 on cod_prd_pr5030=COD_PROD " +
                   $"left join rnc0130 on of_rnc0130=NUM_OF" +
                   $"  where NUM_OF =" + txOF.Text);
            if (apontamentos[0, 0] != null)
            {
                txPROD.Text = apontamentos[0, 0] + " - " + apontamentos[0, 1] + "\nQUANTIDADE: " + apontamentos[0, 2];
                lbstat.Text = apontamentos[0, 3];
                lbset.Text = apontamentos[0, 4] + "   " + apontamentos[0, 5];
                txAmos.Text = apontamentos[0, 2];
                lbRNC.Text = apontamentos[0, 8];

                if (apontamentos[0, 3] != "EM ANDAMENTO")
                {
                    //btAPROVA.Enabled = false;
                    //cbRESP.Enabled = false;
                }
                else
                {
                    string[,] dtlaudo = Conn.FastSelect("select resultado_et9633,num_of_et9633 from et9633  where num_of_et9633=" + txOF.Text);
                    try
                    {
                        if (dtlaudo[0, 0] == "")
                        {
                            btAPROVA.Enabled = true;
                            cbRESP.Enabled = true;
                        }
                    }
                    catch { }
                }
                if (apontamentos[0, 4] == "CONTROLE")
                {
                    btSETOR.Enabled = false;
                }
                else
                {
                    btSETOR.Enabled = true;
                }

                TESTE();

                #region LOTE
                if (Convert.ToInt32(apontamentos[0, 2]) > 2 && Convert.ToInt32(apontamentos[0, 2]) <= 8)
                {
                    //A
                    lbVerificar.Text = "2";
                    lbReprova.Text = "1";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 8 && Convert.ToInt32(apontamentos[0, 2]) <= 15)
                {
                    //B
                    lbVerificar.Text = "3";
                    lbReprova.Text = "1";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 15 && Convert.ToInt32(apontamentos[0, 2]) <= 25)
                {
                    //C
                    lbVerificar.Text = "5";
                    lbReprova.Text = "1";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 25 && Convert.ToInt32(apontamentos[0, 2]) <= 50)
                {
                    //D
                    lbVerificar.Text = "8";
                    lbReprova.Text = "2";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 50 && Convert.ToInt32(apontamentos[0, 2]) <= 90)
                {
                    //E
                    lbVerificar.Text = "13";
                    lbReprova.Text = "2";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 90 && Convert.ToInt32(apontamentos[0, 2]) <= 150)
                {
                    //F
                    lbVerificar.Text = "20";
                    lbReprova.Text = "2";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 150 && Convert.ToInt32(apontamentos[0, 2]) <= 280)
                {
                    //G
                    lbVerificar.Text = "32";
                    lbReprova.Text = "3";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 280 && Convert.ToInt32(apontamentos[0, 2]) <= 500)
                {
                    //H
                    lbVerificar.Text = "50";
                    lbReprova.Text = "4";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 500 && Convert.ToInt32(apontamentos[0, 2]) <= 1200)
                {
                    //J
                    lbVerificar.Text = "80";
                    lbReprova.Text = "6";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 1200 && Convert.ToInt32(apontamentos[0, 2]) <= 3200)
                {
                    //K
                    lbVerificar.Text = "125";
                    lbReprova.Text = "8";
                }
                else if (Convert.ToInt32(apontamentos[0, 2]) > 3200 && Convert.ToInt32(apontamentos[0, 2]) <= 10000)
                {
                    //L
                    lbVerificar.Text = "200";
                    lbReprova.Text = "11";
                }
                else
                {
                    lbVerificar.Text = "VERIFICAR";
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "QTDE PEÇAS REPROVADAS")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = lbReprova.Text;
                    }
                }
                #endregion

                #region RPM

                string[,] RPM = Conn.FastSelect("select " +
    $"/*cod_prd_pr5030,descr_prd_pr5030,cod_fam_pa1048,L.ligante,*/" +
    $"case when pa1048.cod_fam_pa1048 = '1004'   then Round((19050*10)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1) " +
    $"when pa1048.cod_fam_pa1048 in ('1001','1003','4001','1009') and (T.TELA='N' or t.TELA is null or t.TELA ='0') then Round((19050*25)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)" +
    $"when pa1048.cod_fam_pa1048 in ('2006','2001') and l.ligante='R' then Round((19050*25)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                              " +
    $"when pa1048.cod_fam_pa1048='1002' and L.Ligante is null and cod_prd_pr5030 not like '%RUC%' then Round((19050*27)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                  " +
    $"when pa1048.cod_fam_pa1048 in ('2001') and l.ligante='LF' then Round((19050*28)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                                    " +
    $"when pa1048.cod_fam_pa1048 in ('2003','2004') and L.Ligante ='V'  then Round((19050*28)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                            " +
    $"when pa1048.cod_fam_pa1048 in ('2007','2008')  then Round((19050*28)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                                               " +
    $"when pa1048.cod_fam_pa1048 = '2002' then Round((19050*30)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                    " +
    $"when pa1048.cod_fam_pa1048 in ('2024','2026','2039','2054','2025')   then Round((19050*33)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                         " +
    $"when pa1048.cod_fam_pa1048 = '2021'   then Round((19050*35)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                                                        " +
    $"when pa1048.cod_fam_pa1048 in ('2003','2004') and L.Ligante ='B'  then Round((19050*40)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                            " +
    $"when pa1048.cod_fam_pa1048='1002' and  (cod_prd_pr5030 like '%RUC%' or cod_prd_pr5030 like '%NLD%')  then Round((19050*45)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)         " +
    $"when pa1048.cod_fam_pa1048='1009' and T.TELA='S' then Round((19050*45)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)                                                             " +
    $"when pa1048.cod_fam_pa1048 in ('2006','2005','2001','2033','2056','2037') and L.Ligante in ('B','V')  then Round((19050*45)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1)        " +
$"when pa1048.cod_fam_pa1048 in ('1007') or descr_prd_pr5030 like '%K10V%' then Round((19050*45)/convert(float,ISNULL(D1.Diametro,D2.Diametro)),1) " +
$"when pa1048.cod_fam_pa1048 in ('2028', '2020') and L.Ligante in ('B')  and(TR.TELA = 1 or TR.TELA = 0)  then Round((19050 * 60) / convert(float, ISNULL(D1.Diametro, D2.Diametro)), 1) " +
$"when pa1048.cod_fam_pa1048 in ('2028', '2020') and L.Ligante in ('B')  and TR.TELA = 2 then Round((19050 * 80) / convert(float, ISNULL(D1.Diametro, D2.Diametro)), 1) " +
$"when pa1048.cod_fam_pa1048 in ('2020') and(TR.TELA = 1 or TR.TELA = 0)  then Round((19050 * 60) / convert(float, ISNULL(D1.Diametro, D2.Diametro)), 1) " +
$"when pa1048.cod_fam_pa1048 in ('2020') and TR.TELA = 2 then Round((19050 * 80) / convert(float, ISNULL(D1.Diametro, D2.Diametro)), 1) " +
    $"                                                                                                                                                                                     " +
    $"                                                                                                                                                                                     " +
    $"end RPM                                                                                                                                                                              " +
    $"from pr5030                                                                                                                                                                          " +
    $"	left join pa1048 on pa1048.cod_prd_pa1048=pr5030.cod_prd_pr5030	                                                                                                                   " +
    $"	left join et9638 on et9638.cod_prod_et9638=pr5030.cod_prd_pr5030                                                                                                                   " +
    $"	left join PCP_Cadastro_Produto on PCP_Cadastro_Produto.PRODUTO=pr5030.cod_prd_pr5030                                                                                               " +
    $"	left join PCP_Capa_OF on PCP_Capa_OF.COD_PROD=pr5030.cod_prd_pr5030                                                                                                                " +
    $"	                                                                                                                                                                                   " +
    $"	left join (select                                                                                                                                                                  " +
    $"					cod_prd_pa2030 as 'Prod',                                                                                                                                          " +
    $"					replace(pa1035.vlr_atrib_pa1035,',','.') as 'Diametro'                                                                                                             " +
    $"				from pa1035                                                                                                                                                            " +
    $"						left join pa1032 on pa1032.index_pa1032=pa1035.comb_pa1035                                                                                                     " +
    $"						left join pa1031 on pa1031.cod_fam_pa1031=cod_fam_pa1032                                                                                                       " +
    $"						left join pa1030 on pa1030.cod_atrib_pa1030=pa1032.cod_atrib_pa1032                                                                                            " +
    $"						left join pa2030 on pa2030.index_atrib_pa2030=pa1035.index_pa1035	                                                                                           " +
    $"				where                                                                                                                                                                  " +
    $"					pa1030.cod_atrib_pa1030 = '0051'                                                                                                                                   " +
    $"			  ) as D1 on D1.Prod=pr5030.cod_prd_pr5030                                                                                                                                 " +
    $"                                                                                                                                                                                     " +
    $"	left join (select                                                                                                                                                                  " +
    $"				cod_prd_pa2031 as 'Prod',                                                                                                                                              " +
    $"				replace(vlr_comb_pa2031,',','.') as 'Diametro'                                                                                                                         " +
    $"				from pa2031									                                                                                                                           " +
    $"					left join pa1032 on pa1032.index_pa1032=pa2031.cod_comb_pa2031                                                                                                     " +
    $"					left join pa1031 on pa1031.cod_fam_pa1031=cod_fam_pa1032                                                                                                           " +
    $"					left join pa1030 on pa1030.cod_atrib_pa1030=pa1032.cod_atrib_pa1032                                                                                                " +
    $"				where pa1030.cod_atrib_pa1030 = '0001') as D2 on D2.Prod=pr5030.cod_prd_pr5030                                                                                         " +
    $"                                                                                                                                                                                     " +
    $"	left join (select                                                                                                                                                                  " +
    $"					cod_prd_pa2030 as 'Prod',                                                                                                                                          " +
    $"					pa1035.vlr_atrib_pa1035 as 'TELA'                                                                                                                                  " +
    $"				from pa1035                                                                                                                                                            " +
    $"						left join pa1032 on pa1032.index_pa1032=pa1035.comb_pa1035                                                                                                     " +
    $"						left join pa1031 on pa1031.cod_fam_pa1031=cod_fam_pa1032                                                                                                       " +
    $"						left join pa1030 on pa1030.cod_atrib_pa1030=pa1032.cod_atrib_pa1032                                                                                            " +
    $"						left join pa2030 on pa2030.index_atrib_pa2030=pa1035.index_pa1035	                                                                                           " +
    $"				where                                                                                                                                                                  " +
    $"					pa1030.cod_atrib_pa1030 = '0072'                                                                                                                                   " +
    $"			  ) as T on T.Prod=pr5030.cod_prd_pr5030                                                                                                                                   " +
    $"	left join (select                                                                                                                                                                  " +
    $"					cod_prd_pa2030 as 'Prod',                                                                                                                                          " +
    $"					pa1035.vlr_atrib_pa1035 as 'TELA'                                                                                                                                  " +
    $"				from pa1035                                                                                                                                                            " +
    $"						left join pa1032 on pa1032.index_pa1032=pa1035.comb_pa1035                                                                                                     " +
    $"						left join pa1031 on pa1031.cod_fam_pa1031=cod_fam_pa1032                                                                                                       " +
    $"						left join pa1030 on pa1030.cod_atrib_pa1030=pa1032.cod_atrib_pa1032                                                                                            " +
    $"						left join pa2030 on pa2030.index_atrib_pa2030=pa1035.index_pa1035	                                                                                           " +
    $"				where                                                                                                                                                                  " +
    $"					pa1030.cod_atrib_pa1030 = '0019'                                                                                                                                   " +
    $"			  ) as TR on TR.Prod=pr5030.cod_prd_pr5030                                                                                                                                 " +
    $"                                                                                                                                                                                     " +
    $"	left join (select                                                                                                                                                                  " +
    $"					cod_prd_pa2030 as 'Prod',                                                                                                                                          " +
    $"					pa1035.vlr_atrib_pa1035 as 'base'                                                                                                                                  " +
    $"				from pa1035                                                                                                                                                            " +
    $"						left join pa1032 on pa1032.index_pa1032=pa1035.comb_pa1035                                                                                                     " +
    $"						left join pa1031 on pa1031.cod_fam_pa1031=cod_fam_pa1032                                                                                                       " +
    $"						left join pa1030 on pa1030.cod_atrib_pa1030=pa1032.cod_atrib_pa1032                                                                                            " +
    $"						left join pa2030 on pa2030.index_atrib_pa2030=pa1035.index_pa1035	                                                                                           " +
    $"				where                                                                                                                                                                  " +
    $"					pa1030.cod_atrib_pa1030 = '0024'                                                                                                                                   " +
    $"			  ) as B on B.Prod=pr5030.cod_prd_pr5030                                                                                                                                   " +
    $"                                                                                                                                                                                     " +
    $"			  left join (select                                                                                                                                                        " +
    $"					cod_prd_pa2030 as 'Prod',                                                                                                                                          " +
    $"					pa1035.vlr_atrib_pa1035 as 'ligante'                                                                                                                               " +
    $"				from pa1035                                                                                                                                                            " +
    $"						left join pa1032 on pa1032.index_pa1032=pa1035.comb_pa1035                                                                                                     " +
    $"						left join pa1031 on pa1031.cod_fam_pa1031=cod_fam_pa1032                                                                                                       " +
    $"						left join pa1030 on pa1030.cod_atrib_pa1030=pa1032.cod_atrib_pa1032                                                                                            " +
    $"						left join pa2030 on pa2030.index_atrib_pa2030=pa1035.index_pa1035	                                                                                           " +
    $"				where                                                                                                                                                                  " +
    $"					pa1030.cod_atrib_pa1030 = '0040'                                                                                                                                   " +
    $"			  ) as L on L.Prod=pr5030.cod_prd_pr5030                                                                                                                                   " +
    $"                                                                                                                                                                                     " +
    $"where  pr5030.prd_ativo_pr5030='S' and id_prd_pr5030 =1    and cod_prd_pr5030='" + apontamentos[0, 0] + "' " +
    $"group by descr_prd_pr5030,pr5030.cod_prd_pr5030,D1.Diametro,D2.Diametro,pa1048.cod_fam_pa1048,t.TELA,B.base,L.ligante,TR.TELA                                                        ");

                lbRPM.Text = "";
                lbRPMT.Text = "";
                if (RPM[0, 0] != null && RPM[0, 0] != "")
                {
                    lbRPM.Text = RPM[0, 0];
                    lbRPMT.Text = (float.Parse(RPM[0, 0]) * 1.4).ToString("0.00");
                }
                #endregion

                #region RESPONSAVEL
                txDESVIO.Text = "";
                string[,] resp = Conn.FastSelect("select respons_cq_et9830,observ_cq_et9830 from et9830 where num_of_et9830=" + txOF.Text);
                if (resp[0, 0] != "" && resp[0, 0] != null)
                {
                    string[,] nome = Conn.FastSelect("select NOME from CADASTRO_FUNCIONARIO where CODIGO='" + resp[0, 0] + "'");
                    cbRESP.SelectedItem = nome[0, 0];
                    txDESVIO.Text = resp[0, 1];
                }

                #endregion
            }
        }
        public void TESTE()//TESTE DE COTAS
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() != "" && dataGridView1.Rows[i].Cells[5].Value != null)
                {
                    try
                    {

                        if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "R")
                        {
                            if (float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString().Replace(".", ",")) >= float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString().Replace(".", ",")) &&
                                float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString().Replace(".", ",")) <= float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(".", ",")))
                            {
                                dataGridView1.Rows[i].Cells[6].Value = "APROVADO";
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[6].Value = "REPROVADO";
                            }
                        }
                        else
                        {
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "DATA DE RECEBIMENTO")//FORÇA FORMATO DATA
                            {
                                if (DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) >= DateTime.Today)
                                {
                                    dataGridView1.Rows[i].Cells[5].Value = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()).ToString("dd/MM/yyyy");
                                }
                            }

                            if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "PESO FINAL DA PEÇA")//JOGA PESO PRA TESTE
                            {
                                txPeso.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

                                KeyPressEventArgs press = new KeyPressEventArgs((char)Keys.Enter);
                                txPeso_KeyPress(this, press);
                            }

                            dataGridView1.Rows[i].Cells[6].Value = "APROVADO";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Valor invalido!");
                        int a = dataGridView1.SelectedCells[0].RowIndex;
                        dataGridView1.Rows[a].Cells[5].Value = "";
                        dataGridView1.Rows[a].Cells[6].Value = "";
                    }
                }
            }
        }
        #endregion

        #region MAGIA
        private void txOF_KeyPress(object sender, KeyPressEventArgs e)//PESQUISA
        {
            txPeso.Text = "";
            if (!char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar))//NUMERO
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)//ENTER
            {
                e.Handled = true;

                txPeso.Text = "";
                string[,] info = Conn.FastSelect("select COD_PROD from PCP_CAPA_OF where STATUS_OF = 'E' and NUM_OF=" + txOF.Text);
                Conn.Play("update pr5030 set contr_qual_pr5030='S' where cod_prd_pr5030='" + info[0, 0] + "'", "", "");

                string[,] confere = Conn.FastSelect("select * from et9633 where num_of_et9633=" + txOF.Text);

                if (confere[0, 0] == null && info[0, 0] != null)
                {
                    Conn.Play("", "insert into et9633 (cod_emp_et9633,cod_fil_et9633,num_of_et9633,cod_proc_et9633,cod_prop_et9633,especif_1_et9633,especif_2_et9633,metodo_et9633,resultado_et9633,status_et9633,seq_et9633,usu_laudo_et9633,data_laudo_et9633,hora_laudo_et9633)" +
                        " select '01', '01', " + txOF.Text + ", cod_proc_et9631, cod_prop_et9631, especif_1_et9631, especif_2_et9631, metodo_et9631, null, '', seq_et9631, '0043', GETDATE(), GETDATE() from et9631 where cod_prod_et9631 = '" + info[0, 0] + "' order by seq_et9631", "");
                }

                Pesquisa();
            }
        }
        private void txPeso_KeyPress(object sender, KeyPressEventArgs e)//CALCULA PESO
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar))//NUMERO
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)//ENTER
            {
                e.Handled = true;


                string[,] select = Conn.FastSelect($"select " +
                $"num_of,cod_prd_pr5030, descr_prd_pr5030, " +
                $"ISNULL(DIAM.VALOR, DIAMDISCR.VALOR) as DIAMETRO " +
                $", case when isnull(LIGANTE.vlr_atrib_pa1035,'R') = 'V' and(FAMILIA.descr_fam_pa1031 like '%COPO%' OR FAMILIA.descr_fam_pa1031 like '%PIRES%' OR FAMILIA.descr_fam_pa1031 like '%PRATO%') " +
                $"THEN(19050 * 28) " +
                $"    when isnull(LIGANTE.vlr_atrib_pa1035,'R') = 'V' and descr_prd_pr5030 LIKE '%K10V-10%' THEN(19050 * 30) " +
                $"    when isnull(LIGANTE.vlr_atrib_pa1035,'R') = 'B' and FAMILIA.descr_fam_pa1031 like '%COPO%' THEN(19050 * 40) " +
                $"    when isnull(LIGANTE.vlr_atrib_pa1035,'R') IN('V', 'B')  and" +
                $"(FAMILIA.descr_fam_pa1031 like '%RETO%' or FAMILIA.descr_fam_pa1031 like '%DL%' OR FAMILIA.descr_fam_pa1031 like '%UL%' OR FAMILIA.descr_fam_pa1031 like '%SAND%' OR " +
                $"FAMILIA.descr_fam_pa1031 like '%CÔNCAVO%') THEN(19050 * 45) " +
                $"    ELSE 0 " +
                $"    END AS USORPM " +
                $",isnull(LIGANTE.vlr_atrib_pa1035, 'R') AS LIGANTE " +
                $" , FAMILIA.descr_fam_pa1031 " +
                $",CASE WHEN descr_prd_pr5030 LIKE '%K10V-10%' THEN 'KV10'ELSE '' END AS KV10" +
                $"   from PCP_Capa_OF " +
                $"   left join pr5030 on COD_PROD = cod_prd_pr5030 " +
                $"left join(select cod_prd_pa2030, replace(vlr_atrib_pa1035,'.',',') AS VALOR, descr_atrib_pa1030 from pa2030 " +
                $" left join pa1035 on index_atrib_pa2030 = index_pa1035 " +
                $" left join pa1032 on index_pa1032 = comb_pa1035 " +
                $" left join pa1030 on cod_atrib_pa1032 = cod_atrib_pa1030 " +
                $" where cod_atrib_pa1032 = '0051' ) as DIAMDISCR ON DIAMDISCR.cod_prd_pa2030 = cod_prd_pr5030 " +
                $"left join(select cod_prd_pa2031, replace(vlr_comb_pa2031,'.',',') AS VALOR, descr_atrib_pa1030 from pa2031 " +
                $" left join pa1032 on cod_comb_pa2031 = index_pa1032 " +
                $" left join pa1030 on cod_atrib_pa1030 = cod_atrib_pa1032 " +
                $" where cod_atrib_pa1032 = '0001' ) as DIAM ON DIAM.cod_prd_pa2031 = cod_prd_pr5030 " +
                $"LEFT JOIN(select cod_prd_pa2030, vlr_atrib_pa1035 from pa2030 " +
                $"            left join pa1035 on index_atrib_pa2030 = index_pa1035      " +
                $"            left join pa1032 on index_pa1032 = comb_pa1035 " +
                $"            left join pa1030 on cod_atrib_pa1032 = cod_atrib_pa1030 " +
                $"            where cod_atrib_pa1032 = '0040') AS LIGANTE ON LIGANTE.cod_prd_pa2030 = cod_prd_pr5030 " +
                $"LEFT JOIN(select cod_prd_pa1048, descr_fam_pa1031 from  PA1048 " +
                $"            left join pa1031 on cod_fam_pa1031 = cod_fam_pa1048) AS FAMILIA ON FAMILIA.cod_prd_pa1048 = cod_prd_pr5030 " +
                $"LEFT JOIN PCP_Cadastro_Produto ON PCP_Cadastro_Produto.PRODUTO = cod_prd_pr5030 " +
                $"where num_of = " + txOF.Text +
                $"order by 5");

                if (txPeso.Text != "")
                {
                    if (select[0, 3] != "")
                    {
                        double peso = 0.0;

                        peso = Convert.ToDouble(txPeso.Text.Replace(",", "."));

                        if (select[0, 5] == "R")
                        {
                            lbDesb.Text = "VERIFICAR";
                        }
                        else if (select[0, 7] == "KV10")
                        {
                            if (Convert.ToDouble(select[0, 3]) > 175 && Convert.ToDouble(select[0, 3]) <= 300)
                            {
                                lbDesb.Text = (Math.Sqrt(peso) * 0.25).ToString("##.00");
                            }
                            else if (Convert.ToDouble(select[0, 3]) > 300 && Convert.ToDouble(select[0, 3]) <= 610)
                            {
                                lbDesb.Text = (Math.Sqrt(peso) * 0.32).ToString("##.00");
                            }
                            else if (Convert.ToDouble(select[0, 3]) > 610)
                            {
                                lbDesb.Text = (Math.Sqrt(peso) * 0.40).ToString("##.00");
                            }
                            else
                            {
                                lbDesb.Text = "VERIFICAR";
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(select[0, 3]) > 175 && Convert.ToDouble(select[0, 3]) <= 300)
                            {
                                lbDesb.Text = (Math.Sqrt(peso) * 0.20).ToString("##.00");
                            }
                            else if (Convert.ToDouble(select[0, 3]) > 300 && Convert.ToDouble(select[0, 3]) <= 610)
                            {
                                lbDesb.Text = (Math.Sqrt(peso) * 0.25).ToString("##.00");
                            }
                            else if (Convert.ToDouble(select[0, 3]) > 610)
                            {
                                lbDesb.Text = (Math.Sqrt(peso) * 0.32).ToString("##.00");
                            }
                            else
                            {
                                lbDesb.Text = "VERIFICAR";
                            }
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TESTE();
        }
        private void txAmos_KeyPress(object sender, KeyPressEventArgs e)//LOTE MANUAL
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar))//NUMERO
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)//ENTER
            {
                e.Handled = true;

                #region LOTE
                if (Convert.ToInt32(txAmos.Text) > 2 && Convert.ToInt32(txAmos.Text) <= 8)
                {
                    //A
                    lbVerificar.Text = "2";
                    lbReprova.Text = "1";
                }
                else if (Convert.ToInt32(txAmos.Text) > 8 && Convert.ToInt32(txAmos.Text) <= 15)
                {
                    //B
                    lbVerificar.Text = "3";
                    lbReprova.Text = "1";
                }
                else if (Convert.ToInt32(txAmos.Text) > 15 && Convert.ToInt32(txAmos.Text) <= 25)
                {
                    //C
                    lbVerificar.Text = "5";
                    lbReprova.Text = "1";
                }
                else if (Convert.ToInt32(txAmos.Text) > 25 && Convert.ToInt32(txAmos.Text) <= 50)
                {
                    //D
                    lbVerificar.Text = "8";
                    lbReprova.Text = "2";
                }
                else if (Convert.ToInt32(txAmos.Text) > 50 && Convert.ToInt32(txAmos.Text) <= 90)
                {
                    //E
                    lbVerificar.Text = "13";
                    lbReprova.Text = "2";
                }
                else if (Convert.ToInt32(txAmos.Text) > 90 && Convert.ToInt32(txAmos.Text) <= 150)
                {
                    //F
                    lbVerificar.Text = "20";
                    lbReprova.Text = "2";
                }
                else if (Convert.ToInt32(txAmos.Text) > 150 && Convert.ToInt32(txAmos.Text) <= 280)
                {
                    //G
                    lbVerificar.Text = "32";
                    lbReprova.Text = "3";
                }
                else if (Convert.ToInt32(txAmos.Text) > 280 && Convert.ToInt32(txAmos.Text) <= 500)
                {
                    //H
                    lbVerificar.Text = "50";
                    lbReprova.Text = "4";
                }
                else if (Convert.ToInt32(txAmos.Text) > 500 && Convert.ToInt32(txAmos.Text) <= 1200)
                {
                    //J
                    lbVerificar.Text = "80";
                    lbReprova.Text = "6";
                }
                else if (Convert.ToInt32(txAmos.Text) > 1200 && Convert.ToInt32(txAmos.Text) <= 3200)
                {
                    //K
                    lbVerificar.Text = "125";
                    lbReprova.Text = "8";
                }
                else if (Convert.ToInt32(txAmos.Text) > 3200 && Convert.ToInt32(txAmos.Text) <= 10000)
                {
                    //L
                    lbVerificar.Text = "200";
                    lbReprova.Text = "11";
                }
                else
                {
                    lbVerificar.Text = "VERIFICAR";
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "QTDE PEÇAS REPROVADAS")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = lbReprova.Text;
                    }
                }
                #endregion
            }
        }

        #endregion

        
    }
}
