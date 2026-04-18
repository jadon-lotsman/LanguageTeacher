namespace Itereta.Contracts.Dtos.Iteration
{
    public class RepetitionResponseDto
    {
        public int IterationCounter { get; set; }
        public int IterationInterval { get; set; }
        public double EasinessFactor { get; set; }
        public DateTime NextIterationAt { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
