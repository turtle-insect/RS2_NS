using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal class GvasTextProperty : GvasProperty
	{
		public override uint Read(uint address)
		{
			// total size -> [0]->8Byte

			// key + value address
			address = ValueAddress();
			var propValue = Gvas.GetString(address);
			return address + propValue.length;
		}

		public override object Value
		{
			get
			{
				var address = ValueAddress();
				var propValue = Gvas.GetString(address);
				return propValue.name;
			}
			set
			{
				var name = value.ToString();
				if (name == null) return;
				// +1 -> termination

				var address = ValueAddress();
				uint size = SaveData.Instance().ReadNumber(address, 4);
				SaveData.Instance().Reducion(address, size);
				size = (uint)name.Length + 1;
				SaveData.Instance().Extension(address, size);

				// key's value
				SaveData.Instance().WriteText(address, size, name);
				// key's size
				SaveData.Instance().WriteNumber(address - 4, 4, size);

				// total size
				size += SaveData.Instance().ReadNumber(mAddress + 14, 4);
				size += 13;
				SaveData.Instance().WriteNumber(mAddress, 4, size);

				// TBD.
				// change parent property's size
			}
		}

		// (uint, uint) -> address, size
		private uint ValueAddress()
		{
			// key's length -> [14]->4Byte
			uint address = mAddress + 14;

			var propKey = Gvas.GetString(address);
			address += propKey.length;

			return address;
		}
	}
}
