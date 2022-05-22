using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JavaModelTools.Tabula
{
	public class TabulaModelData
	{
		[JsonPropertyName("author")]
		public string Author { get; set; }

		[JsonPropertyName("projVersion")]
		public int ProjVersion { get; set; }

		[JsonPropertyName("notes")]
		public List<string> Notes { get; set; }

		[JsonPropertyName("scaleX")]
		public double ScaleX { get; set; }

		[JsonPropertyName("scaleY")]
		public double ScaleY { get; set; }

		[JsonPropertyName("scaleZ")]
		public double ScaleZ { get; set; }

		[JsonPropertyName("texWidth")]
		public int TexWidth { get; set; }

		[JsonPropertyName("texHeight")]
		public int TexHeight { get; set; }

		[JsonPropertyName("textureFile")]
		public string TextureFile { get; set; }

		[JsonPropertyName("textureFileMd5")]
		public string TextureFileMd5 { get; set; }

		[JsonPropertyName("parts")]
		public List<Part> Parts { get; set; }

		[JsonPropertyName("partCountProjectLife")]
		public int PartCountProjectLife { get; set; }

		[JsonPropertyName("identifier")]
		public string Identifier { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }
	}
}