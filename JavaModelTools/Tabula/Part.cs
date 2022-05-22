using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JavaModelTools.Tabula
{
	public class Part
	{
		private string _identifier;

		[JsonPropertyName("notes")] public List<string> Notes { get; set; }

		[JsonPropertyName("texWidth")] public int TexWidth { get; set; }

		[JsonPropertyName("texHeight")] public int TexHeight { get; set; }

		[JsonPropertyName("matchProject")] public bool MatchProject { get; set; }

		[JsonPropertyName("texOffX")] public int U { get; set; }

		[JsonPropertyName("texOffY")] public int V { get; set; }

		[JsonPropertyName("rotPX")] public double RotationPointX { get; set; }

		[JsonPropertyName("rotPY")] public double RotationPointY { get; set; }

		[JsonPropertyName("rotPZ")] public double RotationPointZ { get; set; }

		[JsonPropertyName("rotAX")] public double Pitch { get; set; }

		[JsonPropertyName("rotAY")] public double Yaw { get; set; }

		[JsonPropertyName("rotAZ")] public double Roll { get; set; }

		[JsonPropertyName("mirror")] public bool Mirror { get; set; }

		[JsonPropertyName("showModel")] public bool ShowModel { get; set; }

		[JsonPropertyName("boxes")] public List<Box> Boxes { get; set; }

		[JsonPropertyName("children")] public List<Part> Children { get; set; }

		[JsonPropertyName("identifier")]
		public string Identifier
		{
			get => _identifier;
			set
			{
				_identifier = value;
				if (Name == null)
					Name = value;
			}
		}

		[JsonPropertyName("name")] public string Name { get; set; }
	}
}