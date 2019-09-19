using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RBXLX_to_RBXMX
{
	class Program
	{
		static IEnumerable<XmlNode> getMD5s(XmlNode main, XmlNode n, Dictionary<string, XmlNode> d = null, int c = 0)
		{
			if (d == null)
			{
				d = new Dictionary<string, XmlNode>();
				foreach (XmlNode ss in main["SharedStrings"])
					d.Add(ss.Attributes["md5"].Value, ss);
			}
			foreach (XmlNode i in n)
				if (i.Name == "Item")
				{
					foreach (XmlNode p in i["Properties"])
						if (p.Name == "SharedString")
							d.Remove(p.InnerText);
					getMD5s(main, i, d, c + 1);
				}
			return c == 0 ? d.Select(e => e.Value) : null;
		}
		static void Main(string[] args)
		{
			var xml = new XmlDocument();
			xml.Load(args[0]);
			XmlNode main = xml.DocumentElement, item = main;

			bool b = false;
			for (int c = 2; c < args.Length; c++)
				if (b = !b && c > 2) System.Environment.Exit(1);
				else
					foreach (XmlNode i in item)
						if (b) break;
						else if (i.Name == "Item")
							foreach (XmlNode p in i["Properties"])
								if (b) break;
								else if (p.Attributes["name"].Value == "Name")
									if (p.InnerText == args[c])
									{
										item = i;
										b = true;
									}

			var l = getMD5s(main, item);
			while (main["Item"] != null)
				main.RemoveChild(main["Item"]);
			main.PrependChild(item);

			var ss = main["SharedStrings"];
			foreach (var i in l)
				ss.RemoveChild(i);

			xml.Save(args[1]);
		}
	}
}
