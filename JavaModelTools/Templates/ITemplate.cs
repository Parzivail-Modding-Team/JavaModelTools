using JavaModelTools.Tabula;

namespace JavaModelTools.Templates
{
	public interface ITemplate
	{
		string Generate(TemplateContext context);
	}
}