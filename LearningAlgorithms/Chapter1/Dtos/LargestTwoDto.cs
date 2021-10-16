namespace LearningAlgorithms.Chapter1.Dtos
{
    public class LargestTwoDto
    {
        public LargestTwoDto(int max, int second)
        {
            Max = max;
            Second = second;
        }

        public int Max { get; set; }

        public int Second { get; set; }
    }
}