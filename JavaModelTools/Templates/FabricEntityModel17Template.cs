using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaModelTools.Extensions;
using JavaModelTools.Tabula;

namespace JavaModelTools.Templates
{
	public class FabricEntityModel17Template : ITemplate
	{
		private readonly TabulaModelData _modelData;
		private readonly Dictionary<string, string> _uniqueNames = new();

		public FabricEntityModel17Template(TabulaModelData modelData)
		{
			_modelData = modelData;
		}

		private string GetUniqueName(Part part)
		{
			if (_uniqueNames.ContainsKey(part.Identifier))
				return _uniqueNames[part.Identifier];

			var index = 0;
			string NameAtIndex() => index == 0 ? part.Name : $"{part.Name}_{index}";

			while (_uniqueNames.ContainsValue(NameAtIndex()))
				index++;

			var name = NameAtIndex();
			_uniqueNames[part.Identifier] = name;
			return name;
		}

		public string Generate(TemplateContext context)
		{
			var sb = new StringBuilder();

			const char tab1 = '\t';
			const string tab2 = "\t\t";

			/*
			 * Imports and class definition
			 */
			sb.AppendLine("package tld.domain.project;");
			sb.AppendLine();
			sb.AppendLine("import net.fabricmc.api.EnvType;");
			sb.AppendLine("import net.fabricmc.api.Environment;");
			sb.AppendLine("import net.minecraft.client.model.*;");
			sb.AppendLine("import net.minecraft.client.render.entity.model.SinglePartEntityModel;");
			sb.AppendLine("import net.minecraft.entity.Entity;");
			sb.AppendLine();
			sb.AppendLine("/**");
			sb.Append(" * Model: ").AppendLine(_modelData.Name);
			sb.Append(" * Author: ").AppendLine(_modelData.Author);
			sb.AppendLine(" */");
			sb.AppendLine("@Environment(EnvType.CLIENT)");
			sb.Append("public class ")
				.Append(context.ClassName)
				.AppendLine("<T extends Entity> extends SinglePartEntityModel<T>");
			sb.AppendLine("{");
			sb.Append(tab1).AppendLine("private final ModelPart root;");

			/*
			 * Fields
			 */

			foreach (var part in _modelData.Parts.Flatten(part => part.Children))
				sb.Append(tab1).Append("private final ModelPart ").Append(GetUniqueName(part)).AppendLine(";");

			sb.AppendLine();

			/*
			 * Rooted Constructor
			 */
			sb.Append(tab1).Append("public ").Append(context.ClassName).AppendLine("(ModelPart root)");
			sb.Append(tab1).AppendLine("{");

			sb.Append(tab2).AppendLine("this.root = root;");
			sb.AppendLine();

			foreach (var part in _modelData.Parts)
				AppendConstructorPart(sb, tab2, "root", part);

			sb.Append(tab1).AppendLine("}");

			sb.AppendLine();
			
			/*
			 * Parameterless constructor
			 */
			sb.Append(tab1).Append("public ").Append(context.ClassName).AppendLine("()");
			sb.Append(tab1).AppendLine("{");
			sb.Append(tab2).Append("this(").AppendLine("getTexturedModelData().createModel());");
			sb.Append(tab1).AppendLine("}");
			sb.AppendLine();

			/*
			 * getTexturedModelData()
			 */
			sb.Append(tab1).AppendLine("public static TexturedModelData getTexturedModelData()");
			sb.Append(tab1).AppendLine("{");
			sb.Append(tab2).AppendLine("var modelData = new ModelData();");
			sb.Append(tab2).AppendLine("var root = modelData.getRoot();");

			sb.AppendLine();

			foreach (var part in _modelData.Parts)
				AppendPart(sb, tab2, "root", part);

			sb.AppendLine();

			sb.Append(tab2)
				.Append("return TexturedModelData.of(modelData, ")
				.Append(_modelData.TexWidth).Append(", ")
				.Append(_modelData.TexHeight).AppendLine(");");

			sb.Append(tab1).AppendLine("}");

			sb.AppendLine();

			/*
			 * getPart()
			 */
			sb.Append(tab1).AppendLine("public ModelPart getPart()");
			sb.Append(tab1).AppendLine("{");
			sb.Append(tab2).AppendLine("return root;");
			sb.Append(tab1).AppendLine("}");

			sb.AppendLine();

			/*
			 * setAngles(...)
			 */
			sb.Append(tab1)
				.AppendLine(
					"public void setAngles(T entity, float limbAngle, float limbDistance, float animationProgress, float headYaw, float headPitch)");
			sb.Append(tab1).AppendLine("{");
			sb.Append(tab1).AppendLine("}");

			sb.AppendLine("}");

			return sb.ToString();
		}

		private void AppendConstructorPart(StringBuilder sb, string tabs, string parent, Part part)
		{
			sb.Append(tabs);

			var partName = GetUniqueName(part);

			sb.Append(partName).Append(" = ");

			sb.Append(parent).Append(".getChild(\"").Append(GetUniqueName(part)).AppendLine("\");");

			foreach (var child in part.Children)
				AppendConstructorPart(sb, tabs, partName, child);
		}

		private void AppendPart(StringBuilder sb, string tabs, string parent, Part part)
		{
			sb.Append(tabs);

			var partName = $"{GetUniqueName(part)}Data";

			if (part.Children.Count > 0)
				sb.Append("var ").Append(partName).Append(" = ");

			sb.Append(parent).Append(".addChild(\"").Append(GetUniqueName(part)).Append("\", ").Append(CreatePart(part))
				.Append(", ").Append(CreateTransform(part)).AppendLine(");");

			foreach (var child in part.Children)
				AppendPart(sb, tabs, partName, child);
		}

		private static string CreateTransform(Part part)
		{
			if (part.Yaw == 0 && part.Pitch == 0 && part.Roll == 0 && part.RotationPointX == 0 &&
			    part.RotationPointY == 0 && part.RotationPointZ == 0)
				return "ModelTransform.NONE";

			var sb = new StringBuilder("ModelTransform.of(")
				.Append((float)part.RotationPointX).Append("f, ")
				.Append((float)part.RotationPointY).Append("f, ")
				.Append((float)part.RotationPointZ).Append("f, ")
				.Append((float)(part.Pitch / 180 * Math.PI)).Append("f, ")
				.Append((float)(part.Yaw / 180 * Math.PI)).Append("f, ")
				.Append((float)(part.Roll / 180 * Math.PI)).Append("f)");

			return sb.ToString();
		}

		private static string CreatePart(Part part)
		{
			var sb = new StringBuilder("ModelPartBuilder.create()");

			if (part.Mirror)
				sb.Append(".mirrored()");

			foreach (var box in part.Boxes)
			{
				sb.Append(".uv(")
					.Append(part.U + box.U).Append(", ").Append(part.V + box.V)
					.Append(')');

				sb.Append(".cuboid(");

				if (box.Name != "Box")
					sb.Append('"').Append(box.Name).Append("\", ");

				sb.Append((float)box.X).Append("f, ")
					.Append((float)box.Y).Append("f, ")
					.Append((float)box.Z).Append("f, ")
					.Append(box.SizeX).Append(", ")
					.Append(box.SizeY).Append(", ")
					.Append(box.SizeZ)
					.Append(')');
			}

			return sb.ToString();
		}
	}
}