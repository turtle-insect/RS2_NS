using RS2.Gvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2
{
	internal class Character : GvasStructProperty
	{
		public Gvas.GvasProperty? CharaText { get; set; }

		public Gvas.GvasProperty? HP { get; set; }
		public Gvas.GvasProperty? LP { get; set; }
		public Gvas.GvasProperty? BP { get; set; }
		public Gvas.GvasProperty? Strength { get; set; }
		public Gvas.GvasProperty? Dexterity { get; set; }
		public Gvas.GvasProperty? Magic { get; set; }
		public Gvas.GvasProperty? Intelligence { get; set; }
		public Gvas.GvasProperty? Speed { get; set; }
		public Gvas.GvasProperty? Stamina { get; set; }
		public Gvas.GvasProperty? DarkMagic { get; set; }
		public Gvas.GvasProperty? SpellPower { get; set; }

		// skill
		public Gvas.GvasProperty? SwordLevel { get; set; }
		public Gvas.GvasProperty? GreatswordLevel { get; set; }
		public Gvas.GvasProperty? AxeLevel { get; set; }
		public Gvas.GvasProperty? ClubLevel { get; set; }
		public Gvas.GvasProperty? SpearLevel { get; set; }
		public Gvas.GvasProperty? ShortswordLevel { get; set; }
		public Gvas.GvasProperty? BowLevel { get; set; }
		public Gvas.GvasProperty? MartialLevel { get; set; }

		// spell
		public Gvas.GvasProperty? FireLevel { get; set; }
		public Gvas.GvasProperty? WaterLevel { get; set; }
		public Gvas.GvasProperty? WindLevel { get; set; }
		public Gvas.GvasProperty? EarthLevel { get; set; }
		public Gvas.GvasProperty? DivineLevel { get; set; }
		public Gvas.GvasProperty? DarkLevel { get; set; }

		public override uint Read(uint address)
		{
			CharaText = Gvas.Gvas.CreateGvasProperty(address, "MCharaText");

			HP = Gvas.Gvas.CreateGvasProperty(address, "MHitPoint");
			LP = Gvas.Gvas.CreateGvasProperty(address, "MLifePoint");
			BP = Gvas.Gvas.CreateGvasProperty(address, "MBattlePoint");
			Strength = Gvas.Gvas.CreateGvasProperty(address, "MStrength");
			Dexterity = Gvas.Gvas.CreateGvasProperty(address, "MDexterity");
			Magic = Gvas.Gvas.CreateGvasProperty(address, "MMagic");
			Intelligence = Gvas.Gvas.CreateGvasProperty(address, "MIntelligence");
			Speed = Gvas.Gvas.CreateGvasProperty(address, "MSpeed");
			Stamina = Gvas.Gvas.CreateGvasProperty(address, "MStamina");
			DarkMagic = Gvas.Gvas.CreateGvasProperty(address, "MDarkMagic");
			SpellPower = Gvas.Gvas.CreateGvasProperty(address, "MSpellPower");

			// skill
			SwordLevel = Gvas.Gvas.CreateGvasProperty(address, "MSwordLevel");
			GreatswordLevel = Gvas.Gvas.CreateGvasProperty(address, "MGreatswordLevel");
			AxeLevel = Gvas.Gvas.CreateGvasProperty(address, "MAxeLevel");
			ClubLevel = Gvas.Gvas.CreateGvasProperty(address, "MClubLevel");
			SpearLevel = Gvas.Gvas.CreateGvasProperty(address, "MSpearLevel");
			ShortswordLevel = Gvas.Gvas.CreateGvasProperty(address, "MShortswordLevel");
			BowLevel = Gvas.Gvas.CreateGvasProperty(address, "MBowLevel");
			MartialLevel = Gvas.Gvas.CreateGvasProperty(address, "MMartialLevel");

			// spell
			FireLevel = Gvas.Gvas.CreateGvasProperty(address, "MFireLevel");
			WaterLevel = Gvas.Gvas.CreateGvasProperty(address, "MWaterLevel");
			WindLevel = Gvas.Gvas.CreateGvasProperty(address, "MWindLevel");
			EarthLevel = Gvas.Gvas.CreateGvasProperty(address, "MEarthLevel");
			DivineLevel = Gvas.Gvas.CreateGvasProperty(address, "MDivineLevel");
			DarkLevel = Gvas.Gvas.CreateGvasProperty(address, "MDarkLevel");

			return DarkLevel.Address;
		}
	}
}
