using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIWar;

namespace TheGUI
{
    public partial class Board : Form, AIWar.IUniverseObserver
    {
        AIWar.GameMaster _gm;
        private Dictionary<int, Drawable> _elems;
        private double _drawingScale = 10; //meter to pixel

        public double DrawingScale { get => _drawingScale;}

        public Board()
        {
            InitializeComponent();
            //TO DO load config

            _gm = new AIWar.GameMaster();
            _gm.Init();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            BoardPicture_Paint(this, null);
        }

        private void BoardPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = BoardPicture.CreateGraphics();
            g.Clear(Color.LightGray);
            Pen p = new Pen(Color.Red, 3);
            //brrrr
            AIWar.Rectangle board = (AIWar.Rectangle)_gm.GetBoard();
            _drawingScale = Math.Min(BoardPicture.Width / board.W.x, BoardPicture.Height / board.H.y);
            g.DrawRectangle(p,0,0, (int)(board.W.x * DrawingScale), (int)(board.H.y * DrawingScale));
        }

        public void UpdateDrawable(Drawable d)
        {
            _elems[d.Id] = d;
        }

        //la fonction dur a prononcer:
        public void DrawDrawable(Drawable d)
        {

        }

    }
}
