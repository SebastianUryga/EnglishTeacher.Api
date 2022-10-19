using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public interface IRandomProbabilityValuePolicy
    {
        bool IsApplicable(PolicyData data);

        KeyValuePair<Word, double> SetProbabilityValue(PolicyData data);
    }
}
