using System.Text.Json.Serialization;

namespace JavaModelTools.NEMI;

public record TexSize(
	[property: JsonPropertyName("w")] int W,
	[property: JsonPropertyName("h")] int H
);