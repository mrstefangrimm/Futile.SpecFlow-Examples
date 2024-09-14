
namespace WinFormsCalculator
{
    partial class CalculatorForm
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
    private void InitializeComponent() {
      label_firstNumber = new System.Windows.Forms.Label();
      textBox_firstNumber = new System.Windows.Forms.TextBox();
      textBox_secondNumber = new System.Windows.Forms.TextBox();
      label_secondNumber = new System.Windows.Forms.Label();
      button_add = new System.Windows.Forms.Button();
      button_subtract = new System.Windows.Forms.Button();
      button_multiply = new System.Windows.Forms.Button();
      button_divide = new System.Windows.Forms.Button();
      textBox_result = new System.Windows.Forms.TextBox();
      label_result = new System.Windows.Forms.Label();
      SuspendLayout();
      // 
      // label_firstNumber
      // 
      label_firstNumber.AutoSize = true;
      label_firstNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      label_firstNumber.Location = new System.Drawing.Point(12, 97);
      label_firstNumber.Name = "label_firstNumber";
      label_firstNumber.Size = new System.Drawing.Size(102, 20);
      label_firstNumber.TabIndex = 0;
      label_firstNumber.Text = "First number:";
      // 
      // textBox_firstNumber
      // 
      textBox_firstNumber.Location = new System.Drawing.Point(142, 93);
      textBox_firstNumber.Name = "textBox_firstNumber";
      textBox_firstNumber.Size = new System.Drawing.Size(100, 23);
      textBox_firstNumber.TabIndex = 1;
      // 
      // textBox_secondNumber
      // 
      textBox_secondNumber.Location = new System.Drawing.Point(142, 122);
      textBox_secondNumber.Name = "textBox_secondNumber";
      textBox_secondNumber.Size = new System.Drawing.Size(100, 23);
      textBox_secondNumber.TabIndex = 3;
      // 
      // label_secondNumber
      // 
      label_secondNumber.AutoSize = true;
      label_secondNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      label_secondNumber.Location = new System.Drawing.Point(12, 126);
      label_secondNumber.Name = "label_secondNumber";
      label_secondNumber.Size = new System.Drawing.Size(126, 20);
      label_secondNumber.TabIndex = 2;
      label_secondNumber.Text = "Second number:";
      // 
      // button_add
      // 
      button_add.Location = new System.Drawing.Point(50, 160);
      button_add.Name = "button_add";
      button_add.Size = new System.Drawing.Size(75, 23);
      button_add.TabIndex = 4;
      button_add.Text = "Add";
      button_add.UseVisualStyleBackColor = true;
      button_add.Click += button_add_Click;
      // 
      // button_subtract
      // 
      button_subtract.Location = new System.Drawing.Point(131, 160);
      button_subtract.Name = "button_subtract";
      button_subtract.Size = new System.Drawing.Size(75, 23);
      button_subtract.TabIndex = 5;
      button_subtract.Text = "Subtract";
      button_subtract.UseVisualStyleBackColor = true;
      button_subtract.Click += button_subtract_Click;
      // 
      // button_multiply
      // 
      button_multiply.Location = new System.Drawing.Point(50, 189);
      button_multiply.Name = "button_multiply";
      button_multiply.Size = new System.Drawing.Size(75, 23);
      button_multiply.TabIndex = 6;
      button_multiply.Text = "Multiply";
      button_multiply.UseVisualStyleBackColor = true;
      button_multiply.Click += button_multiply_Click;
      // 
      // button_divide
      // 
      button_divide.Location = new System.Drawing.Point(131, 189);
      button_divide.Name = "button_divide";
      button_divide.Size = new System.Drawing.Size(75, 23);
      button_divide.TabIndex = 7;
      button_divide.Text = "Divide";
      button_divide.UseVisualStyleBackColor = true;
      button_divide.Click += button_divide_Click;
      // 
      // textBox_result
      // 
      textBox_result.Location = new System.Drawing.Point(104, 231);
      textBox_result.Name = "textBox_result";
      textBox_result.ReadOnly = true;
      textBox_result.Size = new System.Drawing.Size(100, 23);
      textBox_result.TabIndex = 9;
      // 
      // label_result
      // 
      label_result.AutoSize = true;
      label_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      label_result.Location = new System.Drawing.Point(50, 235);
      label_result.Name = "label_result";
      label_result.Size = new System.Drawing.Size(59, 20);
      label_result.TabIndex = 8;
      label_result.Text = "Result:";
      // 
      // CalculatorForm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      BackColor = System.Drawing.Color.White;
      ClientSize = new System.Drawing.Size(260, 277);
      Controls.Add(textBox_result);
      Controls.Add(label_result);
      Controls.Add(button_divide);
      Controls.Add(button_multiply);
      Controls.Add(button_subtract);
      Controls.Add(button_add);
      Controls.Add(textBox_secondNumber);
      Controls.Add(label_secondNumber);
      Controls.Add(textBox_firstNumber);
      Controls.Add(label_firstNumber);
      Name = "CalculatorForm";
      Text = "Form1";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label label_firstNumber;
        private System.Windows.Forms.TextBox textBox_firstNumber;
        private System.Windows.Forms.TextBox textBox_secondNumber;
        private System.Windows.Forms.Label label_secondNumber;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_subtract;
        private System.Windows.Forms.Button button_multiply;
        private System.Windows.Forms.Button button_divide;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Label label_result;
    }
}

