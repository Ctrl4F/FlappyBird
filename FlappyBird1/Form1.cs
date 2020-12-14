using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird1
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int pipeSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            PipeTop.Left -= pipeSpeed;
            PipeBottom.Left -= pipeSpeed;
            ScoreLabel.Text = $"Score: {score}";
            if(PipeTop.Left < -60)
            {
                PipeTop.Left = 500;
                score++;
            }
            if(PipeBottom.Left < -60)
            {
                PipeBottom.Left = 500;
                score++;
            }
            if(Bird.Top < -25)
            {
                GameOver();
            }
            if (Bird.Bounds.IntersectsWith(PipeTop.Bounds) || Bird.Bounds.IntersectsWith(PipeBottom.Bounds) || Bird.Bounds.IntersectsWith(Grounds.Bounds))
            {
                GameOver();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
        private void GameOver()
        {
            timer1.Stop();
            ScoreLabel.Text = $"Game Over";
            playAgain.Visible = true;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Dispose(false);
        }
    }
}
