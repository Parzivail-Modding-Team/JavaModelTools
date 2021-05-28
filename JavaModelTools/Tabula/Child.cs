using System.Collections.Generic;
using Newtonsoft.Json;

namespace JavaModelTools.Tabula
{
	public class Child
	{
		[JsonProperty("notes")]
		public List<object> Notes { get; set; }

		[JsonProperty("texWidth")]
		public int TexWidth { get; set; }

		[JsonProperty("texHeight")]
		public int TexHeight { get; set; }

		[JsonProperty("matchProject")]
		public bool MatchProject { get; set; }

		[JsonProperty("texOffX")]
		public int TexOffX { get; set; }

		[JsonProperty("texOffY")]
		public int TexOffY { get; set; }

		[JsonProperty("rotPX")]
		public double RotPX { get; set; }

		[JsonProperty("rotPY")]
		public double RotPY { get; set; }

		[JsonProperty("rotPZ")]
		public double RotPZ { get; set; }

		[JsonProperty("rotAX")]
		public double RotAX { get; set; }

		[JsonProperty("rotAY")]
		public double RotAY { get; set; }

		[JsonProperty("rotAZ")]
		public double RotAZ { get; set; }

		[JsonProperty("mirror")]
		public bool Mirror { get; set; }

		[JsonProperty("showModel")]
		public bool ShowModel { get; set; }

		[JsonProperty("boxes")]
		public List<Box> Boxes { get; set; }

		[JsonProperty("children")]
		public List<object> Children { get; set; }

		[JsonProperty("identifier")]
		public string Identifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}