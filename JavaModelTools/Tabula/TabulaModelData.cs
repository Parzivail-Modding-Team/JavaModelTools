using System.Collections.Generic;
using Newtonsoft.Json;

namespace JavaModelTools.Tabula
{
	public class TabulaModelData
	{
		[JsonProperty("author")]
		public string Author { get; set; }

		[JsonProperty("projVersion")]
		public int ProjVersion { get; set; }

		[JsonProperty("notes")]
		public List<object> Notes { get; set; }

		[JsonProperty("scaleX")]
		public double ScaleX { get; set; }

		[JsonProperty("scaleY")]
		public double ScaleY { get; set; }

		[JsonProperty("scaleZ")]
		public double ScaleZ { get; set; }

		[JsonProperty("texWidth")]
		public int TexWidth { get; set; }

		[JsonProperty("texHeight")]
		public int TexHeight { get; set; }

		[JsonProperty("textureFile")]
		public string TextureFile { get; set; }

		[JsonProperty("textureFileMd5")]
		public string TextureFileMd5 { get; set; }

		[JsonProperty("parts")]
		public List<Part> Parts { get; set; }

		[JsonProperty("partCountProjectLife")]
		public int PartCountProjectLife { get; set; }

		[JsonProperty("identifier")]
		public string Identifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}