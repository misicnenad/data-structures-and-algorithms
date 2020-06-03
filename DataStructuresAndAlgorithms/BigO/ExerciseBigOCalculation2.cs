namespace DataStructuresAndAlgorithms.BigO
{
    public class ExerciseBigOCalculation2
    {
        public void Run()
        {
            var input = 100;

            AnotherFunChallenge(input);
        }

        // "Big O" value: O(4 + 5n) = O(n)
        private void AnotherFunChallenge(int input)
        {
            var a = 5; // O(1)
            var b = 10; // O(1)
            var c = 50; // O(1)

            for (int i = 0; i < input; i++)
            {
                var x = i + 1; // O(n)
                var y = i + 2; // O(n)
                var z = i + 3; // O(n)
            }

            for (int j = 0; j < input; j++)
            {
                var p = j * 2; // O(n)
                var q = j * 2; // O(n)
            }

            var whoAmI = "I don't know"; // O(1)
        }
    }
}
