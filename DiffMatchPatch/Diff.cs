/*
 * Diff Match and Patch
 * Copyright 2018 The diff-match-patch Authors.
 * https://github.com/google/diff-match-patch
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


// ReSharper disable NonReadonlyMemberInGetHashCode

namespace DiffMatchPatch
{
    /**
   * Class representing one diff operation.
   */
    public class Diff
    {
        public Operation Operation;

        // One of: INSERT, DELETE or EQUAL.
        public string Text;
        // The text associated with this diff operation.

        /**
         * Constructor.  Initializes the diff with the provided values.
         * @param operation One of INSERT, DELETE or EQUAL.
         * @param text The text being applied.
         */
        public Diff(Operation operation, string text)
        {
            // Construct a diff with the specified operation and text.
            this.Operation = operation;
            this.Text = text;
        }

        /**
         * Display a human-readable version of this Diff.
         * @return text version.
         */
        public override string ToString()
        {
            var prettyText = Text.Replace('\n', '\u00b6');
            return "Diff(" + Operation + ",\"" + prettyText + "\")";
        }

        /**
         * Is this Diff equivalent to another Diff?
         * @param d Another Diff to compare against.
         * @return true or false.
         */
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