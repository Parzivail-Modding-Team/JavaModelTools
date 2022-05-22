using System.Text.Json.Serialization;

namespace JavaModelTools.NEMI;

public record TexPos(
	[property: JsonPropertyName("u")] int U,
	[property: JsonPropertyName("v")] int V
);