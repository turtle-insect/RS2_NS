using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal class Gvas
	{
		public static GvasProperty CreateGvasProperty(uint address, String name)
		{
			var list = SaveData.Instance().FindAddress(name, address);
			if (list.Count == 0)
			{
				return new GvasNoneProperty();
			}

			// property's type length.
			address = list[0] - 4;
			var length = SaveData.Instance().ReadNumber(address, 4);
			address = list[0] + length;
			length = SaveData.Instance().ReadNumber(address, 4);
			address += 4;
			// property's type
			var type = SaveData.Instance().ReadText(address, length);
			address += length;

			GvasProperty property = new GvasNoneProperty();
			switch (type)
			{
				case "IntProperty":
					property = new GvasIntProperty();
					break;

				case "TextProperty":
					property = new GvasTextProperty();
					break;

				case "ArrayProperty":
					property = new GvasArrayProperty();
					break;
			}

			property.Address = address;
			property.Name = name;
			property.Read(address);
			return property;
		}
	}
}
