using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AIWar
{
    public enum DrawableType { empty,full }
    public class Drawable
    {
        static Color[] TeamColor = new Color[4] { Color.Blue, Color.Green, Color.Orange, Color.Black };

        Shape _elemShape;
        Vector _position;
        int _id;
        DrawableType _type;
        Color _color;
        float _penWidth;

        public Drawable(int id, Shape s, Vector p)
        {
            _elemShape = s;
            _position = p;
            _type = DrawableType.full;
            _id = id;
            _color = Color.Blue;
            _penWidth = 1;
        }

        public Shape ElemShape { get => _elemShape;}
        public Vector Position { get => _position;}
        public DrawableType Type { get => _type;}
        public int Id { get => _id;}
        public Color Color { get => _color; set => _color = value; }
        public float PenWidth { get => _penWidth; set => _penWidth = value; }

    }
}
