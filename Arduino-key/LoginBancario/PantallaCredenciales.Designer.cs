namespace LoginBancario
{
    partial class PantallaCredenciales
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
            this.campoUsuario = new System.Windows.Forms.TextBox();
            this.campoContrasena = new System.Windows.Forms.TextBox();
            this.etiquetaUsuario = new System.Windows.Forms.Label();
            this.etiquetaContraseña = new System.Windows.Forms.Label();
            this.botonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // campoUsuario
            // 
            this.campoUsuario.Location = new System.Drawing.Point(106, 26);
            this.campoUsuario.Name = "campoUsuario";
            this.campoUsuario.Size = new System.Drawing.Size(100, 20);
            this.campoUsuario.TabIndex = 0;
            // 
            // campoContrasena
            // 
            this.campoContrasena.Location = new System.Drawing.Point(106, 62);
            this.campoContrasena.Name = "campoContrasena";
            this.campoContrasena.Size = new System.Drawing.Size(100, 20);
            this.campoContrasena.TabIndex = 1;
            // 
            // etiquetaUsuario
            // 
            this.etiquetaUsuario.AutoSize = true;
            this.etiquetaUsuario.Location = new System.Drawing.Point(31, 29);
            this.etiquetaUsuario.Name = "etiquetaUsuario";
            this.etiquetaUsuario.Size = new System.Drawing.Size(43, 13);
            this.etiquetaUsuario.TabIndex = 2;
            this.etiquetaUsuario.Text = "Usuario";
            // 
            // etiquetaContraseña
            // 
            this.etiquetaContraseña.AutoSize = true;
            this.etiquetaContraseña.Location = new System.Drawing.Point(31, 69);
            this.etiquetaContraseña.Name = "etiquetaContraseña";
            this.etiquetaContraseña.Size = new System.Drawing.Size(61, 13);
            this.etiquetaContraseña.TabIndex = 3;
            this.etiquetaContraseña.Text = "Contraseña";
            // 
            // botonLogin
            // 
            this.botonLogin.Location = new System.Drawing.Point(73, 100);
            this.botonLogin.Name = "botonLogin";
            this.botonLogin.Size = new System.Drawing.Size(116, 23);
            this.botonLogin.TabIndex = 4;
            this.botonLogin.Text = "Iniciar sesión";
            this.botonLogin.UseVisualStyleBackColor = true;
            this.botonLogin.Click += new System.EventHandler(this.botonLogin_Click);
            // 
            // PantallaCredenciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 157);
            this.Controls.Add(this.botonLogin);
            this.Controls.Add(this.etiquetaContraseña);
            this.Controls.Add(this.etiquetaUsuario);
            this.Controls.Add(this.campoContrasena);
            this.Controls.Add(this.campoUsuario);
            this.Name = "PantallaCredenciales";
            this.Text = "PantallaCredenciales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox campoUsuario;
        private System.Windows.Forms.TextBox campoContrasena;
        private System.Windows.Forms.Label etiquetaUsuario;
        private System.Windows.Forms.Label etiquetaContraseña;
        private System.Windows.Forms.Button botonLogin;
    }
}