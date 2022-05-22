using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JavaModelTools.NEMI;

public record Part(
	[property: JsonPropertyName("parent")] string Parent,
	[property: JsonPropertyName("rot")] Rot Rot,
	[property: JsonPropertyName("boxes")] IReadOnlyList<Box> Boxes,
	[property: JsonPropertyName("pos")] Vec3 Pos
);