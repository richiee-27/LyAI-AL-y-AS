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
            this.btnSemantico = new System.Windows.Forms.Button();
            this.btnSintactico = new System.Windows.Forms.Button();
            this.btnTokens = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.rtxPosfijo = new System.Windows.Forms.RichTextBox();
            this.btnPosfijo = new System.Windows.Forms.Button();
            this.rtxErroresSemanticos = new System.Windows.Forms.RichTextBox();
            this.btnSimbolos = new System.Windows.Forms.Button();
            this.lblListaSim = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.rtxErrores = new System.Windows.Forms.RichTextBox();
            this.rtxGramatica = new System.Windows.Forms.RichTextBox();
            this.rtxSemantico = new System.Windows.Forms.RichTextBox();
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
            this.rtxCodigoFuente.Size = new System.Drawing.Size(283, 384);
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
            this.rtxTokens.Location = new System.Drawing.Point(376, 6);
            this.rtxTokens.Name = "rtxTokens";
            this.rtxTokens.Size = new System.Drawing.Size(283, 379);
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
            this.panel1.Controls.Add(this.btnSemantico);
            this.panel1.Controls.Add(this.btnSintactico);
            this.panel1.Controls.Add(this.btnTokens);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Controls.Add(this.btnAnalizar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 33);
            this.panel1.TabIndex = 10;
            // 
            // btnSemantico
            // 
            this.btnSemantico.Location = new System.Drawing.Point(1124, 4);
            this.btnSemantico.Name = "btnSemantico";
            this.btnSemantico.Size = new System.Drawing.Size(86, 25);
            this.btnSemantico.TabIndex = 12;
            this.btnSemantico.Text = "Semantico";
            this.btnSemantico.UseVisualStyleBackColor = true;
            this.btnSemantico.Click += new System.EventHandler(this.btnSemantico_Click);
            // 
            // btnSintactico
            // 
            this.btnSintactico.Location = new System.Drawing.Point(812, 7);
            this.btnSintactico.Name = "btnSintactico";
            this.btnSintactico.Size = new System.Drawing.Size(75, 23);
            this.btnSintactico.TabIndex = 12;
            this.btnSintactico.Text = "Sintactico";
            this.btnSintactico.UseVisualStyleBackColor = true;
            this.btnSintactico.Click += new System.EventHandler(this.btnSintactico_Click);
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
            this.panel2.Size = new System.Drawing.Size(688, 385);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rtxPosfijo);
            this.panel3.Controls.Add(this.btnPosfijo);
            this.panel3.Controls.Add(this.rtxErroresSemanticos);
            this.panel3.Controls.Add(this.btnSimbolos);
            this.panel3.Controls.Add(this.lblListaSim);
            this.panel3.Controls.Add(this.lblErrores);
            this.panel3.Controls.Add(this.rtxErrores);
            this.panel3.Controls.Add(this.lsbSimbolos);
            this.panel3.Location = new System.Drawing.Point(0, 438);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1336, 128);
            this.panel3.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(379, 641);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 31);
            this.button2.TabIndex = 18;
            this.button2.Text = "Ensamblador";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rtxPosfijo
            // 
            this.rtxPosfijo.Location = new System.Drawing.Point(693, 35);
            this.rtxPosfijo.Name = "rtxPosfijo";
            this.rtxPosfijo.Size = new System.Drawing.Size(315, 81);
            this.rtxPosfijo.TabIndex = 17;
            this.rtxPosfijo.Text = "";
            // 
            // btnPosfijo
            // 
            this.btnPosfijo.Location = new System.Drawing.Point(694, 7);
            this.btnPosfijo.Name = "btnPosfijo";
            this.btnPosfijo.Size = new System.Drawing.Size(75, 23);
            this.btnPosfijo.TabIndex = 16;
            this.btnPosfijo.Text = "Posfijo";
            this.btnPosfijo.UseVisualStyleBackColor = true;
            this.btnPosfijo.Click += new System.EventHandler(this.btnPosfijo_Click);
            // 
            // rtxErroresSemanticos
            // 
            this.rtxErroresSemanticos.Location = new System.Drawing.Point(1014, 13);
            this.rtxErroresSemanticos.Name = "rtxErroresSemanticos";
            this.rtxErroresSemanticos.Size = new System.Drawing.Size(298, 103);
            this.rtxErroresSemanticos.TabIndex = 15;
            this.rtxErroresSemanticos.Text = "";
            // 
            // btnSimbolos
            // 
            this.btnSimbolos.Location = new System.Drawing.Point(556, 5);
            this.btnSimbolos.Name = "btnSimbolos";
            this.btnSimbolos.Size = new System.Drawing.Size(115, 26);
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
            this.rtxErrores.Size = new System.Drawing.Size(340, 81);
            this.rtxErrores.TabIndex = 7;
            this.rtxErrores.Text = "";
            // 
            // rtxGramatica
            // 
            this.rtxGramatica.Location = new System.Drawing.Point(694, 40);
            this.rtxGramatica.Name = "rtxGramatica";
            this.rtxGramatica.Size = new System.Drawing.Size(298, 384);
            this.rtxGramatica.TabIndex = 13;
            this.rtxGramatica.Text = "";
            // 
            // rtxSemantico
            // 
            this.rtxSemantico.Location = new System.Drawing.Point(1014, 40);
            this.rtxSemantico.Name = "rtxSemantico";
            this.rtxSemantico.Size = new System.Drawing.Size(298, 384);
            this.rtxSemantico.TabIndex = 14;
            this.rtxSemantico.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 572);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(353, 175);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // frmLJCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 749);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.rtxSemantico);
            this.Controls.Add(this.rtxGramatica);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmLJCR";
            this.Text = "LENGUAJE JCR";
            this.Load += new System.EventHandler(this.frmLJCR_Load);
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
        private System.Windows.Forms.RichTextBox rtxGramatica;
        private System.Windows.Forms.Button btnSintactico;
        private System.Windows.Forms.Button btnSemantico;
        private System.Windows.Forms.RichTextBox rtxSemantico;
        private System.Windows.Forms.RichTextBox rtxErroresSemanticos;
        private System.Windows.Forms.RichTextBox rtxPosfijo;
        private System.Windows.Forms.Button btnPosfijo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

