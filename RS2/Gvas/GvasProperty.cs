using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal class GvasProperty
	{
		private readonly uint mAddress;

		public static IValueElement CreateGvasProperty(uint bassAddress, String name)
		{
			var list = SaveData.Instance().FindAddress(name, bassAddress);
			if(list.Count == 0)
			{
				return new GvasNoneProperty();
			}

			// "IntProperty".Length -> 4Byte
			// String IntProperty -> 12Byte
			
			// 型チェック
			// check name length.
			var address = list[0] - 4;
			var length = SaveData.Instance().ReadNumber(address, 4);
			address = list[0] + length;
			length = SaveData.Instance().ReadNumber(address, 4);
			address += 4;
			// check name's type
			var type = SaveData.Instance().ReadText(address, length);
			address += length;
			switch (type)
			{
				case "IntProperty":
					// Size -> 4Byte
					// ??? -> 5Byte
					return new GvasIntProperty(address + 9, name);
			}
			return new GvasNoneProperty();
		}
	}
}
