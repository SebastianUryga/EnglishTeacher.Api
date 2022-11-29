using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public interface IWordProbabilityValuePolicy
    {
        bool IsApplicable(PolicyData data);

        double CalculateProbabilityValue(PolicyData data);
    }
}
