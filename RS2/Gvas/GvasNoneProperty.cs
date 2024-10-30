using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal class GvasNoneProperty : GvasProperty
	{
		public override uint Read(uint address)
		{
			throw new NotImplementedException();
		}

		public override Object Value
		{
			get => "";
			set { }
		}
	}
}
