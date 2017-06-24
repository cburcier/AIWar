using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIWar;

namespace TheGUI
{
    public partial class Board : Form
    {
        AIWar.GameMaster _gm;
        Thread _game;
        bool _pause = false;
        bool _closed = false;
        double _displaySpeed = 1;

        public Board()
        {
            InitializeComponent();
            //TO DO load config
            _gm = new AIWar.GameMaster();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            BoardPicture.Update();
            if (!_gm.HasInit())
            {
                _gm.Init();
                _game = new Thread(Run);
                _game.Start();
            }
            _pause = false;
        }

        private void Run()
        {
            while (!_closed)
            {
                if(!_pause)
                {
                    _gm.NextStep();
                    BoardPicture.Invalidate();
                }
                Thread.Sleep((int)(_gm.TimeStep * 1000/_displaySpeed));
            }
        }

        private void BoardPicture_SizeChanged(object sender, EventArgs e)
        {
            BoardPicture.Refresh();
        }

        private void BoardPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (_gm != null && _gm.HasInit())
            {
                Graphics g = e.Graphics;
                g.Clear(Color.LightGray);
                Pen p = new Pen(Color.Red, 3);
                //brrrr
                AIWar.Rectangle board = (AIWar.Rectangle)_gm.GetBoard();
                g.ScaleTransform((float)(BoardPicture.Width / board.W.x), (float)(BoardPicture.Height / board.H.y));
                g.DrawRectangle(p, 0, 0, (int)(board.W.x), (int)(board.H.y));

                foreach (Drawable d in _gm.GetDrawables())
                {
                    DrawDrawable(d, ref g);
                }
            }
        }

        //la fonction dur a prononcer:
        private void DrawDrawable(Drawable d, ref Graphics g)
        {
            if (d.ElemShape.GetType() == typeof(AIWar.Rectangle))
            {
                AIWar.Rectangle shape = (AIWar.Rectangle) d.ElemShape;
                
                if (d.Type == AIWar.DrawableType.full)
                {
                    Brush p = new SolidBrush(d.Color);
                    g.FillRectangle(p, (float)d.Position.x, (float)d.Position.y, (int)(shape.W.x), (int)(shape.H.y));
                }
                else
                {
                    Pen p = new Pen(d.Color, d.PenWidth);
                    g.DrawRectangle(p, (float)d.Position.x, (float)d.Position.y, (int)(shape.W.x), (int)(shape.H.y));
                }
            }
            else if (d.ElemShape.GetType() == typeof(AIWar.Circle))
            {
                AIWar.Circle shape = (AIWar.Circle)d.ElemShape;
                if (d.Type==AIWar.DrawableType.full)
                {
                    Brush p = new SolidBrush(Color.Blue);
                    g.FillEllipse(p, (float)(d.Position.x - shape.Radius), (float)(d.Position.y + shape.Radius), (float)(shape.Radius * 2), (float)(shape.Radius * 2));
                }
                else
                {
                    Pen p = new Pen(Color.Blue, 1);
                    g.DrawEllipse(p, (float)(d.Position.x - shape.Radius), (float)(d.Position.y + shape.Radius), (float)(shape.Radius * 2), (float)(shape.Radius * 2));
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _pause = !_pause;
        }

        private void Board_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closed = true;
        }
    }
}
