namespace LicenseManager.Example.Winforms
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
            propertyGrid1 = new PropertyGrid();
            textBoxHost = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxConsumerKey = new TextBox();
            label3 = new Label();
            textBoxConsumerSecret = new TextBox();
            label4 = new Label();
            textBoxProductId = new TextBox();
            label5 = new Label();
            textBoxLicenseKey = new TextBox();
            buttonActivateLicense = new Button();
            buttonDeActivateLicense = new Button();
            buttonValidateLicense = new Button();
            buttonSetupLicenseClient = new Button();
            buttonListLicenses = new Button();
            buttonCreateLicense = new Button();
            buttonListGenerators = new Button();
            buttonCreateGenerator = new Button();
            buttonUpdateGenerator = new Button();
            buttonGenerateLicense = new Button();
            SuspendLayout();
            // 
            // propertyGrid1
            // 
            propertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            propertyGrid1.Location = new Point(427, 12);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(361, 405);
            propertyGrid1.TabIndex = 0;
            // 
            // textBoxHost
            // 
            textBoxHost.Location = new Point(118, 9);
            textBoxHost.Name = "textBoxHost";
            textBoxHost.Size = new Size(303, 23);
            textBoxHost.TabIndex = 1;
            textBoxHost.Text = "https://licensemanager.codelu.eu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 2;
            label1.Text = "Host:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 4;
            label2.Text = "Consumer Key:";
            // 
            // textBoxConsumerKey
            // 
            textBoxConsumerKey.Location = new Point(118, 38);
            textBoxConsumerKey.Name = "textBoxConsumerKey";
            textBoxConsumerKey.Size = new Size(303, 23);
            textBoxConsumerKey.TabIndex = 3;
            textBoxConsumerKey.Text = "ck_252ce48bf36f3aacee112e3922fc90abf88efd38";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 70);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 6;
            label3.Text = "Consumer Secret:";
            // 
            // textBoxConsumerSecret
            // 
            textBoxConsumerSecret.Location = new Point(118, 67);
            textBoxConsumerSecret.Name = "textBoxConsumerSecret";
            textBoxConsumerSecret.Size = new Size(303, 23);
            textBoxConsumerSecret.TabIndex = 5;
            textBoxConsumerSecret.Text = "cs_0474a2f6605b8bcb2ec3a3c9d8d934b3fed24325";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 99);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 8;
            label4.Text = "Product ID:";
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new Point(118, 96);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.Size = new Size(303, 23);
            textBoxProductId.TabIndex = 7;
            textBoxProductId.Text = "11";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 128);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 10;
            label5.Text = "License Key:";
            // 
            // textBoxLicenseKey
            // 
            textBoxLicenseKey.Location = new Point(118, 125);
            textBoxLicenseKey.Name = "textBoxLicenseKey";
            textBoxLicenseKey.Size = new Size(303, 23);
            textBoxLicenseKey.TabIndex = 9;
            textBoxLicenseKey.Text = "C124A123C412";
            // 
            // buttonActivateLicense
            // 
            buttonActivateLicense.Enabled = false;
            buttonActivateLicense.Location = new Point(142, 196);
            buttonActivateLicense.Name = "buttonActivateLicense";
            buttonActivateLicense.Size = new Size(168, 23);
            buttonActivateLicense.TabIndex = 11;
            buttonActivateLicense.Text = "Activate License";
            buttonActivateLicense.UseVisualStyleBackColor = true;
            buttonActivateLicense.Click += buttonActivateLicense_Click;
            // 
            // buttonDeActivateLicense
            // 
            buttonDeActivateLicense.Enabled = false;
            buttonDeActivateLicense.Location = new Point(142, 225);
            buttonDeActivateLicense.Name = "buttonDeActivateLicense";
            buttonDeActivateLicense.Size = new Size(168, 23);
            buttonDeActivateLicense.TabIndex = 12;
            buttonDeActivateLicense.Text = "De-Activate License";
            buttonDeActivateLicense.UseVisualStyleBackColor = true;
            buttonDeActivateLicense.Click += buttonDeActivateLicense_Click;
            // 
            // buttonValidateLicense
            // 
            buttonValidateLicense.Enabled = false;
            buttonValidateLicense.Location = new Point(142, 254);
            buttonValidateLicense.Name = "buttonValidateLicense";
            buttonValidateLicense.Size = new Size(168, 23);
            buttonValidateLicense.TabIndex = 13;
            buttonValidateLicense.Text = "Validate License";
            buttonValidateLicense.UseVisualStyleBackColor = true;
            buttonValidateLicense.Click += buttonValidateLicense_Click;
            // 
            // buttonSetupLicenseClient
            // 
            buttonSetupLicenseClient.Location = new Point(12, 167);
            buttonSetupLicenseClient.Name = "buttonSetupLicenseClient";
            buttonSetupLicenseClient.Size = new Size(124, 255);
            buttonSetupLicenseClient.TabIndex = 14;
            buttonSetupLicenseClient.Text = "Setup License Client";
            buttonSetupLicenseClient.UseVisualStyleBackColor = true;
            buttonSetupLicenseClient.Click += buttonSetupLicenseClient_Click;
            // 
            // buttonListLicenses
            // 
            buttonListLicenses.Enabled = false;
            buttonListLicenses.Location = new Point(142, 283);
            buttonListLicenses.Name = "buttonListLicenses";
            buttonListLicenses.Size = new Size(168, 23);
            buttonListLicenses.TabIndex = 15;
            buttonListLicenses.Text = "List License";
            buttonListLicenses.UseVisualStyleBackColor = true;
            buttonListLicenses.Click += buttonListLicenses_Click;
            // 
            // buttonCreateLicense
            // 
            buttonCreateLicense.Enabled = false;
            buttonCreateLicense.Location = new Point(142, 167);
            buttonCreateLicense.Name = "buttonCreateLicense";
            buttonCreateLicense.Size = new Size(168, 23);
            buttonCreateLicense.TabIndex = 16;
            buttonCreateLicense.Text = "Create License";
            buttonCreateLicense.UseVisualStyleBackColor = true;
            buttonCreateLicense.Click += buttonCreateLicense_Click;
            // 
            // buttonListGenerators
            // 
            buttonListGenerators.Enabled = false;
            buttonListGenerators.Location = new Point(142, 312);
            buttonListGenerators.Name = "buttonListGenerators";
            buttonListGenerators.Size = new Size(168, 23);
            buttonListGenerators.TabIndex = 17;
            buttonListGenerators.Text = "List Generators";
            buttonListGenerators.UseVisualStyleBackColor = true;
            buttonListGenerators.Click += buttonListGenerators_Click;
            // 
            // buttonCreateGenerator
            // 
            buttonCreateGenerator.Enabled = false;
            buttonCreateGenerator.Location = new Point(142, 341);
            buttonCreateGenerator.Name = "buttonCreateGenerator";
            buttonCreateGenerator.Size = new Size(168, 23);
            buttonCreateGenerator.TabIndex = 18;
            buttonCreateGenerator.Text = "Create Generator";
            buttonCreateGenerator.UseVisualStyleBackColor = true;
            buttonCreateGenerator.Click += buttonCreateGenerator_Click;
            // 
            // buttonUpdateGenerator
            // 
            buttonUpdateGenerator.Enabled = false;
            buttonUpdateGenerator.Location = new Point(142, 370);
            buttonUpdateGenerator.Name = "buttonUpdateGenerator";
            buttonUpdateGenerator.Size = new Size(168, 23);
            buttonUpdateGenerator.TabIndex = 19;
            buttonUpdateGenerator.Text = "Update Generator";
            buttonUpdateGenerator.UseVisualStyleBackColor = true;
            buttonUpdateGenerator.Click += buttonUpdateGenerator_Click;
            // 
            // buttonGenerateLicense
            // 
            buttonGenerateLicense.Enabled = false;
            buttonGenerateLicense.Location = new Point(142, 399);
            buttonGenerateLicense.Name = "buttonGenerateLicense";
            buttonGenerateLicense.Size = new Size(168, 23);
            buttonGenerateLicense.TabIndex = 20;
            buttonGenerateLicense.Text = "Generate License";
            buttonGenerateLicense.UseVisualStyleBackColor = true;
            buttonGenerateLicense.Click += buttonGenerateLicense_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 429);
            Controls.Add(buttonGenerateLicense);
            Controls.Add(buttonUpdateGenerator);
            Controls.Add(buttonCreateGenerator);
            Controls.Add(buttonListGenerators);
            Controls.Add(buttonCreateLicense);
            Controls.Add(buttonListLicenses);
            Controls.Add(buttonSetupLicenseClient);
            Controls.Add(buttonValidateLicense);
            Controls.Add(buttonDeActivateLicense);
            Controls.Add(buttonActivateLicense);
            Controls.Add(label5);
            Controls.Add(textBoxLicenseKey);
            Controls.Add(label4);
            Controls.Add(textBoxProductId);
            Controls.Add(label3);
            Controls.Add(textBoxConsumerSecret);
            Controls.Add(label2);
            Controls.Add(textBoxConsumerKey);
            Controls.Add(label1);
            Controls.Add(textBoxHost);
            Controls.Add(propertyGrid1);
            Name = "Form1";
            Text = "LicenseManager WinForms Example";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PropertyGrid propertyGrid1;
        private TextBox textBoxHost;
        private Label label1;
        private Label label2;
        private TextBox textBoxConsumerKey;
        private Label label3;
        private TextBox textBoxConsumerSecret;
        private Label label4;
        private TextBox textBoxProductId;
        private Label label5;
        private TextBox textBoxLicenseKey;
        private Button buttonActivateLicense;
        private Button buttonDeActivateLicense;
        private Button buttonValidateLicense;
        private Button buttonSetupLicenseClient;
        private Button buttonListLicenses;
        private Button buttonCreateLicense;
        private Button buttonListGenerators;
        private Button buttonCreateGenerator;
        private Button buttonUpdateGenerator;
        private Button buttonGenerateLicense;
    }
}