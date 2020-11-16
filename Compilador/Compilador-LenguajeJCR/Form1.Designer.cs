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
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxCodigoFuente
            // 
            this.rtxCodigoFuente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.rtxCodigoFuente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxCodigoFuente.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxCodigoFuente.ForeColor = System.Drawing.Color.Aqua;
            this.rtxCodigoFuente.Location = new System.Drawing.Point(44, 0);
            this.rtxCodigoFuente.Name = "rtxCodigoFuente";
            this.rtxCodigoFuente.Size = new System.Drawing.Size(371, 364);
            this.rtxCodigoFuente.TabIndex = 0;
            this.rtxCodigoFuente.Text = "";
            this.rtxCodigoFuente.SelectionChanged += new System.EventHandler(this.rtxCodigoFuente_SelectionChanged);
            this.rtxCodigoFuente.VScroll += new System.EventHandler(this.rtxCodigoFuente_VScroll);
            this.rtxCodigoFuente.TextChanged += new System.EventHandler(this.rtxCodigoFuente_TextChanged);
            this.rtxCodigoFuente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxCodigoFuente_KeyDown);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(177, 11);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(65, 23);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Iniciar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(621, 16);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(89, 23);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "TOKENS";
            // 
            // rtxTokens
            // 
            this.rtxTokens.Location = new System.Drawing.Point(421, 0);
            this.rtxTokens.Name = "rtxTokens";
            this.rtxTokens.Size = new System.Drawing.Size(382, 364);
            this.rtxTokens.TabIndex = 3;
            this.rtxTokens.Text = "";
            this.rtxTokens.TextChanged += new System.EventHandler(this.rtxTokens_TextChanged);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(85, 10);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(86, 24);
            this.btnCargar.TabIndex = 4;
            this.btnCargar.Text = "Cargar Archivo";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(731, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // lsbSimbolos
            // 
            this.lsbSimbolos.FormattingEnabled = true;
            this.lsbSimbolos.Location = new System.Drawing.Point(306, 28);
            this.lsbSimbolos.Name = "lsbSimbolos";
            this.lsbSimbolos.Size = new System.Drawing.Size(266, 95);
            this.lsbSimbolos.TabIndex = 6;
            // 
            // lblSimbolos
            // 
            this.lblSimbolos.AutoSize = true;
            this.lblSimbolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimbolos.Location = new System.Drawing.Point(306, 5);
            this.lblSimbolos.Name = "lblSimbolos";
            this.lblSimbolos.Size = new System.Drawing.Size(159, 20);
            this.lblSimbolos.TabIndex = 7;
            this.lblSimbolos.Text = "Tabla De Simbolos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Errores:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(300, 92);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineNumberTextBox.ForeColor = System.Drawing.Color.Lime;
            this.LineNumberTextBox.Location = new System.Drawing.Point(0, 0);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.Size = new System.Drawing.Size(38, 364);
            this.LineNumberTextBox.TabIndex = 10;
            this.LineNumberTextBox.Text = "";
            this.LineNumberTextBox.FontChanged += new System.EventHandler(this.LineNumberTextBox_FontChanged);
            this.LineNumberTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LineNumberTextBox_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAnalizar);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 40);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.LineNumberTextBox);
            this.panel2.Controls.Add(this.rtxCodigoFuente);
            this.panel2.Controls.Add(this.rtxTokens);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 488);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Controls.Add(this.lsbSimbolos);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblText);
            this.panel3.Controls.Add(this.lblSimbolos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 362);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 126);
            this.panel3.TabIndex = 11;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save Code";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Guardar TOKENS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmLJCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 528);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmLJCR";
            this.Text = "LENGUAJE JCR";
            this.Resize += new System.EventHandler(this.frmLJCR_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

