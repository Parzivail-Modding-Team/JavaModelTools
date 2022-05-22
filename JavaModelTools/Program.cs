using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using JavaModelTools.NEMI;
using JavaModelTools.Tabula;
using JavaModelTools.Templates;

namespace JavaModelTools
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0 || !File.Exists(args[0]))
				return;

			var filename = args[0];
			// using var fs = ZipFile.Open(filename, ZipArchiveMode.Read);
			//
			// var modelEntry = fs.Entries.FirstOrDefault(entry => entry.FullName == "model.json");
			//
			// if (modelEntry == null)
			// {
			// 	Console.WriteLine("Archive does not contain model definition");
			// 	return;
			// }
			//
			// using var modelStream = new StreamReader(modelEntry.Open());
			// var modelJson = modelStream.ReadToEnd();
			//
			// var model = JsonSerializer.Deserialize<TabulaModelData>(modelJson);
			
			var model = JsonSerializer.Deserialize<NemiModel>(File.ReadAllText(args[0])).ToTabulaModel();

			if (model == null)
			{
				Console.WriteLine("Failed to deserialize model");
				return;
			}

			var context = new TemplateContext
			{
				FileName = Path.Combine(Path.GetDirectoryName(filename), model.Name.ToLower()),
				ModelName = model.Name
			};

			// new FabricEntityModel17Template(model).Generate(context);
			new NbtEntityModelTemplate(model).Generate(context);
		}
	}
}