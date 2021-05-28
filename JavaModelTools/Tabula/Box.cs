using Newtonsoft.Json;

namespace JavaModelTools.Tabula
{
	public class Box
	{
		[JsonProperty("posX")]
		public double X { get; set; }

		[JsonProperty("posY")]
		public double Y { get; set; }

		[JsonProperty("posZ")]
		public double Z { get; set; }

		[JsonProperty("dimX")]
		public double SizeX { get; set; }

		[JsonProperty("dimY")]
		public double SizeY { get; set; }

		[JsonProperty("dimZ")]
		public double SizeZ { get; set; }

		[JsonProperty("expandX")]
		public double ExpandX { get; set; }

		[JsonProperty("expandY")]
		public double ExpandY { get; set; }

		[JsonProperty("expandZ")]
		public double ExpandZ { get; set; }

		[JsonProperty("texOffX")]
		public int U { get; set; }

		[JsonProperty("texOffY")]
		public int V { get; set; }

		[JsonProperty("identifier")]
		public string Identifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}