namespace DiffMatchPatch
{
    /// <summary>
    /// Possible types of diff operation
    /// </summary>
    /// <remarks>
    /// The data structure representing a diff is a List of Diff objects:
    /// { Diff(Operation.Delete, "Hello"), Diff(Operation.Insert, "Goodbye"),
    /// Diff(Operation.Equal, " world.") }
    /// which means: delete "Hello", add "Goodbye" and keep " world."
    /// </remarks>
    public enum Operation
    {
        Delete,
        Insert,
        Equal
    }
}