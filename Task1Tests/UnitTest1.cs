namespace Task1Tests {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Test1() {

            string[] input = [
                "song.mp3",
                "problem.cfg",
                "problem",
                "picture.png",
                "problem.cfg",
                "sol123.c",
                "data.dat",
                "problem",
                "sol13.c",
                "sol123.c",
                "song.mp3"
            ];

            string[] output = [
                "data.dat",
                "picture.png",
                "problem",
                "problem(1)",
                "problem(1).cfg",
                "problem.cfg",
                "sol123(1).c",
                "sol123.c",
                "sol13.c",
                "song(1).mp3",
                "song.mp3"
            ];

            var result = Task1ConsoleApp.Program.SortFiles(input);

            CollectionAssert.AreEqual(result, output);
        }
    }
}