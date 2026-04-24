
namespace Logos_Rotulagem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txCOD = new System.Windows.Forms.TextBox();
            this.btCAD = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbDESCR = new System.Windows.Forms.Label();
            this.cbLOGO = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txDESCR = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CODIGO";
            // 
            // txCOD
            // 
            this.txCOD.Location = new System.Drawing.Point(96, 6);
            this.txCOD.Name = "txCOD";
            this.txCOD.Size = new System.Drawing.Size(125, 20);
            this.txCOD.TabIndex = 1;
            this.txCOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txCOD_KeyPress);
            // 
            // btCAD
            // 
            this.btCAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCAD.Location = new System.Drawing.Point(12, 121);
            this.btCAD.Name = "btCAD";
            this.btCAD.Size = new System.Drawing.Size(104, 23);
            this.btCAD.TabIndex = 2;
            this.btCAD.Text = "CADASTRAR";
            this.btCAD.UseVisualStyleBackColor = true;
            this.btCAD.Click += new System.EventHandler(this.btCAD_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(815, 169);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // lbDESCR
            // 
            this.lbDESCR.AutoSize = true;
            this.lbDESCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDESCR.Location = new System.Drawing.Point(227, 9);
            this.lbDESCR.Name = "lbDESCR";
            this.lbDESCR.Size = new System.Drawing.Size(0, 13);
            this.lbDESCR.TabIndex = 4;
            // 
            // cbLOGO
            // 
            this.cbLOGO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLOGO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLOGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLOGO.FormattingEnabled = true;
            this.cbLOGO.Location = new System.Drawing.Point(96, 35);
            this.cbLOGO.Name = "cbLOGO";
            this.cbLOGO.Size = new System.Drawing.Size(125, 21);
            this.cbLOGO.TabIndex = 5;
            this.cbLOGO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLOGO_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "LOGO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DESCRIÇÃO";
            // 
            // txDESCR
            // 
            this.txDESCR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txDESCR.Location = new System.Drawing.Point(96, 62);
            this.txDESCR.Name = "txDESCR";
            this.txDESCR.Size = new System.Drawing.Size(731, 53);
            this.txDESCR.TabIndex = 9;
            this.txDESCR.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 334);
            this.Controls.Add(this.txDESCR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLOGO);
            this.Controls.Add(this.lbDESCR);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btCAD);
            this.Controls.Add(this.txCOD);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE LOGOS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txCOD;
        private System.Windows.Forms.Button btCAD;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbDESCR;
        private System.Windows.Forms.ComboBox cbLOGO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txDESCR;
    }
}

