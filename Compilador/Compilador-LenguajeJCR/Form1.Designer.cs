namespace Compilador_LenguajeJCR
{
    partial class frmLJCR
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtxCodigoFuente = new System.Windows.Forms.RichTextBox();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.rtxTokens = new System.Windows.Forms.RichTextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbSimbolos = new System.Windows.Forms.ListBox();
            this.lblSimbolos = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxCodigoFuente
            // 
            this.rtxCodigoFuente.Location = new System.Drawing.Point(12, 15);
            this.rtxCodigoFuente.Name = "rtxCodigoFuente";
            this.rtxCodigoFuente.Size = new System.Drawing.Size(523, 131);
            this.rtxCodigoFuente.TabIndex = 0;
            this.rtxCodigoFuente.Text = "";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(641, 75);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(77, 24);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(12, 191);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(89, 23);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "TOKENS";
            // 
            // rtxTokens
            // 
            this.rtxTokens.Location = new System.Drawing.Point(12, 245);
            this.rtxTokens.Name = "rtxTokens";
            this.rtxTokens.Size = new System.Drawing.Size(523, 138);
            this.rtxTokens.TabIndex = 3;
            this.rtxTokens.Text = "";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(641, 15);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(77, 41);
            this.btnCargar.TabIndex = 4;
            this.btnCargar.Text = "Cargar Archivo";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(588, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // lsbSimbolos
            // 
            this.lsbSimbolos.FormattingEnabled = true;
            this.lsbSimbolos.Location = new System.Drawing.Point(608, 245);
            this.lsbSimbolos.Name = "lsbSimbolos";
            this.lsbSimbolos.Size = new System.Drawing.Size(171, 134);
            this.lsbSimbolos.TabIndex = 6;
            // 
            // lblSimbolos
            // 
            this.lblSimbolos.AutoSize = true;
            this.lblSimbolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimbolos.Location = new System.Drawing.Point(604, 212);
            this.lblSimbolos.Name = "lblSimbolos";
            this.lblSimbolos.Size = new System.Drawing.Size(159, 20);
            this.lblSimbolos.TabIndex = 7;
            this.lblSimbolos.Text = "Tabla De Simbolos";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(211, 178);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(143, 34);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmLJCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblSimbolos);
            this.Controls.Add(this.lsbSimbolos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.rtxTokens);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.rtxCodigoFuente);
            this.Name = "frmLJCR";
            this.Text = "LENGUAJE JCR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxCodigoFuente;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.RichTextBox rtxTokens;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbSimbolos;
        private System.Windows.Forms.Label lblSimbolos;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
    }
}

