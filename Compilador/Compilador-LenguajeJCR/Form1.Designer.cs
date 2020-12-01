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
            this.rtxTokens = new System.Windows.Forms.RichTextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lsbSimbolos = new System.Windows.Forms.ListBox();
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTokens = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSimbolos = new System.Windows.Forms.Button();
            this.lblListaSim = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.rtxErrores = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxCodigoFuente
            // 
            this.rtxCodigoFuente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.rtxCodigoFuente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxCodigoFuente.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxCodigoFuente.ForeColor = System.Drawing.Color.Aqua;
            this.rtxCodigoFuente.Location = new System.Drawing.Point(69, 0);
            this.rtxCodigoFuente.Name = "rtxCodigoFuente";
            this.rtxCodigoFuente.Size = new System.Drawing.Size(301, 384);
            this.rtxCodigoFuente.TabIndex = 0;
            this.rtxCodigoFuente.Text = "";
            this.rtxCodigoFuente.SelectionChanged += new System.EventHandler(this.rtxCodigoFuente_SelectionChanged);
            this.rtxCodigoFuente.VScroll += new System.EventHandler(this.rtxCodigoFuente_VScroll);
            this.rtxCodigoFuente.TextChanged += new System.EventHandler(this.rtxCodigoFuente_TextChanged);
            this.rtxCodigoFuente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxCodigoFuente_KeyDown);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(116, 3);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(82, 27);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Iniciar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // rtxTokens
            // 
            this.rtxTokens.Enabled = false;
            this.rtxTokens.Location = new System.Drawing.Point(463, -3);
            this.rtxTokens.Name = "rtxTokens";
            this.rtxTokens.Size = new System.Drawing.Size(305, 385);
            this.rtxTokens.TabIndex = 3;
            this.rtxTokens.Text = "";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(12, 3);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(98, 26);
            this.btnCargar.TabIndex = 4;
            this.btnCargar.Text = "Cargar Archivo";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lsbSimbolos
            // 
            this.lsbSimbolos.Enabled = false;
            this.lsbSimbolos.FormattingEnabled = true;
            this.lsbSimbolos.Location = new System.Drawing.Point(376, 34);
            this.lsbSimbolos.Name = "lsbSimbolos";
            this.lsbSimbolos.Size = new System.Drawing.Size(305, 82);
            this.lsbSimbolos.TabIndex = 6;
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.LineNumberTextBox.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineNumberTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LineNumberTextBox.Location = new System.Drawing.Point(0, 0);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.Size = new System.Drawing.Size(63, 385);
            this.LineNumberTextBox.TabIndex = 8;
            this.LineNumberTextBox.Text = "";
            this.LineNumberTextBox.FontChanged += new System.EventHandler(this.LineNumberTextBox_FontChanged);
            this.LineNumberTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LineNumberTextBox_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 27);
            this.button1.TabIndex = 9;
            this.button1.Text = "Guardar archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.btnTokens);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Controls.Add(this.btnAnalizar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 33);
            this.panel1.TabIndex = 10;
            // 
            // btnTokens
            // 
            this.btnTokens.Location = new System.Drawing.Point(573, 4);
            this.btnTokens.Name = "btnTokens";
            this.btnTokens.Size = new System.Drawing.Size(108, 24);
            this.btnTokens.TabIndex = 11;
            this.btnTokens.Text = "Guardar Tokens";
            this.btnTokens.UseVisualStyleBackColor = true;
            this.btnTokens.Click += new System.EventHandler(this.btnTokens_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(323, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(91, 27);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtxTokens);
            this.panel2.Controls.Add(this.LineNumberTextBox);
            this.panel2.Controls.Add(this.rtxCodigoFuente);
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 385);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSimbolos);
            this.panel3.Controls.Add(this.lblListaSim);
            this.panel3.Controls.Add(this.lblErrores);
            this.panel3.Controls.Add(this.rtxErrores);
            this.panel3.Controls.Add(this.lsbSimbolos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 430);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1116, 128);
            this.panel3.TabIndex = 12;
            // 
            // btnSimbolos
            // 
            this.btnSimbolos.Location = new System.Drawing.Point(704, 48);
            this.btnSimbolos.Name = "btnSimbolos";
            this.btnSimbolos.Size = new System.Drawing.Size(75, 39);
            this.btnSimbolos.TabIndex = 10;
            this.btnSimbolos.Text = "Guardar Simbolos";
            this.btnSimbolos.UseVisualStyleBackColor = true;
            this.btnSimbolos.Click += new System.EventHandler(this.btnSimbolos_Click);
            // 
            // lblListaSim
            // 
            this.lblListaSim.AutoSize = true;
            this.lblListaSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaSim.Location = new System.Drawing.Point(376, 13);
            this.lblListaSim.Name = "lblListaSim";
            this.lblListaSim.Size = new System.Drawing.Size(138, 16);
            this.lblListaSim.TabIndex = 9;
            this.lblListaSim.Text = "LISTA DE SIMBOLOS";
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrores.Location = new System.Drawing.Point(13, 13);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(160, 16);
            this.lblErrores.TabIndex = 8;
            this.lblErrores.Text = "ERRORES DE SINTAXIS";
            // 
            // rtxErrores
            // 
            this.rtxErrores.Enabled = false;
            this.rtxErrores.Location = new System.Drawing.Point(12, 35);
            this.rtxErrores.Name = "rtxErrores";
            this.rtxErrores.Size = new System.Drawing.Size(351, 81);
            this.rtxErrores.TabIndex = 7;
            this.rtxErrores.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(806, 40);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(298, 384);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // frmLJCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 558);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel3);
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
        private System.Windows.Forms.RichTextBox rtxTokens;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ListBox lsbSimbolos;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtxErrores;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblListaSim;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Button btnTokens;
        private System.Windows.Forms.Button btnSimbolos;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

