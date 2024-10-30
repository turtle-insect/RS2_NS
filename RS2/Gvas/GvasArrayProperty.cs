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
			mAddress = address;

			// ??? [0]->8Byte
			// size?

			// property's type length.
			address += 8;
			uint length = SaveData.Instance().ReadNumber(address, 4);

			// property's type
			address += 4;
			String type = SaveData.Instance().ReadText(address, length);

			// ??? [12+length]->1Byte

			// array's count
			address += length + 1;
			uint count = SaveData.Instance().ReadNumber(address, 4);
			address += 4;

			switch (type)
			{
				case "StructProperty":
					// property's name
					length = SaveData.Instance().ReadNumber(address, 4);
					address += 4;
					var name = SaveData.Instance().ReadText(address, length);
					address += length;

					// property's type
					length = SaveData.Instance().ReadNumber(address, 4);
					address += 4;
					type = SaveData.Instance().ReadText(address, length);
					address += length;

					// ???
					// size?
					uint size = SaveData.Instance().ReadNumber(address, 4);
					address += 8;
					mProperties = GvasStructProperty.CreateGvasProperties(address, name, count);
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
