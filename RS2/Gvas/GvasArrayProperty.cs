using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	class GvasArrayProperty : GvasProperty
	{
		private GvasProperty[] mProperties = [];
		public override uint Read(uint address)
		{
			// ??? [0]->8Byte
			// size?

			// property's type
			address += 8;
			var propType = Gvas.GetString(address);
			address += propType.length;

			// ??? [12+length]->1Byte

			// array's count
			address += 1;
			uint count = SaveData.Instance().ReadNumber(address, 4);
			address += 4;

			switch (propType.Item1)
			{
				case "StructProperty":
					// property's name
					var propName = Gvas.GetString(address);

					// property's type
					address += propName.length;
					propType = Gvas.GetString(address);
					address += propType.length;

					// ???
					// size?
					uint size = SaveData.Instance().ReadNumber(address, 4);
					address += 8;
					mProperties = GvasStructProperty.CreateGvasProperties(address, propType.name, count);
					break;
			}

			return address;
		}

		public override object Value
		{
			get => mProperties;
			set { }
		}
	}
}
