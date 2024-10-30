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
			// property's name
			var propName = Gvas.GetString(address);

			var properties = new GvasStructProperty[count];
			address += 21;

			for (uint i = 0; i < count; i++)
			{
				// unique struct
				switch (propName.name)
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
