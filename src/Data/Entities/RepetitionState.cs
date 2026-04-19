namespace Itereta.Data.Entities
{
    public class RepetitionState
    {
        public int Id { get; set; }

        public int IterationCounter { get; set; }
        public int IterationInterval { get; set; }
        public double EasinessFactor { get; set; }
        public bool CanSelfAssess { get; set; }
        public DateTime LastIterationAt { get; set; }
        public DateTime NextIterationAt => LastIterationAt.AddDays(IterationInterval);


        public int UserId { get; set; }
        public User User { get; set; }
        public int VocabularyEntryId { get; set; }
        public VocabularyEntry VocabularyEntry { get; set; }


        public RepetitionState() { }

        public RepetitionState(User user, VocabularyEntry entry)
        {
            CanSelfAssess = false;

            User = user;
            VocabularyEntry = entry;
        }
    }
}
