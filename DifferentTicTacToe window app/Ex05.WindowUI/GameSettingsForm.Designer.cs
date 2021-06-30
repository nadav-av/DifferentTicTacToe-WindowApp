namespace Ex05.WindowUI
{
    public partial class GameSettingsForm
    {
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.Label labelHeadline;
        private System.Windows.Forms.Label LableP1;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.NumericUpDown upDownRows;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown upDownCols;
        private System.Windows.Forms.Button buttonStart;

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
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.labelHeadline = new System.Windows.Forms.Label();
            this.LableP1 = new System.Windows.Forms.Label();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.upDownRows = new System.Windows.Forms.NumericUpDown();
            this.labelRows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.upDownCols = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(118, 44);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(122, 23);
            this.textBoxPlayer1.TabIndex = 0;
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPlayer2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPlayer2.Location = new System.Drawing.Point(119, 78);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(121, 23);
            this.textBoxPlayer2.TabIndex = 2;
            this.textBoxPlayer2.Text = "[Computer]";
            this.textBoxPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(43, 80);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(70, 19);
            this.checkBoxPlayer2.TabIndex = 1;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkPlayer2_CheckedChangedOnce);
            // 
            // labelHeadline
            // 
            this.labelHeadline.AutoSize = true;
            this.labelHeadline.Location = new System.Drawing.Point(12, 9);
            this.labelHeadline.Name = "labelHeadline";
            this.labelHeadline.Size = new System.Drawing.Size(47, 15);
            this.labelHeadline.TabIndex = 3;
            this.labelHeadline.Text = "Players:";
            // 
            // LableP1
            // 
            this.LableP1.AutoSize = true;
            this.LableP1.Location = new System.Drawing.Point(43, 47);
            this.LableP1.Name = "LableP1";
            this.LableP1.Size = new System.Drawing.Size(51, 15);
            this.LableP1.TabIndex = 4;
            this.LableP1.Text = "Player 1:";
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(13, 130);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(64, 15);
            this.labelBoardSize.TabIndex = 5;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // upDownRows
            // 
            this.upDownRows.Location = new System.Drawing.Point(87, 166);
            this.upDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.upDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.upDownRows.Name = "upDownRows";
            this.upDownRows.Size = new System.Drawing.Size(41, 23);
            this.upDownRows.TabIndex = 3;
            this.upDownRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.upDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.upDownRows.ValueChanged += new System.EventHandler(this.numOfRows_Changed);
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelRows.Location = new System.Drawing.Point(43, 168);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(38, 15);
            this.labelRows.TabIndex = 8;
            this.labelRows.Text = "Rows:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cols:";
            // 
            // upDownCols
            // 
            this.upDownCols.Location = new System.Drawing.Point(199, 166);
            this.upDownCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.upDownCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.upDownCols.Name = "upDownCols";
            this.upDownCols.Size = new System.Drawing.Size(41, 23);
            this.upDownCols.TabIndex = 4;
            this.upDownCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.upDownCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.upDownCols.ValueChanged += new System.EventHandler(this.numOfCols_Changed);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Location = new System.Drawing.Point(13, 222);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(228, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.StartButton_Clicked);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(254, 256);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upDownCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.upDownRows);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.LableP1);
            this.Controls.Add(this.labelHeadline);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.upDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}