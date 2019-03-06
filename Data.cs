using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	[DataContract]
	class Data
	{
		[DataMember]
		public string base64 { get; set; }
		[DataMember]
		public string name { get; set; }
	}
}
