namespace laba7
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
            this.Removee = new System.Windows.Forms.Button();
            this.Replace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Removee
            // 
            this.Removee.Location = new System.Drawing.Point(118, 165);
            this.Removee.Name = "Removee";
            this.Removee.Size = new System.Drawing.Size(165, 77);
            this.Removee.TabIndex = 0;
            this.Removee.Text = "Remove";
            this.Removee.UseVisualStyleBackColor = true;
            this.Removee.Click += new System.EventHandler(this.Removee_Click);
            // 
            // Replace
            // 
            this.Replace.Location = new System.Drawing.Point(461, 165);
            this.Replace.Name = "Replace";
            this.Replace.Size = new System.Drawing.Size(175, 77);
            this.Replace.TabIndex = 1;
            this.Replace.Text = "Replace";
            this.Replace.UseVisualStyleBackColor = true;
            this.Replace.Click += new System.EventHandler(this.Replace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Replace);
            this.Controls.Add(this.Removee);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Removee;
        private System.Windows.Forms.Button Replace;
    }
}

