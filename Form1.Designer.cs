namespace TestTaskForActualTech
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
			this.CheckinWSListBox = new System.Windows.Forms.ListBox();
			this.WSNameTB = new System.Windows.Forms.TextBox();
			this.WSNameLabel = new System.Windows.Forms.Label();
			this.WSURLLabel = new System.Windows.Forms.Label();
			this.WSURLTB = new System.Windows.Forms.TextBox();
			this.TimeIntervalLabel = new System.Windows.Forms.Label();
			this.TimeIntervalTB = new System.Windows.Forms.TextBox();
			this.AddWSButton = new System.Windows.Forms.Button();
			this.SaveWSButton = new System.Windows.Forms.Button();
			this.DeleteWSButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CheckinWSListBox
			// 
			this.CheckinWSListBox.FormattingEnabled = true;
			this.CheckinWSListBox.Location = new System.Drawing.Point(248, 15);
			this.CheckinWSListBox.Name = "CheckinWSListBox";
			this.CheckinWSListBox.Size = new System.Drawing.Size(301, 186);
			this.CheckinWSListBox.TabIndex = 0;
			this.CheckinWSListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CheckinWSListBox_MouseDoubleClick);
			// 
			// WSNameTB
			// 
			this.WSNameTB.Location = new System.Drawing.Point(67, 15);
			this.WSNameTB.Name = "WSNameTB";
			this.WSNameTB.Size = new System.Drawing.Size(161, 20);
			this.WSNameTB.TabIndex = 1;
			// 
			// WSNameLabel
			// 
			this.WSNameLabel.AutoSize = true;
			this.WSNameLabel.Location = new System.Drawing.Point(4, 18);
			this.WSNameLabel.Name = "WSNameLabel";
			this.WSNameLabel.Size = new System.Drawing.Size(57, 13);
			this.WSNameLabel.TabIndex = 2;
			this.WSNameLabel.Text = "Название";
			// 
			// WSURLLabel
			// 
			this.WSURLLabel.AutoSize = true;
			this.WSURLLabel.Location = new System.Drawing.Point(7, 48);
			this.WSURLLabel.Name = "WSURLLabel";
			this.WSURLLabel.Size = new System.Drawing.Size(29, 13);
			this.WSURLLabel.TabIndex = 3;
			this.WSURLLabel.Text = "URL";
			// 
			// WSURLTB
			// 
			this.WSURLTB.Location = new System.Drawing.Point(67, 48);
			this.WSURLTB.Name = "WSURLTB";
			this.WSURLTB.Size = new System.Drawing.Size(161, 20);
			this.WSURLTB.TabIndex = 4;
			// 
			// TimeIntervalLabel
			// 
			this.TimeIntervalLabel.AutoSize = true;
			this.TimeIntervalLabel.Location = new System.Drawing.Point(7, 84);
			this.TimeIntervalLabel.Name = "TimeIntervalLabel";
			this.TimeIntervalLabel.Size = new System.Drawing.Size(127, 13);
			this.TimeIntervalLabel.TabIndex = 5;
			this.TimeIntervalLabel.Text = "Интервал запросов, мс";
			// 
			// TimeIntervalTB
			// 
			this.TimeIntervalTB.Location = new System.Drawing.Point(141, 84);
			this.TimeIntervalTB.Name = "TimeIntervalTB";
			this.TimeIntervalTB.Size = new System.Drawing.Size(87, 20);
			this.TimeIntervalTB.TabIndex = 6;
			// 
			// AddWSButton
			// 
			this.AddWSButton.Location = new System.Drawing.Point(12, 119);
			this.AddWSButton.Name = "AddWSButton";
			this.AddWSButton.Size = new System.Drawing.Size(87, 29);
			this.AddWSButton.TabIndex = 7;
			this.AddWSButton.Text = "Добавить";
			this.AddWSButton.UseVisualStyleBackColor = true;
			this.AddWSButton.Click += new System.EventHandler(this.AddWSButton_Click);
			// 
			// SaveWSButton
			// 
			this.SaveWSButton.Enabled = false;
			this.SaveWSButton.Location = new System.Drawing.Point(141, 119);
			this.SaveWSButton.Name = "SaveWSButton";
			this.SaveWSButton.Size = new System.Drawing.Size(87, 29);
			this.SaveWSButton.TabIndex = 8;
			this.SaveWSButton.Text = "Сохранить";
			this.SaveWSButton.UseVisualStyleBackColor = true;
			this.SaveWSButton.Click += new System.EventHandler(this.SaveWSButton_Click);
			// 
			// DeleteWSButton
			// 
			this.DeleteWSButton.Enabled = false;
			this.DeleteWSButton.Location = new System.Drawing.Point(248, 207);
			this.DeleteWSButton.Name = "DeleteWSButton";
			this.DeleteWSButton.Size = new System.Drawing.Size(87, 33);
			this.DeleteWSButton.TabIndex = 9;
			this.DeleteWSButton.Text = "Удалить";
			this.DeleteWSButton.UseVisualStyleBackColor = true;
			this.DeleteWSButton.Click += new System.EventHandler(this.DeleteWSButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 260);
			this.Controls.Add(this.DeleteWSButton);
			this.Controls.Add(this.SaveWSButton);
			this.Controls.Add(this.AddWSButton);
			this.Controls.Add(this.TimeIntervalTB);
			this.Controls.Add(this.TimeIntervalLabel);
			this.Controls.Add(this.WSURLTB);
			this.Controls.Add(this.WSURLLabel);
			this.Controls.Add(this.WSNameLabel);
			this.Controls.Add(this.WSNameTB);
			this.Controls.Add(this.CheckinWSListBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox CheckinWSListBox;
		private System.Windows.Forms.TextBox WSNameTB;
		private System.Windows.Forms.Label WSNameLabel;
		private System.Windows.Forms.Label WSURLLabel;
		private System.Windows.Forms.TextBox WSURLTB;
		private System.Windows.Forms.Label TimeIntervalLabel;
		private System.Windows.Forms.TextBox TimeIntervalTB;
		private System.Windows.Forms.Button AddWSButton;
		private System.Windows.Forms.Button SaveWSButton;
		private System.Windows.Forms.Button DeleteWSButton;
	}
}

