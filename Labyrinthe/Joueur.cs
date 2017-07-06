﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace Labyrinthe
{
    public enum Direction
    {
        HAUT = 0,
        DROITE = 1,
        BAS = 2,
        GAUCHE = 3,
        AUTRE = 666
    }
    public class Joueur
    {
        Point _position = new Point(0,0);
        int _vision = 1;
        decimal _vitesse, _force;
        Inventaire _inventaire /*= new Inventaire()*/;
        bool _carte = false;
        MyLabyrinthe _tableau;

        MyLabyrinthe _carteLaby;

            public Joueur()
        {
            _inventaire = new Inventaire();
        }

        public void Deplacement(Direction d)
        {
            if (!isMur(d))
            {
                switch (d)
                {
                    case Direction.HAUT:
                        Position = new Point(Position.X, Position.Y - 1);
                        break;
                    case Direction.DROITE:
                        Position = new Point(Position.X + 1, Position.Y);
                        break;
                    case Direction.BAS:
                        Position = new Point(Position.X, Position.Y + 1);
                        break;
                    case Direction.GAUCHE:
                        Position = new Point(Position.X - 1, Position.Y);
                        break;
                }
                ModificationCarte(Position, Vision);
            }
        }

        /// <summary>
        /// Retourne si le mouvement peut être fait
        /// </summary>
        /// <param name="d">Direction</param>
        /// <returns></returns>
        public bool isMur(Direction d)
        {
            switch (d)
            {
                case Direction.HAUT:
                    if (Position.Y == 0)
                        return true;
                    else return (Laby.Tableau[(int)Position.X, (int)Position.Y - 1]);
                case Direction.DROITE:
                    if (Position.X == Laby.Tableau.GetLength(0)-1)
                        return true;
                    else return (Laby.Tableau[(int)Position.X + 1, (int)Position.Y]);
                case Direction.BAS:
                    if (Position.Y == Laby.Tableau.GetLength(1)-1)
                        return true;
                    else return (Laby.Tableau[(int)Position.X, (int)Position.Y + 1]);
                case Direction.GAUCHE:
                    if (Position.X == 0)
                        return true;
                    else return (Laby.Tableau[(int)Position.X - 1, (int)Position.Y]);
            }
            return false;
        }
        #region get/set
        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        public int Vision
        {
            get { return _vision; }
            set { _vision = value; }
        }

        public decimal Vitesse
        {
            get { return _vitesse; }
            set { _vitesse = value; }
        }

        public decimal Force
        {
            get { return _force; }
            set { _force = value; }
        }

        public Inventaire Inventaire
        {
            get { return _inventaire; }
            set { _inventaire = value;}
        }

        public MyLabyrinthe Laby
        {
            get
            {
                return _tableau;
            }

            set
            {
                _tableau = value;
            }
        }

        public MyLabyrinthe CarteLaby
        {
            get
            {
                return _carteLaby;
            }

            set
            {
                _carteLaby = value;
            }
        }

        public bool Carte
        {
            get
            {
                return _carte;
            }

            set
            {
                _carte = value;
            }
        }
        #endregion
        public void ModificationCarte(Point position, int Vision)
        {
            for (int i = 0-Vision; i < 0+Vision+1; i++)
                for (int j = 0-Vision; j<0+Vision+1;j++)
                    CarteLaby.ModifierLabyrinthe((int)position.X+i, (int)position.Y+j, true);
                        
        }

        public void InitialisationCarte()
        {
            CarteLaby = new MyLabyrinthe();
            CarteLaby.Tableau = new bool[Laby.Tableau.GetLength(0), Laby.Tableau.GetLength(1)];
            for (int i = 0; i < Laby.Tableau.GetLength(0); i++)
                for (int j = 0; j < Laby.Tableau.GetLength(1); j++)
                    CarteLaby.ModifierLabyrinthe(i, j, false);
        }

        public void SubirEffet(Loot loot)
        {
            if (loot.name == "Pilule de vision")
                Vision++;
            if (loot.name == "Carte")
                Carte = true;
        }
    }
}
