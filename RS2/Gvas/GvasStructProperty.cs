using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	abstract class GvasStructProperty : GvasProperty
	{
		public override object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public static GvasStructProperty[] CreateGvasProperties(uint address, String name, uint count)
		{
			// property's type length.
			var length = SaveData.Instance().ReadNumber(address, 4);
			address += 4;
			// type's name
			var type = SaveData.Instance().ReadText(address, length);
			address += length;

			var properties = new GvasStructProperty[count];
			address += 21;

			for (uint i = 0; i < count; i++)
			{
				// unique struct
				switch (type)
				{
					case "G01PartyCharaStatus":
						properties[i] = new Character();
						address = properties[i].Read(address);
						break;
				}
			}

			return properties;
		}
	}
}
