using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    partial class GameForm
    {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLACK_OOPS_Arkanoid.GameForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playground = new System.Windows.Forms.Panel();
            this.ball = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.playground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.player)).BeginInit();
            this.SuspendLayout();
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.playground, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 554);
            this.tableLayoutPanel1.TabIndex = 1;
            this.playground.BackColor = System.Drawing.Color.Black;
            this.playground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playground.Controls.Add(this.ball);
            this.playground.Controls.Add(this.player);
            this.playground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground.Location = new System.Drawing.Point(1, 1);
            this.playground.Margin = new System.Windows.Forms.Padding(1);
            this.playground.Name = "playground";
            this.playground.Size = new System.Drawing.Size(851, 552);
            this.playground.TabIndex = 0;
            this.playground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playground_MouseMove);
            this.ball.BackColor = System.Drawing.Color.Transparent;
            this.ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ball.Image = ((System.Drawing.Image) (resources.GetObject("ball.Image")));
            this.ball.Location = new System.Drawing.Point(396, 428);
            this.ball.Margin = new System.Windows.Forms.Padding(4);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(40, 37);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.player.Image = ((System.Drawing.Image) (resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(292, 473);
            this.player.Margin = new System.Windows.Forms.Padding(4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(265, 65);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameForm";
            this.Text = "Arkanoid";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.playground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.player)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Panel playground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;

        #endregion
    }
}