namespace TGAuth
{
    partial class TGAuth
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.username_label.Location = new System.Drawing.Point(92, 86);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(117, 45);
            this.username_label.TabIndex = 0;
            this.username_label.Text = "Логин:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.password_label.Location = new System.Drawing.Point(72, 170);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(137, 45);
            this.password_label.TabIndex = 1;
            this.password_label.Text = "Пароль:";
            // 
            // username_tb
            // 
            this.username_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username_tb.Location = new System.Drawing.Point(218, 86);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(312, 39);
            this.username_tb.TabIndex = 2;
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(218, 177);
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(312, 39);
            this.password_tb.TabIndex = 3;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(52, 269);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(241, 87);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "Вход";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 87);
            this.button1.TabIndex = 5;
            this.button1.Text = "Регистрация";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TGAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.username_tb);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_label);
            this.Name = "TGAuth";
            this.Text = "TGAuth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label username_label;
        private Label password_label;
        private TextBox username_tb;
        private TextBox password_tb;
        private Button login_btn;
        private Button button1;
    }
}