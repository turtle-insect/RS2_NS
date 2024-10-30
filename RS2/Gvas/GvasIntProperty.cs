using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal class GvasIntProperty : GvasProperty
	{
		private uint mSize;

		public override uint Read(uint address)
		{
			// Size -> [0]->8Byte
			mSize = SaveData.Instance().ReadNumber(address, 4);

			// ??? -> 1Byte
			return address + 13;
		}

		public override Object Value
		{
			get => SaveData.Instance().ReadNumber(mAddress + 9, mSize);
			set
			{
				uint num;
				if (!uint.TryParse(value.ToString(), out num)) return;
				SaveData.Instance().WriteNumber(mAddress + 9, mSize, num);
			}
		}
	}
}
