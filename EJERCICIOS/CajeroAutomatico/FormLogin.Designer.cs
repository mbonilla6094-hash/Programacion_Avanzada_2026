namespace CajeroAutomatico
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTitulo = new Panel();
            labelTitulo = new Label();
            labelSubtitulo = new Label();
            groupBoxLogin = new GroupBox();
            labelId = new Label();
            textBoxId = new TextBox();
            labelContrasena = new Label();
            textBoxContrasena = new TextBox();
            buttonIngresar = new Button();
            buttonSalir = new Button();
            labelMensaje = new Label();
            panelTitulo.SuspendLayout();
            groupBoxLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = System.Drawing.Color.FromArgb(0, 100, 150);
            panelTitulo.Controls.Add(labelTitulo);
            panelTitulo.Controls.Add(labelSubtitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new System.Drawing.Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new System.Drawing.Size(450, 80);
            panelTitulo.TabIndex = 0;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelTitulo.ForeColor = System.Drawing.Color.White;
            labelTitulo.Location = new System.Drawing.Point(110, 10);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(230, 32);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "CAJERO AUTOMATICO";
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelSubtitulo.ForeColor = System.Drawing.Color.White;
            labelSubtitulo.Location = new System.Drawing.Point(155, 48);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new System.Drawing.Size(140, 15);
            labelSubtitulo.TabIndex = 1;
            labelSubtitulo.Text = "Ingrese sus credenciales";
            // 
            // groupBoxLogin
            // 
            groupBoxLogin.Controls.Add(labelId);
            groupBoxLogin.Controls.Add(textBoxId);
            groupBoxLogin.Controls.Add(labelContrasena);
            groupBoxLogin.Controls.Add(textBoxContrasena);
            groupBoxLogin.Controls.Add(buttonIngresar);
            groupBoxLogin.Controls.Add(buttonSalir);
            groupBoxLogin.Location = new System.Drawing.Point(50, 100);
            groupBoxLogin.Name = "groupBoxLogin";
            groupBoxLogin.Size = new System.Drawing.Size(350, 200);
            groupBoxLogin.TabIndex = 1;
            groupBoxLogin.TabStop = false;
            groupBoxLogin.Text = "Inicio de Sesion";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new System.Drawing.Point(30, 35);
            labelId.Name = "labelId";
            labelId.Size = new System.Drawing.Size(75, 15);
            labelId.TabIndex = 0;
            labelId.Text = "ID de Usuario";
            // 
            // textBoxId
            // 
            textBoxId.Location = new System.Drawing.Point(30, 55);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new System.Drawing.Size(290, 23);
            textBoxId.TabIndex = 1;
            // 
            // labelContrasena
            // 
            labelContrasena.AutoSize = true;
            labelContrasena.Location = new System.Drawing.Point(30, 90);
            labelContrasena.Name = "labelContrasena";
            labelContrasena.Size = new System.Drawing.Size(67, 15);
            labelContrasena.TabIndex = 2;
            labelContrasena.Text = "Contrasena";
            // 
            // textBoxContrasena
            // 
            textBoxContrasena.Location = new System.Drawing.Point(30, 110);
            textBoxContrasena.Name = "textBoxContrasena";
            textBoxContrasena.PasswordChar = '*';
            textBoxContrasena.Size = new System.Drawing.Size(290, 23);
            textBoxContrasena.TabIndex = 3;
            // 
            // buttonIngresar
            // 
            buttonIngresar.BackColor = System.Drawing.Color.FromArgb(0, 100, 150);
            buttonIngresar.FlatStyle = FlatStyle.Flat;
            buttonIngresar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonIngresar.ForeColor = System.Drawing.Color.White;
            buttonIngresar.Location = new System.Drawing.Point(30, 150);
            buttonIngresar.Name = "buttonIngresar";
            buttonIngresar.Size = new System.Drawing.Size(135, 35);
            buttonIngresar.TabIndex = 4;
            buttonIngresar.Text = "Ingresar";
            buttonIngresar.UseVisualStyleBackColor = false;
            buttonIngresar.Click += buttonIngresar_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonSalir.ForeColor = System.Drawing.Color.White;
            buttonSalir.Location = new System.Drawing.Point(185, 150);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new System.Drawing.Size(135, 35);
            buttonSalir.TabIndex = 5;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // labelMensaje
            // 
            labelMensaje.AutoSize = true;
            labelMensaje.ForeColor = System.Drawing.Color.Red;
            labelMensaje.Location = new System.Drawing.Point(50, 310);
            labelMensaje.Name = "labelMensaje";
            labelMensaje.Size = new System.Drawing.Size(0, 15);
            labelMensaje.TabIndex = 2;
            // 
            // FormLogin
            // 
            AcceptButton = buttonIngresar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(450, 340);
            Controls.Add(labelMensaje);
            Controls.Add(groupBoxLogin);
            Controls.Add(panelTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cajero Automatico - Login";
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            groupBoxLogin.ResumeLayout(false);
            groupBoxLogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTitulo;
        private Label labelTitulo;
        private Label labelSubtitulo;
        private GroupBox groupBoxLogin;
        private Label labelId;
        private TextBox textBoxId;
        private Label labelContrasena;
        private TextBox textBoxContrasena;
        private Button buttonIngresar;
        private Button buttonSalir;
        private Label labelMensaje;
    }
}
