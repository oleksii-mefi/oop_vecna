namespace lab9
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        
        /// <param name="disposing"
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateCustom = new System.Windows.Forms.Button();
            this.btnCreateDefault = new System.Windows.Forms.Button();
            this.lblCounterState = new System.Windows.Forms.Label();
            this.txtMinValue = new System.Windows.Forms.TextBox();
            this.txtInitialValue = new System.Windows.Forms.TextBox();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "зменшити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "збільшити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ЛІЧИЛЬНИК";
            // 
            // btnCreateCustom
            // 
            this.btnCreateCustom.Location = new System.Drawing.Point(33, 306);
            this.btnCreateCustom.Name = "btnCreateCustom";
            this.btnCreateCustom.Size = new System.Drawing.Size(270, 37);
            this.btnCreateCustom.TabIndex = 7;
            this.btnCreateCustom.Text = "Створити довільний";
            this.btnCreateCustom.UseVisualStyleBackColor = true;
            this.btnCreateCustom.Click += new System.EventHandler(this.btnCreateCustom_Click);
            // 
            // btnCreateDefault
            // 
            this.btnCreateDefault.Location = new System.Drawing.Point(343, 306);
            this.btnCreateDefault.Name = "btnCreateDefault";
            this.btnCreateDefault.Size = new System.Drawing.Size(270, 37);
            this.btnCreateDefault.TabIndex = 8;
            this.btnCreateDefault.Text = "Створити за замовчуванням";
            this.btnCreateDefault.UseVisualStyleBackColor = true;
            this.btnCreateDefault.Click += new System.EventHandler(this.btnCreateDefault_Click);
            // 
            // lblCounterState
            // 
            this.lblCounterState.AutoSize = true;
            this.lblCounterState.Location = new System.Drawing.Point(293, 122);
            this.lblCounterState.Name = "lblCounterState";
            this.lblCounterState.Size = new System.Drawing.Size(44, 16);
            this.lblCounterState.TabIndex = 9;
            this.lblCounterState.Text = "label4";
            // 
            // txtMinValue
            // 
            this.txtMinValue.Location = new System.Drawing.Point(75, 198);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(134, 22);
            this.txtMinValue.TabIndex = 10;
            // 
            // txtInitialValue
            // 
            this.txtInitialValue.Location = new System.Drawing.Point(254, 198);
            this.txtInitialValue.Name = "txtInitialValue";
            this.txtInitialValue.Size = new System.Drawing.Size(129, 22);
            this.txtInitialValue.TabIndex = 11;
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.Location = new System.Drawing.Point(425, 198);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(141, 22);
            this.txtMaxValue.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMaxValue);
            this.Controls.Add(this.txtInitialValue);
            this.Controls.Add(this.txtMinValue);
            this.Controls.Add(this.lblCounterState);
            this.Controls.Add(this.btnCreateDefault);
            this.Controls.Add(this.btnCreateCustom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateCustom;
        private System.Windows.Forms.Button btnCreateDefault;
        private System.Windows.Forms.Label lblCounterState;
        private System.Windows.Forms.TextBox txtMinValue;
        private System.Windows.Forms.TextBox txtInitialValue;
        private System.Windows.Forms.TextBox txtMaxValue;
    }
}

