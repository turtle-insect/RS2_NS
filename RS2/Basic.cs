using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2
{
	internal class Basic
	{
		public Gvas.IValueElement Crown { get; init; }
		public Gvas.IValueElement TotalBattleCount { get; init; }
		public Gvas.IValueElement TotalBattleWinCount { get; init; }

		public Basic()
		{
			// money
			// G01GamePlayDataSaveInfo -> Crown
			var addresses = SaveData.Instance().FindAddress("G01GamePlayDataSaveInfo", 0);
			if (addresses.Count > 0)
			{
				Crown = Gvas.GvasProperty.CreateGvasProperty(addresses[0], "Crown");
				TotalBattleCount = Gvas.GvasProperty.CreateGvasProperty(addresses[0], "TotalBattleCount");
				TotalBattleWinCount = Gvas.GvasProperty.CreateGvasProperty(addresses[0], "TotalBattleWinCount");
			}
			else
			{
				Crown = new Gvas.GvasNoneProperty();
				TotalBattleCount = new Gvas.GvasNoneProperty();
				TotalBattleWinCount = new Gvas.GvasNoneProperty();
			}
		}
	}
}
