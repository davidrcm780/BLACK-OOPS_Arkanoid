using System.ComponentModel;

namespace BLACK_OOPS_Arkanoid
{
    partial class firstMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(firstMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.scoresButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(246, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Black;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.PlayButton.ForeColor = System.Drawing.Color.White;
            this.PlayButton.Location = new System.Drawing.Point(355, 193);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(180, 44);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "JUGAR";
            this.PlayButton.UseVisualStyleBackColor = false;
            // 
            // scoresButton
            // 
            this.scoresButton.BackColor = System.Drawing.Color.Black;
            this.scoresButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scoresButton.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.scoresButton.ForeColor = System.Drawing.Color.White;
            this.scoresButton.Location = new System.Drawing.Point(355, 277);
            this.scoresButton.Name = "scoresButton";
            this.scoresButton.Size = new System.Drawing.Size(180, 44);
            this.scoresButton.TabIndex = 2;
            this.scoresButton.Text = "PUNTAJES";
            this.scoresButton.UseVisualStyleBackColor = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Black;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(355, 357);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(180, 44);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "SALIR";
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // firstMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.scoresButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "firstMenu";
            this.Size = new System.Drawing.Size(882, 498);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button scoresButton;

        #endregion
    }
}