namespace Desktop_App
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
            ourDate = new DateTimePicker();
            getAvailableRoomsBtn = new Button();
            outputBox1 = new RichTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // ourDate
            // 
            ourDate.Format = DateTimePickerFormat.Short;
            ourDate.Location = new Point(85, 100);
            ourDate.Name = "ourDate";
            ourDate.Size = new Size(192, 23);
            ourDate.TabIndex = 0;
            // 
            // getAvailableRoomsBtn
            // 
            getAvailableRoomsBtn.BackColor = Color.Tomato;
            getAvailableRoomsBtn.ForeColor = SystemColors.Control;
            getAvailableRoomsBtn.Location = new Point(578, 98);
            getAvailableRoomsBtn.Name = "getAvailableRoomsBtn";
            getAvailableRoomsBtn.Size = new Size(152, 30);
            getAvailableRoomsBtn.TabIndex = 1;
            getAvailableRoomsBtn.Text = "View Available Rooms";
            getAvailableRoomsBtn.UseVisualStyleBackColor = false;
            getAvailableRoomsBtn.Click += getAvailableRoomsBtn_Click;
            // 
            // outputBox1
            // 
            outputBox1.Location = new Point(85, 138);
            outputBox1.Name = "outputBox1";
            outputBox1.Size = new Size(645, 255);
            outputBox1.TabIndex = 2;
            outputBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Adobe Gothic Std B", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(73, 34);
            label1.Name = "label1";
            label1.Size = new Size(668, 40);
            label1.TabIndex = 3;
            label1.Text = "Welcome To Our Hotel Management System";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(outputBox1);
            Controls.Add(getAvailableRoomsBtn);
            Controls.Add(ourDate);
            Name = "Form1";
            Text = "Hotel Management System";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker ourDate;
        private Button getAvailableRoomsBtn;
        private RichTextBox outputBox1;
        private Label label1;
    }
}