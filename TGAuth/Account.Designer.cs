namespace TGAuth
{
    partial class Account
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
            this.access_token_label = new System.Windows.Forms.Label();
            this.refresh_token_label = new System.Windows.Forms.Label();
            this.refresh_time_label = new System.Windows.Forms.Label();
            this.refresh_tokens_btn = new System.Windows.Forms.Button();
            this.ping_btn = new System.Windows.Forms.Button();
            this.ping_result_label = new System.Windows.Forms.Label();
            this.successful_login = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // access_token_label
            // 
            this.access_token_label.AutoSize = true;
            this.access_token_label.Location = new System.Drawing.Point(65, 90);
            this.access_token_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.access_token_label.Name = "access_token_label";
            this.access_token_label.Size = new System.Drawing.Size(78, 32);
            this.access_token_label.TabIndex = 0;
            this.access_token_label.Text = "label1";
            // 
            // refresh_token_label
            // 
            this.refresh_token_label.AutoSize = true;
            this.refresh_token_label.Location = new System.Drawing.Point(65, 173);
            this.refresh_token_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.refresh_token_label.Name = "refresh_token_label";
            this.refresh_token_label.Size = new System.Drawing.Size(78, 32);
            this.refresh_token_label.TabIndex = 1;
            this.refresh_token_label.Text = "label2";
            // 
            // refresh_time_label
            // 
            this.refresh_time_label.AutoSize = true;
            this.refresh_time_label.Location = new System.Drawing.Point(65, 243);
            this.refresh_time_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.refresh_time_label.Name = "refresh_time_label";
            this.refresh_time_label.Size = new System.Drawing.Size(78, 32);
            this.refresh_time_label.TabIndex = 2;
            this.refresh_time_label.Text = "label3";
            // 
            // refresh_tokens_btn
            // 
            this.refresh_tokens_btn.Location = new System.Drawing.Point(67, 324);
            this.refresh_tokens_btn.Margin = new System.Windows.Forms.Padding(6);
            this.refresh_tokens_btn.Name = "refresh_tokens_btn";
            this.refresh_tokens_btn.Size = new System.Drawing.Size(273, 49);
            this.refresh_tokens_btn.TabIndex = 3;
            this.refresh_tokens_btn.Text = "Обновить токены";
            this.refresh_tokens_btn.UseVisualStyleBackColor = true;
            this.refresh_tokens_btn.Click += new System.EventHandler(this.refresh_tokens_btn_Click);
            // 
            // ping_btn
            // 
            this.ping_btn.Location = new System.Drawing.Point(351, 324);
            this.ping_btn.Margin = new System.Windows.Forms.Padding(6);
            this.ping_btn.Name = "ping_btn";
            this.ping_btn.Size = new System.Drawing.Size(292, 49);
            this.ping_btn.TabIndex = 4;
            this.ping_btn.Text = "Access_token жив?";
            this.ping_btn.UseVisualStyleBackColor = true;
            this.ping_btn.Click += new System.EventHandler(this.ping_btn_Click);
            // 
            // ping_result_label
            // 
            this.ping_result_label.AutoSize = true;
            this.ping_result_label.Location = new System.Drawing.Point(680, 332);
            this.ping_result_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ping_result_label.Name = "ping_result_label";
            this.ping_result_label.Size = new System.Drawing.Size(222, 32);
            this.ping_result_label.TabIndex = 5;
            this.ping_result_label.Text = "Не запрашивалось";
            // 
            // successful_login
            // 
            this.successful_login.AutoSize = true;
            this.successful_login.Location = new System.Drawing.Point(67, 19);
            this.successful_login.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.successful_login.Name = "successful_login";
            this.successful_login.Size = new System.Drawing.Size(236, 32);
            this.successful_login.TabIndex = 6;
            this.successful_login.Text = "Вы успешно вошли!";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 401);
            this.Controls.Add(this.successful_login);
            this.Controls.Add(this.ping_result_label);
            this.Controls.Add(this.ping_btn);
            this.Controls.Add(this.refresh_tokens_btn);
            this.Controls.Add(this.refresh_time_label);
            this.Controls.Add(this.refresh_token_label);
            this.Controls.Add(this.access_token_label);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Account";
            this.Text = "Личный Кабинет";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label access_token_label;
        private Label refresh_token_label;
        private Label refresh_time_label;
        private Button refresh_tokens_btn;
        private Button ping_btn;
        private Label ping_result_label;
        private Label successful_login;
    }
}