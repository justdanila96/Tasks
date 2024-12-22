namespace Task1ConsoleApp {
    internal static class Extensions {
        public static Dictionary<T, int> Collect<T>(this IEnumerable<T> values) where T : notnull {

            var dict = new Dictionary<T, int>();

            foreach (T item in values) {
                if (dict.TryGetValue(item, out int value)) {
                    dict[item] = ++value;
                }
                else {
                    dict.Add(item, 1);
                }
            }

            return dict;
        }
    }

    internal class FilenameComparer : IComparer<string> {
        public int Compare(string? x, string? y) => string.CompareOrdinal(x, y);
    }

    public class Program {

        private static string IncrNumber(string str, string number) {

            const char dot = '.';
            return str.LastIndexOf(dot) switch {
                int index when index >= 0 => str.Insert(index, number),
                _ => str + number
            };
        }

        private static IEnumerable<string> GetFileSequence(KeyValuePair<string, int> fileInfo) {

            (string filename, int count) = fileInfo;
            yield return filename;
            for (int i = 1; i < count; i++) {
                yield return IncrNumber(filename, $"({i})");
            }
        }

        public static IEnumerable<string> SortFiles(IEnumerable<string> input) =>
            input.Collect()
            .SelectMany(GetFileSequence)
            .Order(new FilenameComparer());

        static void Main(string[] args) {
            foreach (string filename in SortFiles(args)) {
                Console.WriteLine(filename);
            }
        }
    }
}
