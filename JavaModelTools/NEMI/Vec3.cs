using System.Text.Json.Serialization;

namespace JavaModelTools.NEMI;

public record Vec3(
	[property: JsonPropertyName("x")] double X,
	[property: JsonPropertyName("y")] double Y,
	[property: JsonPropertyName("z")] double Z
);