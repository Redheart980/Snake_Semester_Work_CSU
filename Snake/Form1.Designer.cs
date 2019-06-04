namespace Snake
{
    partial class Form_Snake
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Complexity = new System.Windows.Forms.TrackBar();
            this.Complexity_TextBox = new System.Windows.Forms.TextBox();
            this.ScoreText_TextBox = new System.Windows.Forms.TextBox();
            this.Score_TextBox = new System.Windows.Forms.TextBox();
            this.Start_button = new System.Windows.Forms.Button();
            this.Stop_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Complexity)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_tick);
            // 
            // Complexity
            // 
            this.Complexity.Location = new System.Drawing.Point(600, 100);
            this.Complexity.Margin = new System.Windows.Forms.Padding(0);
            this.Complexity.Maximum = 1000;
            this.Complexity.Minimum = 100;
            this.Complexity.Name = "Complexity";
            this.Complexity.Size = new System.Drawing.Size(172, 45);
            this.Complexity.SmallChange = 10;
            this.Complexity.TabIndex = 0;
            this.Complexity.TabStop = false;
            this.Complexity.TickFrequency = 20;
            this.Complexity.Value = 100;
            this.Complexity.ValueChanged += new System.EventHandler(this.Complexity_ValueChanged);
            // 
            // Complexity_TextBox
            // 
            this.Complexity_TextBox.BackColor = System.Drawing.SystemColors.Control;
            this.Complexity_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Complexity_TextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.Complexity_TextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Complexity_TextBox.Location = new System.Drawing.Point(634, 74);
            this.Complexity_TextBox.Name = "Complexity_TextBox";
            this.Complexity_TextBox.ReadOnly = true;
            this.Complexity_TextBox.Size = new System.Drawing.Size(100, 13);
            this.Complexity_TextBox.TabIndex = 1;
            this.Complexity_TextBox.TabStop = false;
            this.Complexity_TextBox.Text = "Сложность";
            this.Complexity_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ScoreText_TextBox
            // 
            this.ScoreText_TextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ScoreText_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScoreText_TextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ScoreText_TextBox.Location = new System.Drawing.Point(600, 148);
            this.ScoreText_TextBox.Name = "ScoreText_TextBox";
            this.ScoreText_TextBox.ReadOnly = true;
            this.ScoreText_TextBox.Size = new System.Drawing.Size(100, 13);
            this.ScoreText_TextBox.TabIndex = 2;
            this.ScoreText_TextBox.TabStop = false;
            this.ScoreText_TextBox.Text = "Очки:";
            // 
            // Score_TextBox
            // 
            this.Score_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score_TextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.Score_TextBox.ForeColor = System.Drawing.Color.Black;
            this.Score_TextBox.Location = new System.Drawing.Point(600, 167);
            this.Score_TextBox.Name = "Score_TextBox";
            this.Score_TextBox.ReadOnly = true;
            this.Score_TextBox.Size = new System.Drawing.Size(100, 13);
            this.Score_TextBox.TabIndex = 3;
            this.Score_TextBox.TabStop = false;
            this.Score_TextBox.Text = "0";
            // 
            // Start_button
            // 
            this.Start_button.Location = new System.Drawing.Point(600, 214);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(75, 23);
            this.Start_button.TabIndex = 4;
            this.Start_button.Text = "Начать";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // Stop_button
            // 
            this.Stop_button.Enabled = false;
            this.Stop_button.Location = new System.Drawing.Point(600, 243);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(75, 23);
            this.Stop_button.TabIndex = 5;
            this.Stop_button.Text = "Стоп";
            this.Stop_button.UseVisualStyleBackColor = true;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // Form_Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.Start_button);
            this.Controls.Add(this.Score_TextBox);
            this.Controls.Add(this.ScoreText_TextBox);
            this.Controls.Add(this.Complexity_TextBox);
            this.Controls.Add(this.Complexity);
            this.KeyPreview = true;
            this.Name = "Form_Snake";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control);
            ((System.ComponentModel.ISupportInitialize)(this.Complexity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TrackBar Complexity;
        private System.Windows.Forms.TextBox Complexity_TextBox;
        private System.Windows.Forms.TextBox ScoreText_TextBox;
        private System.Windows.Forms.TextBox Score_TextBox;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button Stop_button;
    }
}

