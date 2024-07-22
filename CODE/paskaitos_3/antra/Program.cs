namespace antra
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Paskaitos data: 2024-06-11

            // SARASAI (LISTS)

            List<string> list = null;
            //List<string> list = new List<string> { "test" };
            //List<string> list = new List<string> { "a", "bc", "def" };
            //List<string> list = new List<string> { null };
            //List<string> list = new List<string> { "a", null, "bc" };
            //List<string> list = new List<string> { "" };
            //List<string> list = new List<string> { };
            var answer = String.Join(", ", GetStringLengthsImproovment(list));
            Console.WriteLine(answer);
        }
        public static List<int> GetStringLengthsImproovment(List<string> strings)
        {
            List<int> result = new List<int>();
            if (strings == null)
            {
                throw new ArgumentNullException("Some exception");
            }
            foreach (string str in strings)
            {
                if (str == null)
                {
                    result.Add(-1);
                }
                else
                {
                    result.Add(str.Length);
                }
            }
            return result;
        }
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
    }
}
