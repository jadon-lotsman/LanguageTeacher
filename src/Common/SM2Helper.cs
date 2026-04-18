using Itereta.Contracts.Dtos.Iteration;
using Itereta.Data.Entities;

namespace Itereta.Common
{
    public static class SM2Helper
    {
        private const int MinIntervalDays = 1;
        private const int MaxIntervalDays = 365;

        private const double MinEasinessFactor = 1.3;

        private const int FirstIntervalDays = 1;
        private const int SecondIntervalDays = 4;


        public static double ComputeQuality(TimeSpan averageTime, TimeSpan actionTime, int actionCounter, double similarity)
        {
            var changeCounter = Math.Max(0, actionCounter-1);
            double Stability = Math.Exp(-changeCounter);

            double Accuracy = CalcFuzzyAccuracy(similarity);

            var ratio = averageTime / actionTime;
            double Reaction = CalcSigmoidReaction(ratio);

            double Knowledge = 0.5 * Accuracy + 0.3 * Stability + 0.2 * Reaction;

            double Quality = Knowledge * 5;

            return Quality;
        }

        public static (int interval, double easinessFactor, DateTime iterationAt) 
            GetNextState(double ef, int interval, int repetitionCounter, double quality)
        {
            int nextInterval;
            double newEasinessFactor;
            DateTime nextIterationAt;

            if (!IsRecallSuccessful(quality))
            {
                nextInterval = 1;
                newEasinessFactor = MinEasinessFactor;
            }
            else
            {
                newEasinessFactor = ef + (0.1 - (5 - quality) * (0.08 + (5 - quality) * 0.02));
                newEasinessFactor = Math.Clamp(newEasinessFactor, MinEasinessFactor, newEasinessFactor);

                nextInterval = repetitionCounter switch
                {
                    0 => FirstIntervalDays,
                    1 => SecondIntervalDays,
                    _ => (int)Math.Ceiling((interval > 0 ? interval : 1) * newEasinessFactor)
                };

                nextInterval = Math.Clamp(nextInterval, MinIntervalDays, MaxIntervalDays);
            }


            nextIterationAt = DateTime.UtcNow.AddDays(nextInterval);

            return (nextInterval, newEasinessFactor, nextIterationAt);
        }


        public static bool IsRecallSuccessful(double quality) => quality >= 3;

        private static double CalcFuzzyAccuracy(double similarity, double min=0.75, double max=0.9)
        {
            if (similarity <= min)  return 0;
            if (similarity >= max) return 1;
            return (similarity - min) / (max - min);
        }

        private static double CalcSigmoidReaction(double ratio, double min=0.7, double max=1.3, double center=1.0, double steepness=3.0)
        {
            return min + (max - min) / (1.0 + Math.Exp(-steepness * (ratio - center)));
        }
    }
}
