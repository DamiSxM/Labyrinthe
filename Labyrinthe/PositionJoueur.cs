using System.Windows;
using System;
using System.Runtime.Serialization;

namespace Labyrinthe
{
    [Serializable]
    public class PositionJoueur
    {
        private Point _position;
        private string _adresse;

        public string Adresse
        {
            get
            {
                return _adresse;
            }

            set
            {
                _adresse = value;
            }
        }

        public Point Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public PositionJoueur(string sender, Point data)
        {
            this.Adresse = sender;
            this.Position = data;
        }
        public PositionJoueur(SerializationInfo info, StreamingContext context) { }

    }
}