using System.Collections.Generic;
using JavaModelTools.Tabula;

namespace JavaModelTools.Templates
{
	public abstract class Template
	{
		private readonly Dictionary<string, string> _uniqueNames = new();
		
		public TabulaModelData ModelData { get; }

		public Template(TabulaModelData modelData)
		{
			ModelData = modelData;
		}
		
		public abstract void Generate(TemplateContext context);

		protected string GetUniqueName(Part part)
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
	}
}