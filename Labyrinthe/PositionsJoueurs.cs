using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using System;

namespace Labyrinthe
{
    [Serializable]
    public class PositionsJoueurs : Dictionary<Point,string>
    {
        public PositionsJoueurs() : base() { }
        public PositionsJoueurs(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}