
namespace Pixel_Program
{
    partial class FrmReportes
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
            this.lblIngresos = new System.Windows.Forms.Label();
            this.dataGridViewIngresos = new System.Windows.Forms.DataGridView();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolverAtras = new System.Windows.Forms.Button();
            this.lblGastos = new System.Windows.Forms.Label();
            this.dataGridViewGastos = new System.Windows.Forms.DataGridView();
            this.lblTotalGastos = new System.Windows.Forms.Label();
            this.dateTimePicker1Ingresos = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2Ingresos = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnFiltrarGastos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2Gastos = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1Gastos = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngresos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIngresos
            // 
            this.lblIngresos.AutoSize = true;
            this.lblIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos.Location = new System.Drawing.Point(6, 43);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(55, 13);
            this.lblIngresos.TabIndex = 2;
            this.lblIngresos.Text = "Ingresos";
            // 
            // dataGridViewIngresos
            // 
            this.dataGridViewIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewIngresos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIngresos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIngresos.ColumnHeadersVisible = false;
            this.dataGridViewIngresos.Location = new System.Drawing.Point(5, 119);
            this.dataGridViewIngresos.Name = "dataGridViewIngresos";
            this.dataGridViewIngresos.RowHeadersVisible = false;
            this.dataGridViewIngresos.Size = new System.Drawing.Size(368, 189);
            this.dataGridViewIngresos.TabIndex = 5;
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.Location = new System.Drawing.Point(5, 344);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(112, 20);
            this.lblTotalIngresos.TabIndex = 6;
            this.lblTotalIngresos.Text = "Total Gastos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-29, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 30);
            this.panel1.TabIndex = 31;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.DimGray;
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(802, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(27, 27);
            this.btnMinimizar.TabIndex = 48;
            this.btnMinimizar.Text = "-";
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(372, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "REPORTES";
            // 
            // btnVolverAtras
            // 
            this.btnVolverAtras.BackColor = System.Drawing.Color.Firebrick;
            this.btnVolverAtras.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolverAtras.FlatAppearance.BorderSize = 0;
            this.btnVolverAtras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnVolverAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverAtras.ForeColor = System.Drawing.Color.White;
            this.btnVolverAtras.Location = new System.Drawing.Point(620, 375);
            this.btnVolverAtras.Name = "btnVolverAtras";
            this.btnVolverAtras.Size = new System.Drawing.Size(155, 38);
            this.btnVolverAtras.TabIndex = 47;
            this.btnVolverAtras.Text = "Volver Atras";
            this.btnVolverAtras.UseVisualStyleBackColor = false;
            this.btnVolverAtras.Click += new System.EventHandler(this.btnVolverAtras_Click);
            // 
            // lblGastos
            // 
            this.lblGastos.AutoSize = true;
            this.lblGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastos.Location = new System.Drawing.Point(411, 43);
            this.lblGastos.Name = "lblGastos";
            this.lblGastos.Size = new System.Drawing.Size(46, 13);
            this.lblGastos.TabIndex = 48;
            this.lblGastos.Text = "Gastos";
            // 
            // dataGridViewGastos
            // 
            this.dataGridViewGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewGastos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewGastos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGastos.ColumnHeadersVisible = false;
            this.dataGridViewGastos.Location = new System.Drawing.Point(410, 119);
            this.dataGridViewGastos.Name = "dataGridViewGastos";
            this.dataGridViewGastos.RowHeadersVisible = false;
            this.dataGridViewGastos.Size = new System.Drawing.Size(368, 190);
            this.dataGridViewGastos.TabIndex = 49;
            // 
            // lblTotalGastos
            // 
            this.lblTotalGastos.AutoSize = true;
            this.lblTotalGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGastos.Location = new System.Drawing.Point(419, 344);
            this.lblTotalGastos.Name = "lblTotalGastos";
            this.lblTotalGastos.Size = new System.Drawing.Size(112, 20);
            this.lblTotalGastos.TabIndex = 50;
            this.lblTotalGastos.Text = "Total Gastos";
            // 
            // dateTimePicker1Ingresos
            // 
            this.dateTimePicker1Ingresos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1Ingresos.Location = new System.Drawing.Point(52, 66);
            this.dateTimePicker1Ingresos.Name = "dateTimePicker1Ingresos";
            this.dateTimePicker1Ingresos.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1Ingresos.TabIndex = 51;
            // 
            // dateTimePicker2Ingresos
            // 
            this.dateTimePicker2Ingresos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2Ingresos.Location = new System.Drawing.Point(197, 66);
            this.dateTimePicker2Ingresos.Name = "dateTimePicker2Ingresos";
            this.dateTimePicker2Ingresos.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker2Ingresos.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Hasta";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(299, 65);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(74, 22);
            this.btnFiltrar.TabIndex = 56;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnFiltrarGastos
            // 
            this.btnFiltrarGastos.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnFiltrarGastos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFiltrarGastos.FlatAppearance.BorderSize = 0;
            this.btnFiltrarGastos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnFiltrarGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarGastos.ForeColor = System.Drawing.Color.White;
            this.btnFiltrarGastos.Location = new System.Drawing.Point(704, 65);
            this.btnFiltrarGastos.Name = "btnFiltrarGastos";
            this.btnFiltrarGastos.Size = new System.Drawing.Size(74, 22);
            this.btnFiltrarGastos.TabIndex = 61;
            this.btnFiltrarGastos.Text = "Filtrar";
            this.btnFiltrarGastos.UseVisualStyleBackColor = false;
            this.btnFiltrarGastos.Click += new System.EventHandler(this.btnFiltrarGastos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(556, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(411, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Desde";
            // 
            // dateTimePicker2Gastos
            // 
            this.dateTimePicker2Gastos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2Gastos.Location = new System.Drawing.Point(602, 66);
            this.dateTimePicker2Gastos.Name = "dateTimePicker2Gastos";
            this.dateTimePicker2Gastos.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker2Gastos.TabIndex = 58;
            // 
            // dateTimePicker1Gastos
            // 
            this.dateTimePicker1Gastos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1Gastos.Location = new System.Drawing.Point(457, 66);
            this.dateTimePicker1Gastos.Name = "dateTimePicker1Gastos";
            this.dateTimePicker1Gastos.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1Gastos.TabIndex = 57;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFiltrarGastos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker2Gastos);
            this.Controls.Add(this.dateTimePicker1Gastos);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2Ingresos);
            this.Controls.Add(this.dateTimePicker1Ingresos);
            this.Controls.Add(this.lblTotalGastos);
            this.Controls.Add(this.dataGridViewGastos);
            this.Controls.Add(this.lblGastos);
            this.Controls.Add(this.btnVolverAtras);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTotalIngresos);
            this.Controls.Add(this.dataGridViewIngresos);
            this.Controls.Add(this.lblIngresos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGastos";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmGastos_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmGastos_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmGastos_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngresos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.DataGridView dataGridViewIngresos;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolverAtras;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Label lblGastos;
        private System.Windows.Forms.DataGridView dataGridViewGastos;
        private System.Windows.Forms.Label lblTotalGastos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1Ingresos;
        private System.Windows.Forms.DateTimePicker dateTimePicker2Ingresos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnFiltrarGastos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2Gastos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1Gastos;
    }
}

