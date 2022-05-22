using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using JavaModelTools.Tabula;
using Microsoft.VisualBasic;

namespace JavaModelTools.NEMI;

public record NemiModel(
	[property: JsonPropertyName("exporter")] string Exporter,
	[property: JsonPropertyName("name")] string Name,
	[property: JsonPropertyName("tex")] TexSize Tex,
	[property: JsonPropertyName("parts")] Dictionary<string, Part> Parts
)
{
	public TabulaModelData ToTabulaModel()
	{
		return new TabulaModelData
		{
			Author = "",
			Identifier = Name,
			Name = Name,
			ScaleX = 1,
			ScaleY = 1,
			ScaleZ = 1,
			TexWidth = Tex.W,
			TexHeight = Tex.H,
			Parts = CollectParts() 
		};
	}

	private List<Tabula.Part> CollectParts()
	{
		return Parts
			.Where(pair => pair.Value.Parent == null)
			.Select(pair => CreatePart(pair.Key, pair.Value))
			.ToList();
	}

	private Tabula.Part CreatePart(string id, Part part)
	{
		return new Tabula.Part
		{
			Identifier = id,
			Name = id,
			U = 0,
			V = 0,
			Pitch = part.Rot.Pitch,
			Yaw = part.Rot.Yaw,
			Roll = part.Rot.Roll,
			RotationPointX = part.Pos.X,
			RotationPointY = part.Pos.Y,
			RotationPointZ = part.Pos.Z,
			Boxes = part.Boxes
				.Select(CreateBox)
				.ToList(),
			Children = Parts
				.Where(pair => pair.Value.Parent == id)
				.Select(pair => CreatePart(pair.Key, pair.Value))
				.ToList()
		};
	}

	private static Tabula.Box CreateBox(Box b)
	{
		return new Tabula.Box
		{
			Identifier = "",
			Name = "",
			U = b.Tex.U,
			V = b.Tex.V,
			X = b.Pos.X,
			Y = b.Pos.Y,
			Z = b.Pos.Z,
			ExpandX = b.Inflate,
			ExpandY = b.Inflate,
			ExpandZ = b.Inflate,
			SizeX = b.Size.X,
			SizeY = b.Size.Y,
			SizeZ = b.Size.Z
		};
	}
}