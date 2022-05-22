using System.Text.Json.Serialization;

namespace JavaModelTools.Tabula
{
	public class Box
	{
		[JsonPropertyName("posX")]
		public double X { get; set; }

		[JsonPropertyName("posY")]
		public double Y { get; set; }

		[JsonPropertyName("posZ")]
		public double Z { get; set; }

		[JsonPropertyName("dimX")]
		public double SizeX { get; set; }

		[JsonPropertyName("dimY")]
		public double SizeY { get; set; }

		[JsonPropertyName("dimZ")]
		public double SizeZ { get; set; }

		[JsonPropertyName("expandX")]
		public double ExpandX { get; set; }

		[JsonPropertyName("expandY")]
		public double ExpandY { get; set; }

		[JsonPropertyName("expandZ")]
		public double ExpandZ { get; set; }

		[JsonPropertyName("texOffX")]
		public int U { get; set; }

		[JsonPropertyName("texOffY")]
		public int V { get; set; }

		[JsonPropertyName("identifier")]
		public string Identifier { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }
	}
}