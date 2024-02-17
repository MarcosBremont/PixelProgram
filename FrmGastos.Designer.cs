
namespace Pixel_Program
{
    partial class FrmGastos
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewGastos = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnActualizarGastos = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolverAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(84, 64);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(219, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(349, 64);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(129, 20);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(9, 68);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(74, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(303, 68);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(42, 13);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Agregar Gasto";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // dataGridViewGastos
            // 
            this.dataGridViewGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewGastos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewGastos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGastos.ColumnHeadersVisible = false;
            this.dataGridViewGastos.Location = new System.Drawing.Point(12, 108);
            this.dataGridViewGastos.Name = "dataGridViewGastos";
            this.dataGridViewGastos.RowHeadersVisible = false;
            this.dataGridViewGastos.Size = new System.Drawing.Size(776, 210);
            this.dataGridViewGastos.TabIndex = 5;
            this.dataGridViewGastos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGastos_CellClick);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(8, 421);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(112, 20);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total Gastos";
            // 
            // btnActualizarGastos
            // 
            this.btnActualizarGastos.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnActualizarGastos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnActualizarGastos.FlatAppearance.BorderSize = 0;
            this.btnActualizarGastos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnActualizarGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarGastos.ForeColor = System.Drawing.Color.White;
            this.btnActualizarGastos.Location = new System.Drawing.Point(159, 380);
            this.btnActualizarGastos.Name = "btnActualizarGastos";
            this.btnActualizarGastos.Size = new System.Drawing.Size(130, 33);
            this.btnActualizarGastos.TabIndex = 7;
            this.btnActualizarGastos.Text = "Actualizar Gasto";
            this.btnActualizarGastos.UseVisualStyleBackColor = false;
            this.btnActualizarGastos.Click += new System.EventHandler(this.btnActualizarGastos_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(531, 64);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(170, 20);
            this.txtFecha.TabIndex = 8;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(304, 380);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 33);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar Gasto";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(486, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha";
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
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "GASTOS";
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
            // FrmGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolverAtras);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnActualizarGastos);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridViewGastos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGastos";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmGastos_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmGastos_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmGastos_MouseUp);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.FrmGastos_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGastos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewGastos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnActualizarGastos;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolverAtras;
        private System.Windows.Forms.Button btnMinimizar;
    }
}

