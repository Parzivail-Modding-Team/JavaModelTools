using System.Collections.Generic;
using Newtonsoft.Json;

namespace JavaModelTools.Tabula
{
	public class Part
	{
		[JsonProperty("notes")]
		public List<string> Notes { get; set; }

		[JsonProperty("texWidth")]
		public int TexWidth { get; set; }

		[JsonProperty("texHeight")]
		public int TexHeight { get; set; }

		[JsonProperty("matchProject")]
		public bool MatchProject { get; set; }

		[JsonProperty("texOffX")]
		public int U { get; set; }

		[JsonProperty("texOffY")]
		public int V { get; set; }

		[JsonProperty("rotPX")]
		public double RotationPointX { get; set; }

		[JsonProperty("rotPY")]
		public double RotationPointY { get; set; }

		[JsonProperty("rotPZ")]
		public double RotationPointZ { get; set; }

		[JsonProperty("rotAX")]
		public double Pitch { get; set; }

		[JsonProperty("rotAY")]
		public double Yaw { get; set; }

		[JsonProperty("rotAZ")]
		public double Roll { get; set; }

		[JsonProperty("mirror")]
		public bool Mirror { get; set; }

		[JsonProperty("showModel")]
		public bool ShowModel { get; set; }

		[JsonProperty("boxes")]
		public List<Box> Boxes { get; set; }

		[JsonProperty("children")]
		public List<Part> Children { get; set; }

		[JsonProperty("identifier")]
		public string Identifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}