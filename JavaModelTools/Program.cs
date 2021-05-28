using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using JavaModelTools.Tabula;
using JavaModelTools.Templates;
using Newtonsoft.Json;

namespace JavaModelTools
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0 || !File.Exists(args[0]))
				return;

			var filename = args[0];
			using var fs = ZipFile.Open(filename, ZipArchiveMode.Read);

			var modelEntry = fs.Entries.FirstOrDefault(entry => entry.FullName == "model.json");

			if (modelEntry == null)
			{
				Console.WriteLine("Archive does not contain model definition");
				return;
			}

			using var modelStream = new StreamReader(modelEntry.Open());
			var modelJson = modelStream.ReadToEnd();

			var model = JsonConvert.DeserializeObject<TabulaModelData>(modelJson);
			var context = new TemplateContext
			{
				ClassName = "WorrtEntityModel"
			};
			
			var output = new FabricEntityModel17Template(model).Generate(context);
			File.WriteAllText($"{context.ClassName}.java", output);
		}
	}
}