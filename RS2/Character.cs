using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2
{
	internal class Character
	{
		public Gvas.IValueElement HP { get; init; }
		public Gvas.IValueElement LP { get; init; }
		public Gvas.IValueElement BP { get; init; }
		public Gvas.IValueElement Strength { get; init; }
		public Gvas.IValueElement Dexterity { get; init; }
		public Gvas.IValueElement Magic { get; init; }
		public Gvas.IValueElement Intelligence { get; init; }
		public Gvas.IValueElement Speed { get; init; }
		public Gvas.IValueElement Stamina { get; init; }
		public Gvas.IValueElement DarkMagic { get; init; }
		public Gvas.IValueElement SpellPower { get; init; }

		public Character(uint address)
		{
			HP = Gvas.GvasProperty.CreateGvasProperty(address, "MHitPoint");
			LP = Gvas.GvasProperty.CreateGvasProperty(address, "MLifePoint");
			BP = Gvas.GvasProperty.CreateGvasProperty(address, "MBattlePoint");
			Strength = Gvas.GvasProperty.CreateGvasProperty(address, "MStrength");
			Dexterity = Gvas.GvasProperty.CreateGvasProperty(address, "MDexterity");
			Magic = Gvas.GvasProperty.CreateGvasProperty(address, "MMagic");
			Intelligence = Gvas.GvasProperty.CreateGvasProperty(address, "MIntelligence");
			Speed = Gvas.GvasProperty.CreateGvasProperty(address, "MSpeed");
			Stamina = Gvas.GvasProperty.CreateGvasProperty(address, "MStamina");
			DarkMagic = Gvas.GvasProperty.CreateGvasProperty(address, "MDarkMagic");
			SpellPower = Gvas.GvasProperty.CreateGvasProperty(address, "MSpellPower");
		}
	}
}
