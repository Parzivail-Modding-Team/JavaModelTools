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
				{ "x", new TagNodeDouble(ModelData.ScaleX) },
				{ "y", new TagNodeDouble(ModelData.ScaleY) },
				{ "z", new TagNodeDouble(ModelData.ScaleZ) }
			};
			nbt.Root["texture"] = new TagNodeCompound
			{
				{ "path", new TagNodeString(ModelData.TextureFile) },
				{ "w", new TagNodeDouble(ModelData.TexWidth) },
				{ "h", new TagNodeDouble(ModelData.TexHeight) }
			};

			var parts = new TagNodeCompound();

			foreach (var part in ModelData.Parts)
				AppendPart(parts, part);

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
					{ "pitch", new TagNodeDouble(part.Pitch) },
					{ "yaw", new TagNodeDouble(part.Yaw) },
					{ "roll", new TagNodeDouble(part.Roll) },
				},
				["pos"] = new TagNodeCompound
				{
					{ "x", new TagNodeDouble(part.RotationPointX) },
					{ "y", new TagNodeDouble(part.RotationPointY) },
					{ "z", new TagNodeDouble(part.RotationPointZ) },
				},
				["tex"] = new TagNodeCompound
				{
					{ "w", new TagNodeDouble(part.TexWidth) },
					{ "h", new TagNodeDouble(part.TexHeight) },
					{ "u", new TagNodeInt(part.U) },
					{ "v", new TagNodeInt(part.V) },
					{ "mirrored", new TagNodeByte(part.Mirror) },
				}
			};

			var children = new TagNodeCompound();

			foreach (var child in part.Children)
				AppendPart(children, child);

			partTag["children"] = children;

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
						{ "x", new TagNodeDouble(cube.X) },
						{ "y", new TagNodeDouble(cube.Y) },
						{ "z", new TagNodeDouble(cube.Z) },
					},
					["expand"] = new TagNodeCompound
					{
						{ "x", new TagNodeDouble(cube.ExpandX) },
						{ "y", new TagNodeDouble(cube.ExpandY) },
						{ "z", new TagNodeDouble(cube.ExpandZ) },
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