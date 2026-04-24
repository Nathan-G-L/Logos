
namespace Controle_de_Qualidade
{
    partial class CQ
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CQ));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txOF = new System.Windows.Forms.TextBox();
            this.btAPROVA = new System.Windows.Forms.Button();
            this.btMASK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbstat = new System.Windows.Forms.Label();
            this.lbset = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btSETOR = new System.Windows.Forms.Button();
            this.lbReprova = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbVerificar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txPeso = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDesb = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRPM = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbRPMT = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txAmos = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRNC = new System.Windows.Forms.Label();
            this.cbRESP = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txPROD = new System.Windows.Forms.RichTextBox();
            this.btDESVIO = new System.Windows.Forms.Button();
            this.txDESVIO = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1226, 346);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "OF";
            // 
            // txOF
            // 
            this.txOF.Location = new System.Drawing.Point(41, 5);
            this.txOF.Name = "txOF";
            this.txOF.Size = new System.Drawing.Size(100, 20);
            this.txOF.TabIndex = 0;
            this.txOF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txOF_KeyPress);
            // 
            // btAPROVA
            // 
            this.btAPROVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAPROVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAPROVA.Location = new System.Drawing.Point(1163, 402);
            this.btAPROVA.Name = "btAPROVA";
            this.btAPROVA.Size = new System.Drawing.Size(75, 70);
            this.btAPROVA.TabIndex = 5;
            this.btAPROVA.Text = "APROVA";
            this.btAPROVA.UseVisualStyleBackColor = true;
            this.btAPROVA.Click += new System.EventHandler(this.btAPROVA_Click);
            // 
            // btMASK
            // 
            this.btMASK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btMASK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMASK.ForeColor = System.Drawing.Color.DarkOrange;
            this.btMASK.Location = new System.Drawing.Point(524, -6);
            this.btMASK.Name = "btMASK";
            this.btMASK.Size = new System.Drawing.Size(94, 44);
            this.btMASK.TabIndex = 4;
            this.btMASK.Text = "MÁSCARA";
            this.btMASK.UseVisualStyleBackColor = true;
            this.btMASK.Visible = false;
            this.btMASK.Click += new System.EventHandler(this.btMASK_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "STATUS:";
            // 
            // lbstat
            // 
            this.lbstat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbstat.AutoSize = true;
            this.lbstat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstat.Location = new System.Drawing.Point(62, 16);
            this.lbstat.Name = "lbstat";
            this.lbstat.Size = new System.Drawing.Size(56, 13);
            this.lbstat.TabIndex = 6;
            this.lbstat.Text = "STATUS";
            // 
            // lbset
            // 
            this.lbset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbset.AutoSize = true;
            this.lbset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbset.Location = new System.Drawing.Point(62, 36);
            this.lbset.Name = "lbset";
            this.lbset.Size = new System.Drawing.Size(49, 13);
            this.lbset.TabIndex = 8;
            this.lbset.Text = "SETOR";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "SETOR:";
            // 
            // btSETOR
            // 
            this.btSETOR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSETOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSETOR.ForeColor = System.Drawing.Color.Red;
            this.btSETOR.Location = new System.Drawing.Point(12, 407);
            this.btSETOR.Name = "btSETOR";
            this.btSETOR.Size = new System.Drawing.Size(94, 62);
            this.btSETOR.TabIndex = 2;
            this.btSETOR.Text = "APONTA SETOR";
            this.btSETOR.UseVisualStyleBackColor = true;
            this.btSETOR.Click += new System.EventHandler(this.btSETOR_Click);
            // 
            // lbReprova
            // 
            this.lbReprova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbReprova.AutoSize = true;
            this.lbReprova.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReprova.ForeColor = System.Drawing.Color.Red;
            this.lbReprova.Location = new System.Drawing.Point(80, 60);
            this.lbReprova.Name = "lbReprova";
            this.lbReprova.Size = new System.Drawing.Size(14, 13);
            this.lbReprova.TabIndex = 14;
            this.lbReprova.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "REPROVAR:";
            // 
            // lbVerificar
            // 
            this.lbVerificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVerificar.AutoSize = true;
            this.lbVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVerificar.Location = new System.Drawing.Point(80, 40);
            this.lbVerificar.Name = "lbVerificar";
            this.lbVerificar.Size = new System.Drawing.Size(14, 13);
            this.lbVerificar.TabIndex = 12;
            this.lbVerificar.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "VERIFICAR:";
            // 
            // txPeso
            // 
            this.txPeso.Location = new System.Drawing.Point(6, 17);
            this.txPeso.Name = "txPeso";
            this.txPeso.Size = new System.Drawing.Size(145, 20);
            this.txPeso.TabIndex = 4;
            this.txPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txPeso_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "DESBALANCEAMENTO MÁXIMO:";
            // 
            // lbDesb
            // 
            this.lbDesb.AutoSize = true;
            this.lbDesb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesb.Location = new System.Drawing.Point(73, 53);
            this.lbDesb.Name = "lbDesb";
            this.lbDesb.Size = new System.Drawing.Size(0, 13);
            this.lbDesb.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "USO:";
            // 
            // lbRPM
            // 
            this.lbRPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRPM.AutoSize = true;
            this.lbRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPM.Location = new System.Drawing.Point(57, 16);
            this.lbRPM.Name = "lbRPM";
            this.lbRPM.Size = new System.Drawing.Size(0, 13);
            this.lbRPM.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "TESTE:";
            // 
            // lbRPMT
            // 
            this.lbRPMT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRPMT.AutoSize = true;
            this.lbRPMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPMT.Location = new System.Drawing.Point(57, 36);
            this.lbRPMT.Name = "lbRPMT";
            this.lbRPMT.Size = new System.Drawing.Size(0, 13);
            this.lbRPMT.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lbset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbstat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(112, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 79);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STATUS";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.txAmos);
            this.groupBox2.Controls.Add(this.lbReprova);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbVerificar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(441, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 79);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AMOSTRAGEM";
            // 
            // txAmos
            // 
            this.txAmos.Location = new System.Drawing.Point(9, 17);
            this.txAmos.Name = "txAmos";
            this.txAmos.Size = new System.Drawing.Size(85, 20);
            this.txAmos.TabIndex = 3;
            this.txAmos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txAmos_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.txPeso);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lbDesb);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(739, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 79);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BALANCEAMENTO";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lbRPM);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.lbRPMT);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(599, 396);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(133, 79);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RPM";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1141, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "RNC:";
            // 
            // lbRNC
            // 
            this.lbRNC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRNC.AutoSize = true;
            this.lbRNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRNC.Location = new System.Drawing.Point(1174, 9);
            this.lbRNC.Name = "lbRNC";
            this.lbRNC.Size = new System.Drawing.Size(0, 13);
            this.lbRNC.TabIndex = 27;
            // 
            // cbRESP
            // 
            this.cbRESP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRESP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRESP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRESP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRESP.FormattingEnabled = true;
            this.cbRESP.Location = new System.Drawing.Point(915, 5);
            this.cbRESP.Name = "cbRESP";
            this.cbRESP.Size = new System.Drawing.Size(220, 21);
            this.cbRESP.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(812, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "RESPONSAVEL";
            // 
            // txPROD
            // 
            this.txPROD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txPROD.BackColor = System.Drawing.SystemColors.Control;
            this.txPROD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txPROD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPROD.Location = new System.Drawing.Point(147, 4);
            this.txPROD.Name = "txPROD";
            this.txPROD.ReadOnly = true;
            this.txPROD.Size = new System.Drawing.Size(659, 34);
            this.txPROD.TabIndex = 30;
            this.txPROD.Text = "PRODUTO";
            // 
            // btDESVIO
            // 
            this.btDESVIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDESVIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDESVIO.Location = new System.Drawing.Point(1057, 402);
            this.btDESVIO.Name = "btDESVIO";
            this.btDESVIO.Size = new System.Drawing.Size(100, 23);
            this.btDESVIO.TabIndex = 31;
            this.btDESVIO.Text = "OBSERVAÇÃO";
            this.btDESVIO.UseVisualStyleBackColor = true;
            this.btDESVIO.Click += new System.EventHandler(this.btDESVIO_Click);
            // 
            // txDESVIO
            // 
            this.txDESVIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txDESVIO.Location = new System.Drawing.Point(1057, 425);
            this.txDESVIO.Name = "txDESVIO";
            this.txDESVIO.ReadOnly = true;
            this.txDESVIO.Size = new System.Drawing.Size(100, 44);
            this.txDESVIO.TabIndex = 32;
            this.txDESVIO.Text = "";
            // 
            // CQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 478);
            this.Controls.Add(this.txDESVIO);
            this.Controls.Add(this.btDESVIO);
            this.Controls.Add(this.txPROD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbRESP);
            this.Controls.Add(this.lbRNC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSETOR);
            this.Controls.Add(this.btMASK);
            this.Controls.Add(this.btAPROVA);
            this.Controls.Add(this.txOF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Qualidade ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txOF;
        private System.Windows.Forms.Button btAPROVA;
        private System.Windows.Forms.Button btMASK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbstat;
        private System.Windows.Forms.Label lbset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSETOR;
        private System.Windows.Forms.Label lbReprova;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbVerificar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txPeso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbDesb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRPM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbRPMT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txAmos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRNC;
        private System.Windows.Forms.ComboBox cbRESP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txPROD;
        private System.Windows.Forms.Button btDESVIO;
        private System.Windows.Forms.RichTextBox txDESVIO;
    }
}

