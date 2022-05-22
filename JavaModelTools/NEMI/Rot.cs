using System.Text.Json.Serialization;

namespace JavaModelTools.NEMI;

public record Rot(
	[property: JsonPropertyName("pitch")] double Pitch,
	[property: JsonPropertyName("yaw")] double Yaw,
	[property: JsonPropertyName("roll")] double Roll
);