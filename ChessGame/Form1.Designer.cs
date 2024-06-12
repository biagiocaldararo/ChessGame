namespace ChessGame
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
            btn_NewGame = new Button();
            btn_Exit = new Button();
            btn_Concede = new Button();
            SuspendLayout();
            // 
            // btn_NewGame
            // 
            btn_NewGame.Location = new Point(21, 12);
            btn_NewGame.Name = "btn_NewGame";
            btn_NewGame.Size = new Size(167, 42);
            btn_NewGame.TabIndex = 0;
            btn_NewGame.Text = "New Game";
            btn_NewGame.UseVisualStyleBackColor = true;
            btn_NewGame.Click += Btn_NewGame_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(21, 108);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(167, 42);
            btn_Exit.TabIndex = 1;
            btn_Exit.Text = "Exit";
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += Btn_Exit_Click;
            // 
            // btn_Concede
            // 
            btn_Concede.Location = new Point(21, 60);
            btn_Concede.Name = "btn_Concede";
            btn_Concede.Size = new Size(167, 42);
            btn_Concede.TabIndex = 2;
            btn_Concede.Text = "Concede";
            btn_Concede.UseVisualStyleBackColor = true;
            btn_Concede.Visible = false;
            btn_Concede.Click += btn_Concede_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1439, 930);
            Controls.Add(btn_Concede);
            Controls.Add(btn_Exit);
            Controls.Add(btn_NewGame);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Form1";
            Text = "ChessGame";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_NewGame;
        private Button btn_Exit;
        private Button btn_Concede;
    }
}
