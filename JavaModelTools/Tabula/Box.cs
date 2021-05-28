using Newtonsoft.Json;

namespace JavaModelTools.Tabula
{
	public class Box
	{
		[JsonProperty("posX")]
		public double PosX { get; set; }

		[JsonProperty("posY")]
		public double PosY { get; set; }

		[JsonProperty("posZ")]
		public double PosZ { get; set; }

		[JsonProperty("dimX")]
		public double DimX { get; set; }

		[JsonProperty("dimY")]
		public double DimY { get; set; }

		[JsonProperty("dimZ")]
		public double DimZ { get; set; }

		[JsonProperty("expandX")]
		public double ExpandX { get; set; }

		[JsonProperty("expandY")]
		public double ExpandY { get; set; }

		[JsonProperty("expandZ")]
		public double ExpandZ { get; set; }

		[JsonProperty("texOffX")]
		public int TexOffX { get; set; }

		[JsonProperty("texOffY")]
		public int TexOffY { get; set; }

		[JsonProperty("identifier")]
		public string Identifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}