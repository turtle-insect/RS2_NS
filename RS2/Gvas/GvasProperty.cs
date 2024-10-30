using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal abstract class GvasProperty
	{
		protected uint mAddress = 0;
		protected String mName = "";

		public abstract uint Read(uint address);
		public abstract Object Value { get; set; }

		public uint Address
		{
			get => mAddress;
			set => mAddress = value;
		}

		public String Name
		{
			get => mName;
			set => mName = value;
		}
	}
}
