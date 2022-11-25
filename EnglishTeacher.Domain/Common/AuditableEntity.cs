namespace EnglishTeacher.Domain.Common
{
    public enum Status
    {
        Deleted = 0,
        Active = 1,
        Deactivated = 2,
    }

    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
        public Status Status { get; set; }
        public DateTime? Inactivated { get; set; }
        public string? InactivatedBy { get; set; }
    }
}
