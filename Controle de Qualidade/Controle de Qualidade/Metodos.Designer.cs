
namespace Controle_de_Qualidade
{
    partial class Metodos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Metodos));
            this.label1 = new System.Windows.Forms.Label();
            this.cbPROC = new System.Windows.Forms.ComboBox();
            this.txSEQ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCOD = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txFIM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txINICIO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txDESVIO = new System.Windows.Forms.TextBox();
            this.cbMETODO = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btADICIONA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROCESSO";
            // 
            // cbPROC
            // 
            this.cbPROC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPROC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPROC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPROC.FormattingEnabled = true;
            this.cbPROC.Location = new System.Drawing.Point(92, 44);
            this.cbPROC.Name = "cbPROC";
            this.cbPROC.Size = new System.Drawing.Size(271, 21);
            this.cbPROC.TabIndex = 1;
            // 
            // txSEQ
            // 
            this.txSEQ.Location = new System.Drawing.Point(50, 11);
            this.txSEQ.Name = "txSEQ";
            this.txSEQ.Size = new System.Drawing.Size(44, 20);
            this.txSEQ.TabIndex = 2;
            this.txSEQ.Text = "000";
            this.txSEQ.Leave += new System.EventHandler(this.txSEQ_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SEQ";
            // 
            // cbCOD
            // 
            this.cbCOD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCOD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOD.FormattingEnabled = true;
            this.cbCOD.Location = new System.Drawing.Point(92, 73);
            this.cbCOD.Name = "cbCOD";
            this.cbCOD.Size = new System.Drawing.Size(271, 21);
            this.cbCOD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CODIGO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "ESPECIFICAÇÃO FINAL";
            // 
            // txFIM
            // 
            this.txFIM.Location = new System.Drawing.Point(163, 127);
            this.txFIM.Name = "txFIM";
            this.txFIM.Size = new System.Drawing.Size(200, 20);
            this.txFIM.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "ESPECIFICAÇÃO INICIAL";
            // 
            // txINICIO
            // 
            this.txINICIO.Location = new System.Drawing.Point(163, 100);
            this.txINICIO.Name = "txINICIO";
            this.txINICIO.Size = new System.Drawing.Size(200, 20);
            this.txINICIO.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "DESVIO";
            // 
            // txDESVIO
            // 
            this.txDESVIO.Location = new System.Drawing.Point(71, 152);
            this.txDESVIO.Name = "txDESVIO";
            this.txDESVIO.Size = new System.Drawing.Size(92, 20);
            this.txDESVIO.TabIndex = 12;
            this.txDESVIO.Text = "0";
            // 
            // cbMETODO
            // 
            this.cbMETODO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMETODO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMETODO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMETODO.FormattingEnabled = true;
            this.cbMETODO.Location = new System.Drawing.Point(72, 178);
            this.cbMETODO.Name = "cbMETODO";
            this.cbMETODO.Size = new System.Drawing.Size(158, 21);
            this.cbMETODO.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "MÉTODO";
            // 
            // btADICIONA
            // 
            this.btADICIONA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btADICIONA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btADICIONA.Location = new System.Drawing.Point(312, 209);
            this.btADICIONA.Name = "btADICIONA";
            this.btADICIONA.Size = new System.Drawing.Size(75, 23);
            this.btADICIONA.TabIndex = 16;
            this.btADICIONA.Text = "ADICIONA";
            this.btADICIONA.UseVisualStyleBackColor = true;
            this.btADICIONA.Click += new System.EventHandler(this.btADICIONA_Click);
            // 
            // Metodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 244);
            this.Controls.Add(this.btADICIONA);
            this.Controls.Add(this.cbMETODO);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txDESVIO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txINICIO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txFIM);
            this.Controls.Add(this.cbCOD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txSEQ);
            this.Controls.Add(this.cbPROC);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Metodos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Métodos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Metodos_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPROC;
        private System.Windows.Forms.TextBox txSEQ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCOD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txFIM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txINICIO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txDESVIO;
        private System.Windows.Forms.ComboBox cbMETODO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btADICIONA;
    }
}