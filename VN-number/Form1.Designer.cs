﻿namespace VN_number
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.VINlable = new System.Windows.Forms.Label();
            this.VINMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.decodeButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.engienLabel = new System.Windows.Forms.Label();
            this.prodLabel = new System.Windows.Forms.Label();
            this.firmLabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.carBodyLabel = new System.Windows.Forms.Label();
            this.carProducterLabel = new System.Windows.Forms.Label();
            this.carEngineLabel = new System.Windows.Forms.Label();
            this.carFirmTextBox = new System.Windows.Forms.TextBox();
            this.carModelTextBox = new System.Windows.Forms.TextBox();
            this.carYearTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // VINlable
            // 
            this.VINlable.AutoSize = true;
            this.VINlable.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VINlable.Location = new System.Drawing.Point(21, 32);
            this.VINlable.Name = "VINlable";
            this.VINlable.Size = new System.Drawing.Size(202, 29);
            this.VINlable.TabIndex = 0;
            this.VINlable.Text = "Введите VIN-номер";
            // 
            // VINMaskedTextBox
            // 
            this.VINMaskedTextBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VINMaskedTextBox.Location = new System.Drawing.Point(229, 23);
            this.VINMaskedTextBox.Mask = "AAAAAAAAAAAAA0000";
            this.VINMaskedTextBox.Name = "VINMaskedTextBox";
            this.VINMaskedTextBox.Size = new System.Drawing.Size(314, 45);
            this.VINMaskedTextBox.TabIndex = 1;
            this.VINMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VINMaskedTextBox_KeyDown);
            // 
            // decodeButton
            // 
            this.decodeButton.AutoSize = true;
            this.decodeButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.decodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decodeButton.Location = new System.Drawing.Point(537, 23);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(57, 50);
            this.decodeButton.TabIndex = 2;
            this.decodeButton.Text = " ✔";
            this.decodeButton.UseVisualStyleBackColor = false;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.statusLabel.Location = new System.Drawing.Point(19, 87);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 22);
            this.statusLabel.TabIndex = 3;
            // 
            // engienLabel
            // 
            this.engienLabel.AutoSize = true;
            this.engienLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.engienLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.engienLabel.Location = new System.Drawing.Point(21, 304);
            this.engienLabel.Name = "engienLabel";
            this.engienLabel.Size = new System.Drawing.Size(180, 25);
            this.engienLabel.TabIndex = 8;
            this.engienLabel.Text = "Объем двигателя";
            // 
            // prodLabel
            // 
            this.prodLabel.AutoSize = true;
            this.prodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prodLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.prodLabel.Location = new System.Drawing.Point(21, 346);
            this.prodLabel.Name = "prodLabel";
            this.prodLabel.Size = new System.Drawing.Size(146, 25);
            this.prodLabel.TabIndex = 9;
            this.prodLabel.Text = "Производство";
            // 
            // firmLabel
            // 
            this.firmLabel.AutoSize = true;
            this.firmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firmLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.firmLabel.Location = new System.Drawing.Point(20, 133);
            this.firmLabel.Name = "firmLabel";
            this.firmLabel.Size = new System.Drawing.Size(69, 25);
            this.firmLabel.TabIndex = 4;
            this.firmLabel.Text = "Марка";
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modelLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.modelLabel.Location = new System.Drawing.Point(21, 172);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(84, 25);
            this.modelLabel.TabIndex = 5;
            this.modelLabel.Text = "Модель";
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bodyLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.bodyLabel.Location = new System.Drawing.Point(20, 258);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(46, 25);
            this.bodyLabel.TabIndex = 6;
            this.bodyLabel.Text = "Тип";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.yearLabel.Location = new System.Drawing.Point(20, 217);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(126, 25);
            this.yearLabel.TabIndex = 10;
            this.yearLabel.Text = "Год выпуска";
            // 
            // carBodyLabel
            // 
            this.carBodyLabel.AutoSize = true;
            this.carBodyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.carBodyLabel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.carBodyLabel.Location = new System.Drawing.Point(209, 258);
            this.carBodyLabel.Name = "carBodyLabel";
            this.carBodyLabel.Size = new System.Drawing.Size(0, 25);
            this.carBodyLabel.TabIndex = 13;
            this.carBodyLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // carProducterLabel
            // 
            this.carProducterLabel.AutoSize = true;
            this.carProducterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.carProducterLabel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.carProducterLabel.Location = new System.Drawing.Point(209, 346);
            this.carProducterLabel.Name = "carProducterLabel";
            this.carProducterLabel.Size = new System.Drawing.Size(0, 25);
            this.carProducterLabel.TabIndex = 15;
            this.carProducterLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // carEngineLabel
            // 
            this.carEngineLabel.AutoSize = true;
            this.carEngineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.carEngineLabel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.carEngineLabel.Location = new System.Drawing.Point(209, 304);
            this.carEngineLabel.Name = "carEngineLabel";
            this.carEngineLabel.Size = new System.Drawing.Size(0, 25);
            this.carEngineLabel.TabIndex = 16;
            this.carEngineLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // carFirmTextBox
            // 
            this.carFirmTextBox.Location = new System.Drawing.Point(215, 132);
            this.carFirmTextBox.Name = "carFirmTextBox";
            this.carFirmTextBox.Size = new System.Drawing.Size(100, 26);
            this.carFirmTextBox.TabIndex = 17;
            // 
            // carModelTextBox
            // 
            this.carModelTextBox.Location = new System.Drawing.Point(215, 172);
            this.carModelTextBox.Name = "carModelTextBox";
            this.carModelTextBox.Size = new System.Drawing.Size(100, 26);
            this.carModelTextBox.TabIndex = 18;
            // 
            // carYearTextBox
            // 
            this.carYearTextBox.Location = new System.Drawing.Point(214, 216);
            this.carYearTextBox.Name = "carYearTextBox";
            this.carYearTextBox.Size = new System.Drawing.Size(100, 26);
            this.carYearTextBox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(629, 401);
            this.Controls.Add(this.carYearTextBox);
            this.Controls.Add(this.carModelTextBox);
            this.Controls.Add(this.carFirmTextBox);
            this.Controls.Add(this.carEngineLabel);
            this.Controls.Add(this.carProducterLabel);
            this.Controls.Add(this.carBodyLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.prodLabel);
            this.Controls.Add(this.engienLabel);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.firmLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.VINMaskedTextBox);
            this.Controls.Add(this.VINlable);
            this.Name = "Form1";
            this.Text = "VIN-расшифровщик";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VINlable;
        private System.Windows.Forms.MaskedTextBox VINMaskedTextBox;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label engienLabel;
        private System.Windows.Forms.Label prodLabel;
        private System.Windows.Forms.Label firmLabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label carBodyLabel;
        private System.Windows.Forms.Label carProducterLabel;
        private System.Windows.Forms.Label carEngineLabel;
        private System.Windows.Forms.TextBox carFirmTextBox;
        private System.Windows.Forms.TextBox carModelTextBox;
        private System.Windows.Forms.TextBox carYearTextBox;
    }
}

