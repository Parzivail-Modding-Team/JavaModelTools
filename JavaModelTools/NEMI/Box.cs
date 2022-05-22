using System.Text.Json.Serialization;

namespace JavaModelTools.NEMI;

public record Box(
	[property: JsonPropertyName("tex")] TexPos Tex,
	[property: JsonPropertyName("pos")] Vec3 Pos,
	[property: JsonPropertyName("size")] Vec3 Size,
	[property: JsonPropertyName("inflate")] double Inflate,
	[property: JsonPropertyName("mirrored")] bool Mirrored
);