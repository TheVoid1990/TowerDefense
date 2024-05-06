using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TowerDefense
{
	[XmlRoot("Tiles")]
	public class TileContainer
	{
		[XmlElement("Row")]
		public List<TileRow> Rows { get; set; }
	}

	public class TileRow
	{
		[XmlElement("TileData")]
		public List<TileData> Tiles { get; set; }
	}

	public enum TileType
	{
		[XmlEnum("unknown")]
		Unknown,

		[XmlEnum(Name = "water")]
		Water,

		[XmlEnum(Name = "ground")]
		Ground
	}

	public class TileData
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlAttribute("type")]
		public TileType Type { get; set; }
	}
}
