namespace ABC_Car_Traders
{
    partial class CheckoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckoutForm));
            this.txtCardHolderName = new Guna.UI.WinForms.GunaTextBox();
            this.txtCardNumber = new Guna.UI.WinForms.GunaTextBox();
            this.txtCVV = new Guna.UI.WinForms.GunaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaTextBox1 = new Guna.UI.WinForms.GunaTextBox();
            this.gunaCheckBox1 = new Guna.UI.WinForms.GunaCheckBox();
            this.gunaCheckBox2 = new Guna.UI.WinForms.GunaCheckBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.BackColor = System.Drawing.Color.Transparent;
            this.txtCardHolderName.BaseColor = System.Drawing.Color.AliceBlue;
            this.txtCardHolderName.BorderColor = System.Drawing.Color.Silver;
            this.txtCardHolderName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCardHolderName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCardHolderName.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCardHolderName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCardHolderName.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardHolderName.Location = new System.Drawing.Point(665, 262);
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.PasswordChar = '\0';
            this.txtCardHolderName.Radius = 12;
            this.txtCardHolderName.SelectedText = "";
            this.txtCardHolderName.Size = new System.Drawing.Size(264, 34);
            this.txtCardHolderName.TabIndex = 85;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtCardNumber.BaseColor = System.Drawing.Color.AliceBlue;
            this.txtCardNumber.BorderColor = System.Drawing.Color.Silver;
            this.txtCardNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCardNumber.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCardNumber.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCardNumber.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCardNumber.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.Location = new System.Drawing.Point(665, 322);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.PasswordChar = '\0';
            this.txtCardNumber.Radius = 12;
            this.txtCardNumber.SelectedText = "";
            this.txtCardNumber.Size = new System.Drawing.Size(264, 34);
            this.txtCardNumber.TabIndex = 86;
            // 
            // txtCVV
            // 
            this.txtCVV.BackColor = System.Drawing.Color.Transparent;
            this.txtCVV.BaseColor = System.Drawing.Color.AliceBlue;
            this.txtCVV.BorderColor = System.Drawing.Color.Silver;
            this.txtCVV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCVV.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCVV.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCVV.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCVV.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCVV.Location = new System.Drawing.Point(486, 427);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.PasswordChar = '\0';
            this.txtCVV.Radius = 12;
            this.txtCVV.SelectedText = "";
            this.txtCVV.Size = new System.Drawing.Size(140, 33);
            this.txtCVV.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Imprint MT Shadow", 38.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(12, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 61);
            this.label5.TabIndex = 88;
            this.label5.Text = "Checkout";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Goudy Old Style", 17.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(478, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 26);
            this.label6.TabIndex = 89;
            this.label6.Text = "Card Holder Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Goudy Old Style", 17.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(478, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 26);
            this.label7.TabIndex = 90;
            this.label7.Text = "Card Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Goudy Old Style", 15.25F, System.Drawing.FontStyle.Italic);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(479, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 24);
            this.label8.TabIndex = 91;
            this.label8.Text = "CVC";
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.Teal;
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton1.ForeColor = System.Drawing.Color.White;
            this.gunaButton1.Image = null;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(819, 487);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Radius = 10;
            this.gunaButton1.Size = new System.Drawing.Size(104, 36);
            this.gunaButton1.TabIndex = 92;
            this.gunaButton1.Text = "Pay Now";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("NSimSun", 25.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(512, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(357, 35);
            this.label12.TabIndex = 93;
            this.label12.Text = "Enter Card Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 15.25F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(703, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 94;
            this.label1.Text = "Expire Date";
            // 
            // gunaTextBox1
            // 
            this.gunaTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTextBox1.BaseColor = System.Drawing.Color.AliceBlue;
            this.gunaTextBox1.BorderColor = System.Drawing.Color.Silver;
            this.gunaTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox1.FocusedBaseColor = System.Drawing.Color.White;
            this.gunaTextBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaTextBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaTextBox1.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaTextBox1.Location = new System.Drawing.Point(707, 427);
            this.gunaTextBox1.Name = "gunaTextBox1";
            this.gunaTextBox1.PasswordChar = '\0';
            this.gunaTextBox1.Radius = 12;
            this.gunaTextBox1.SelectedText = "";
            this.gunaTextBox1.Size = new System.Drawing.Size(222, 33);
            this.gunaTextBox1.TabIndex = 95;
            // 
            // gunaCheckBox1
            // 
            this.gunaCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaCheckBox1.BaseColor = System.Drawing.Color.White;
            this.gunaCheckBox1.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaCheckBox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaCheckBox1.FillColor = System.Drawing.Color.White;
            this.gunaCheckBox1.Location = new System.Drawing.Point(708, 206);
            this.gunaCheckBox1.Name = "gunaCheckBox1";
            this.gunaCheckBox1.Size = new System.Drawing.Size(20, 20);
            this.gunaCheckBox1.TabIndex = 0;
            this.gunaCheckBox1.CheckedChanged += new System.EventHandler(this.gunaCheckBox1_CheckedChanged);
            // 
            // gunaCheckBox2
            // 
            this.gunaCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaCheckBox2.BaseColor = System.Drawing.Color.White;
            this.gunaCheckBox2.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaCheckBox2.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaCheckBox2.FillColor = System.Drawing.Color.White;
            this.gunaCheckBox2.Location = new System.Drawing.Point(819, 206);
            this.gunaCheckBox2.Name = "gunaCheckBox2";
            this.gunaCheckBox2.Size = new System.Drawing.Size(20, 20);
            this.gunaCheckBox2.TabIndex = 96;
            this.gunaCheckBox2.CheckedChanged += new System.EventHandler(this.gunaCheckBox2_CheckedChanged);
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.BackgroundImage")));
            this.gunaPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Location = new System.Drawing.Point(734, 189);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(68, 51);
            this.gunaPictureBox1.TabIndex = 97;
            this.gunaPictureBox1.TabStop = false;
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox2.BackgroundImage")));
            this.gunaPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Location = new System.Drawing.Point(845, 189);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(68, 51);
            this.gunaPictureBox2.TabIndex = 98;
            this.gunaPictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Goudy Old Style", 17.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(481, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 26);
            this.label2.TabIndex = 99;
            this.label2.Text = "Card Payment";
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(969, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gunaPictureBox2);
            this.Controls.Add(this.gunaPictureBox1);
            this.Controls.Add(this.gunaCheckBox2);
            this.Controls.Add(this.gunaCheckBox1);
            this.Controls.Add(this.gunaTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.gunaButton1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCVV);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.txtCardHolderName);
            this.DoubleBuffered = true;
            this.Name = "CheckoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckoutForm";
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI.WinForms.GunaTextBox txtCardHolderName;
        private Guna.UI.WinForms.GunaTextBox txtCardNumber;
        private Guna.UI.WinForms.GunaTextBox txtCVV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox gunaTextBox1;
        private Guna.UI.WinForms.GunaCheckBox gunaCheckBox1;
        private Guna.UI.WinForms.GunaCheckBox gunaCheckBox2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private System.Windows.Forms.Label label2;
    }
}