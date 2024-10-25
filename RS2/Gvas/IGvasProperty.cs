using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2.Gvas
{
	internal interface IValueElement
	{
		public abstract String Name();
		public abstract Object Value { get; set; }
	}
}
