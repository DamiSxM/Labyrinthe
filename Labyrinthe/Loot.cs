﻿using System.Windows;
using System.Configuration;
using System;
using System.Runtime.Serialization;

namespace Labyrinthe
{
	enum Effet
	{
		VisionBonus = 0,
		VisionMalus = 1,
		VitesseBonus = 2,
		VitesseMalus = 3,
		ForceBonus = 4,
		ForceMalus = 5,
		Carte = 6,
		Cle = 7,
		Pic = 8,
	}
	public enum TypeLoot
	{
		Sort = 0,
		Etre = 1,
		Cle = 2,
		Porte = 3,
		Pic = 4
	}
    [Serializable]
	public class Loot
	{
		private string _name;
		internal static LootConstantes constantesLoot = new LootConstantes();

		//CONSTRUCTEURS
		public Loot() { }
		public Loot(string name) : this() { _name = name; }
        public Loot(SerializationInfo info, StreamingContext context) { }

        //ACCESSEURS
        public string name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		public TypeLoot TypeLoot
		{
			get
			{
				throw new System.NotImplementedException();
			}

			set
			{
			}
		}

		//METHODES
		public static bool IsNull(Loot loot)
		{
			return (loot == null);
		}		
	}
}