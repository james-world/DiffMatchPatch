using System.Text.Json.Serialization;
using ApprovalTests;
using ApprovalTests.Reporters;
using Newtonsoft.Json;
using Xunit;


namespace DiffMatchPatch.UnitTests
{
    [UseReporter(typeof(DiffReporter))]
    public class DiffTests
    {
        [Fact]
        public void DiffWorks()
        {
            var text1 = @"I am the very model of a modern Major-General,
I've information vegetable, animal, and mineral,
I know the kings of England, and I quote the fights historical,
From Marathon to Waterloo, in order categorical.";

            var text2 = @"I am the very model of a cartoon individual,
My animation's comical, unusual, and whimsical,
I'm quite adept at funny gags, comedic theory I have read,
From wicked puns and stupid jokes to anvils that drop on your head.";

            var sut = new DiffMatchPatch();
            sut.DiffTimeout = 0;
            var diffs = sut.DiffMain(text1, text2);
            sut.DiffCleanupEfficiency(diffs);
            var patches = sut.PatchMake(diffs);
            var patch = sut.PatchToText(patches);

            Approvals.Verify(patch);
        }

        [Fact]
        public void PatchWorks()
        {
            var text1 = @"I am the very model of a modern Major-General,
I've information vegetable, animal, and mineral,
I know the kings of England, and I quote the fights historical,
From Marathon to Waterloo, in order categorical.";

            var patch = @"@@ -22,71 +22,66 @@
 f a 
-modern Major-Gener
+cartoon individu
 al,%0d%0a
-I've infor
+My ani
 mation
- vegetable, anim
+'s comical, unusu
 al, and 
 mine
@@ -80,88 +80,85 @@
 and 
-miner
+whimsic
 al,%0d%0aI
- know the kings of England, and I quote
+'m quite adept at funny gags, comedic
  the
- fights historical
+ory I have read
 ,%0d%0aFrom 
 Mara
@@ -157,47 +157,66 @@
 rom 
-Marathon
+wicked puns and stupid jokes
  to 
-Waterloo, in order categorical
+anvils that drop on your head
 .";
            patch = patch.Replace("\r\n", "\n");
            
            var sut = new DiffMatchPatch();
            sut.DiffTimeout = 0;
            var patches = sut.PatchFromText(patch);
            var result = sut.PatchApply(patches, text1)[0];

            Approvals.Verify(result);            
        }
    }
}