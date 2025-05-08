namespace Taxisystem
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnLogin = new Button();
            toolTip1 = new ToolTip(components);
            lblPickup = new Label();
            txtPickup = new TextBox();
            label3 = new Label();
            lblDestination = new TextBox();
            btnBook = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(48, 25);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(48, 54);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(203, 32);
            txtEmail.TabIndex = 1;
            toolTip1.SetToolTip(txtEmail, "Πληκτρολογήστε το email σας μορφής user@email.com");
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(48, 109);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(118, 36);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblPickup
            // 
            lblPickup.AutoSize = true;
            lblPickup.Location = new Point(48, 171);
            lblPickup.Margin = new Padding(4, 0, 4, 0);
            lblPickup.Name = "lblPickup";
            lblPickup.Size = new Size(207, 25);
            lblPickup.TabIndex = 3;
            lblPickup.Text = "Διεύθυνση Παραλαβής";
            // 
            // txtPickup
            // 
            txtPickup.Location = new Point(48, 216);
            txtPickup.Margin = new Padding(4);
            txtPickup.Name = "txtPickup";
            txtPickup.Size = new Size(328, 32);
            txtPickup.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 271);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 25);
            label3.TabIndex = 5;
            label3.Text = "Προορισμός";
            // 
            // lblDestination
            // 
            lblDestination.Location = new Point(48, 318);
            lblDestination.Margin = new Padding(4);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(328, 32);
            lblDestination.TabIndex = 6;
            // 
            // btnBook
            // 
            btnBook.Location = new Point(411, 260);
            btnBook.Margin = new Padding(4);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(226, 36);
            btnBook.TabIndex = 7;
            btnBook.Text = "Κάντε Κράτηση";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.Click += btnBook_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(96, 511);
            label1.Name = "label1";
            label1.Size = new Size(541, 25);
            label1.TabIndex = 8;
            label1.Text = "Ελάχιστη χρέωση: 4€ για εντός Αθήνας – για εκτός Αθήνας 9€";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(1000, 562);
            Controls.Add(label1);
            Controls.Add(btnBook);
            Controls.Add(lblDestination);
            Controls.Add(label3);
            Controls.Add(txtPickup);
            Controls.Add(lblPickup);
            Controls.Add(btnLogin);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnLogin;
        private ToolTip toolTip1;
        private Label lblPickup;
        private TextBox txtPickup;
        private Label label3;
        private TextBox lblDestination;
        private Button btnBook;
        private Label label1;
    }
}
