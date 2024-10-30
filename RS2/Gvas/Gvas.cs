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
			address = list[0] - 4;

			// property's name
			var propName = GetString(address);

			// property's type
			address += propName.length;
			var propType = GetString(address);
			address += propType.length;

			GvasProperty property = new GvasNoneProperty();
			switch (propType.name)
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

		// (String, uint) -> name, address
		public static (String name, uint length) GetString(uint address)
		{
			uint length = SaveData.Instance().ReadNumber(address, 4);
			String name = SaveData.Instance().ReadText(address + 4, length);
			return (name, length + 4);
		}
	}
}
