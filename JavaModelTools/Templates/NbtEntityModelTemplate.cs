using System;
using System.Collections.Generic;
using System.IO;
using JavaModelTools.Tabula;
using Substrate.Nbt;

namespace JavaModelTools.Templates
{
	public class NbtEntityModelTemplate : Template
	{
		public NbtEntityModelTemplate(TabulaModelData modelData) : base(modelData)
		{
		}

		public override void Generate(TemplateContext context)
		{
			var nbt = new NbtTree { Name = context.ModelName };

			nbt.Root["author"] = new TagNodeString(ModelData.Author);
			nbt.Root["version"] = new TagNodeInt(ModelData.ProjVersion);
			nbt.Root["scale"] = new TagNodeCompound
			{
				{ "x", new TagNodeFloat((float)ModelData.ScaleX) },
				{ "y", new TagNodeFloat((float)ModelData.ScaleY) },
				{ "z", new TagNodeFloat((float)ModelData.ScaleZ) }
			};
			nbt.Root["tex"] = new TagNodeCompound
			{
				{ "path", new TagNodeString(ModelData.TextureFile) },
				{ "w", new TagNodeFloat(ModelData.TexWidth) },
				{ "h", new TagNodeFloat(ModelData.TexHeight) }
			};

			var parts = new TagNodeCompound();

			foreach (var part in ModelData.Parts)
				AppendPart(parts, part);

			const bool addExtraPlayerModelParts = true;
			if (addExtraPlayerModelParts)
			{
				AppendPart(parts, new Part()
				{
					Name = "ear",
					Children = new List<Part>(),
					Boxes = new List<Box>(),
					Identifier = "ear"
				});
				AppendPart(parts, new Part()
				{
					Name = "cloak",
					Children = new List<Part>(),
					Boxes = new List<Box>(),
					Identifier = "cloak"
				});
			}

			nbt.Root["parts"] = parts;

			using var fs = File.Open($"{context.FileName}.nem", FileMode.Create);
			nbt.WriteTo(fs);
		}

		private void AppendPart(TagNodeCompound parent, Part part)
		{
			var partName = GetUniqueName(part);

			var partTag = new TagNodeCompound
			{
				["rot"] = new TagNodeCompound
				{
					{ "pitch", new TagNodeFloat((float)(part.Pitch / 180 * Math.PI)) },
					{ "yaw", new TagNodeFloat((float)(part.Yaw / 180 * Math.PI)) },
					{ "roll", new TagNodeFloat((float)(part.Roll / 180 * Math.PI)) },
				},
				["pos"] = new TagNodeCompound
				{
					{ "x", new TagNodeFloat((float)part.RotationPointX) },
					{ "y", new TagNodeFloat((float)part.RotationPointY) },
					{ "z", new TagNodeFloat((float)part.RotationPointZ) },
				},
				["tex"] = new TagNodeCompound
				{
					{ "w", new TagNodeFloat(part.TexWidth) },
					{ "h", new TagNodeFloat(part.TexHeight) },
					{ "u", new TagNodeInt(part.U) },
					{ "v", new TagNodeInt(part.V) },
					{ "mirrored", new TagNodeByte(part.Mirror) },
				}
			};

			if (part.Children.Count > 0)
			{
				var children = new TagNodeCompound();

				foreach (var child in part.Children)
					AppendPart(children, child);

				partTag["children"] = children;
			}

			var cuboids = new TagNodeList(TagType.TAG_COMPOUND);

			foreach (var cube in part.Boxes)
			{
				cuboids.Add(new TagNodeCompound
				{
					["size"] =
						new TagNodeCompound
						{
							{ "x", new TagNodeInt((int)cube.SizeX) },
							{ "y", new TagNodeInt((int)cube.SizeY) },
							{ "z", new TagNodeInt((int)cube.SizeZ) },
						},
					["pos"] = new TagNodeCompound
					{
						{ "x", new TagNodeFloat((float)cube.X) },
						{ "y", new TagNodeFloat((float)cube.Y) },
						{ "z", new TagNodeFloat((float)cube.Z) },
					},
					["expand"] = new TagNodeCompound
					{
						{ "x", new TagNodeFloat((float)cube.ExpandX) },
						{ "y", new TagNodeFloat((float)cube.ExpandY) },
						{ "z", new TagNodeFloat((float)cube.ExpandZ) },
					},
					["tex"] = new TagNodeCompound
					{
						{ "u", new TagNodeInt(cube.U) },
						{ "v", new TagNodeInt(cube.V) },
					}
				});
			}

			partTag["cuboids"] = cuboids;

			parent[partName] = partTag;
		}
	}
}