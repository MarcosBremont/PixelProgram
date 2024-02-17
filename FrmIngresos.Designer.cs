
namespace Pixel_Program
{
    partial class FrmIngresos
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnActualizarGastos = new System.Windows.Forms.Button();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.dataGridViewIngresos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolverAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngresos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(524, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fecha";
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
            this.btnEliminar.Location = new System.Drawing.Point(306, 376);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 32);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar Ingreso";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(569, 64);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(170, 20);
            this.txtFecha.TabIndex = 19;
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
            this.btnActualizarGastos.Location = new System.Drawing.Point(161, 376);
            this.btnActualizarGastos.Name = "btnActualizarGastos";
            this.btnActualizarGastos.Size = new System.Drawing.Size(130, 32);
            this.btnActualizarGastos.TabIndex = 18;
            this.btnActualizarGastos.Text = "Actualizar Ingreso";
            this.btnActualizarGastos.UseVisualStyleBackColor = false;
            this.btnActualizarGastos.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.Location = new System.Drawing.Point(10, 416);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(124, 20);
            this.lblTotalIngresos.TabIndex = 17;
            this.lblTotalIngresos.Text = "Total Ingresos";
            // 
            // dataGridViewIngresos
            // 
            this.dataGridViewIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewIngresos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIngresos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIngresos.ColumnHeadersVisible = false;
            this.dataGridViewIngresos.Location = new System.Drawing.Point(13, 126);
            this.dataGridViewIngresos.Name = "dataGridViewIngresos";
            this.dataGridViewIngresos.RowHeadersVisible = false;
            this.dataGridViewIngresos.Size = new System.Drawing.Size(776, 210);
            this.dataGridViewIngresos.TabIndex = 16;
            this.dataGridViewIngresos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIngresos_CellClick);
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
            this.button1.Location = new System.Drawing.Point(14, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Agregar Ingreso";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(331, 68);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(42, 13);
            this.lblMonto.TabIndex = 14;
            this.lblMonto.Text = "Monto";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(12, 67);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(74, 13);
            this.lblDescripcion.TabIndex = 13;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(377, 64);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(129, 20);
            this.txtMonto.TabIndex = 12;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(114, 64);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(205, 20);
            this.txtDescripcion.TabIndex = 11;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(12, 93);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(93, 13);
            this.lblNombreCliente.TabIndex = 23;
            this.lblNombreCliente.Text = "Nombre Cliente";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(114, 90);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(205, 20);
            this.txtNombreCliente.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-43, -1);
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
            this.btnMinimizar.Location = new System.Drawing.Point(816, 1);
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
            this.label3.Location = new System.Drawing.Point(376, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "INGRESOS";
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
            this.btnVolverAtras.Location = new System.Drawing.Point(634, 376);
            this.btnVolverAtras.Name = "btnVolverAtras";
            this.btnVolverAtras.Size = new System.Drawing.Size(155, 38);
            this.btnVolverAtras.TabIndex = 46;
            this.btnVolverAtras.Text = "Volver Atras";
            this.btnVolverAtras.UseVisualStyleBackColor = false;
            this.btnVolverAtras.Click += new System.EventHandler(this.btnVolverAtras_Click);
            // 
            // FrmIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolverAtras);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnActualizarGastos);
            this.Controls.Add(this.lblTotalIngresos);
            this.Controls.Add(this.dataGridViewIngresos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIngresos";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmIngresos_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmIngresos_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmIngresos_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIngresos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnActualizarGastos;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.DataGridView dataGridViewIngresos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolverAtras;
        private System.Windows.Forms.Button btnMinimizar;
    }
}