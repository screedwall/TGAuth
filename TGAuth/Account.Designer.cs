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
            this.access_token_label.Location = new System.Drawing.Point(35, 42);
            this.access_token_label.Name = "access_token_label";
            this.access_token_label.Size = new System.Drawing.Size(38, 15);
            this.access_token_label.TabIndex = 0;
            this.access_token_label.Text = "label1";
            // 
            // refresh_token_label
            // 
            this.refresh_token_label.AutoSize = true;
            this.refresh_token_label.Location = new System.Drawing.Point(35, 81);
            this.refresh_token_label.Name = "refresh_token_label";
            this.refresh_token_label.Size = new System.Drawing.Size(38, 15);
            this.refresh_token_label.TabIndex = 1;
            this.refresh_token_label.Text = "label2";
            // 
            // refresh_time_label
            // 
            this.refresh_time_label.AutoSize = true;
            this.refresh_time_label.Location = new System.Drawing.Point(35, 114);
            this.refresh_time_label.Name = "refresh_time_label";
            this.refresh_time_label.Size = new System.Drawing.Size(38, 15);
            this.refresh_time_label.TabIndex = 2;
            this.refresh_time_label.Text = "label3";
            // 
            // refresh_tokens_btn
            // 
            this.refresh_tokens_btn.Location = new System.Drawing.Point(36, 152);
            this.refresh_tokens_btn.Name = "refresh_tokens_btn";
            this.refresh_tokens_btn.Size = new System.Drawing.Size(147, 23);
            this.refresh_tokens_btn.TabIndex = 3;
            this.refresh_tokens_btn.Text = "Обновить токены";
            this.refresh_tokens_btn.UseVisualStyleBackColor = true;
            this.refresh_tokens_btn.Click += new System.EventHandler(this.refresh_tokens_btn_Click);
            // 
            // ping_btn
            // 
            this.ping_btn.Location = new System.Drawing.Point(189, 152);
            this.ping_btn.Name = "ping_btn";
            this.ping_btn.Size = new System.Drawing.Size(75, 23);
            this.ping_btn.TabIndex = 4;
            this.ping_btn.Text = "Ping";
            this.ping_btn.UseVisualStyleBackColor = true;
            this.ping_btn.Click += new System.EventHandler(this.ping_btn_Click);
            // 
            // ping_result_label
            // 
            this.ping_result_label.AutoSize = true;
            this.ping_result_label.Location = new System.Drawing.Point(284, 156);
            this.ping_result_label.Name = "ping_result_label";
            this.ping_result_label.Size = new System.Drawing.Size(93, 15);
            this.ping_result_label.TabIndex = 5;
            this.ping_result_label.Text = "Не выполнялся";
            // 
            // successful_login
            // 
            this.successful_login.AutoSize = true;
            this.successful_login.Location = new System.Drawing.Point(36, 9);
            this.successful_login.Name = "successful_login";
            this.successful_login.Size = new System.Drawing.Size(120, 15);
            this.successful_login.TabIndex = 6;
            this.successful_login.Text = "Вы успешно вошли!";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 188);
            this.Controls.Add(this.successful_login);
            this.Controls.Add(this.ping_result_label);
            this.Controls.Add(this.ping_btn);
            this.Controls.Add(this.refresh_tokens_btn);
            this.Controls.Add(this.refresh_time_label);
            this.Controls.Add(this.refresh_token_label);
            this.Controls.Add(this.access_token_label);
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