// ReSharper disable NonReadonlyMemberInGetHashCode

namespace DiffMatchPatch
{
    /// <summary>
    /// Diff represents one diff operation.
    /// </summary>
    public class Diff
    {
        public Operation Operation;

        // One of: INSERT, DELETE or EQUAL.
        public string Text;
        // The text associated with this diff operation.

        /// <summary>
        /// Initialize a diff with the provided values.
        /// </summary>
        /// <param name="operation">Diff operation type</param>
        /// <param name="text">The text being applied</param>
        public Diff(Operation operation, string text)
        {
            // Construct a diff with the specified operation and text.
            this.Operation = operation;
            this.Text = text;
        }

        /// <summary>
        /// Display a human-readable version of this Diff.
        /// </summary>
        /// <returns>Human readable string representation</returns>
        public override string ToString()
        {
            var prettyText = Text.Replace('\n', '\u00b6');
            return "Diff(" + Operation + ",\"" + prettyText + "\")";
        }
        
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Diff return false.
            var p = obj as Diff;
            if (p == null)
            {
                return false;
            }

            // Return true if the fields match.
            return p.Operation == Operation && p.Text == Text;
        }

        public bool Equals(Diff obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // Return true if the fields match.
            return obj.Operation == Operation && obj.Text == Text;
        }

        public override int GetHashCode() => Text.GetHashCode() ^ Operation.GetHashCode();
    }
}