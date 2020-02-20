using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class Resource
	{
		private int resourceNumber = 0;
		private string name;

		public int ResourceNumber { get => resourceNumber; set => resourceNumber = value; }
		public string Name { get => name; set => name = value; }

		public Resource(string name)
		{
			this.name = name;
		}
	}
}
