using Microsoft.VisualStudio.TestTools.UnitTesting;
using antra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antra.Tests
{

    /*
| Test Case # | Input                                             | Expected Output                | Description                                        |
|-------------|---------------------------------------------------|--------------------------------|----------------------------------------------------|
| 1           | `strings = null`                                  | Throws `ArgumentNullException` | List is null, should throw ArgumentNullException   |
| 2           | `strings = new List<string> { "test" }`           | `[4]`                          | Single non-null string                             |
| 3           | `strings = new List<string> { "a", "bc", "def" }` | `[1, 2, 3]`                    | Multiple non-null strings                          |
| 4           | `strings = new List<string> { null }`             | `[-1]`                         | Single null string                                 |
| 5           | `strings = new List<string> { "a", null, "bc" }`  | `[1, -1, 2]`                   | Mixed null and non-null strings                    |
| 6           | `strings = new List<string> { "" }`               | `[0]`                          | Single empty string                                |
| 7           | `strings = new List<string> { }`                  | `[]`                           | Empty list, should return an empty list            |


*/
    [TestClass()]
    public class ProgramTests
    {
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStringLengths_ListIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            List<string> strings = null;

            // Act
            var result = Program.GetStringLengthsImproovment(strings);

            // Assert - [ExpectedException] attribute is used to check the exception
        }
        [TestMethod()]
        public void GetStringLengthsOneElementTest()
        {
            var strings = new List<string> { "test" };
            var expected = new List<int> { 1 };
            var actual = Program.GetStringLengthsImproovment(strings);
            Assert.AreEqual(expected, actual);
        }
    }
}