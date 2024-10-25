using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal class GvasIntProperty : IValueElement
	{
		private readonly uint mAddress;
		private readonly String mName;
		public GvasIntProperty(uint address, String name)
		{
			mAddress = address;
			mName = name;
		}

		public String Name()
		{
			return mName;
		}

		public Object Value
		{
			get => SaveData.Instance().ReadNumber(mAddress, 4);
			set
			{
				uint num;
				if (!uint.TryParse(value.ToString(), out num)) return;
				SaveData.Instance().WriteNumber(mAddress, 4, num);
			}
		}
	}
}
