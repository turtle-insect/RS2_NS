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

			var value = ValueAddress();
			return value.Item1 + value.Item2;
		}

		public override object Value
		{
			get
			{
				var value = ValueAddress();
				return SaveData.Instance().ReadText(value.Item1, value.Item2);
			}
			set
			{
				var name = value.ToString();
				if (name == null) return;
				// +1 -> termination
				uint size = (uint)name.Length + 1;

				var tmp = ValueAddress();
				SaveData.Instance().Reducion(tmp.Item1, tmp.Item2);
				SaveData.Instance().Extension(tmp.Item1, size);

				// key's value
				SaveData.Instance().WriteText(tmp.Item1, size, name);
				// key's size
				SaveData.Instance().WriteNumber(tmp.Item1 - 4, 4, size);

				// total size
				size += SaveData.Instance().ReadNumber(mAddress + 14, 4);
				size += 13;
				SaveData.Instance().WriteNumber(mAddress, 4, size);

				// TBD.
				// change parent property's size
			}
		}

		// (uint, uint) -> address, size
		private (uint, uint) ValueAddress()
		{
			// key's length -> [14]->4Byte
			uint address = mAddress + 14;
			uint length = SaveData.Instance().ReadNumber(address, 4);
			address += 4 + length;

			// key's name -> [18]->length
			// var key = SaveData.Instance().ReadText(address + 18, length);

			// key's value Size -> [18+length]->4Byte
			uint size = SaveData.Instance().ReadNumber(address, 4);
			// key's value -> [18+length+4]
			return (address + 4, size);
		}
	}
}
