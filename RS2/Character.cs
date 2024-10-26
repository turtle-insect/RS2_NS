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

		// skill
		public Gvas.IValueElement SwordLevel { get; init; }
		public Gvas.IValueElement GreatswordLevel { get; init; }
		public Gvas.IValueElement AxeLevel { get; init; }
		public Gvas.IValueElement ClubLevel { get; init; }
		public Gvas.IValueElement SpearLevel { get; init; }
		public Gvas.IValueElement ShortswordLevel { get; init; }
		public Gvas.IValueElement BowLevel { get; init; }
		public Gvas.IValueElement MartialLevel { get; init; }

		// spell
		public Gvas.IValueElement FireLevel { get; init; }
		public Gvas.IValueElement WaterLevel { get; init; }
		public Gvas.IValueElement WindLevel { get; init; }
		public Gvas.IValueElement EarthLevel { get; init; }
		public Gvas.IValueElement DivineLevel { get; init; }
		public Gvas.IValueElement DarkLevel { get; init; }

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

			// skill
			SwordLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MSwordLevel");
			GreatswordLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MGreatswordLevel");
			AxeLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MAxeLevel");
			ClubLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MClubLevel");
			SpearLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MSpearLevel");
			ShortswordLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MShortswordLevel");
			BowLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MBowLevel");
			MartialLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MMartialLevel");

			// spell
			FireLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MFireLevel");
			WaterLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MWaterLevel");
			WindLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MWindLevel");
			EarthLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MEarthLevel");
			DivineLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MDivineLevel");
			DarkLevel = Gvas.GvasProperty.CreateGvasProperty(address, "MDarkLevel");
		}
	}
}
