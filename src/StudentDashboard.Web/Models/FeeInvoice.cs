using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class FeeInvoice : BaseEntity
{
    [Required]
    public int StudentId { get; set; }
    public Student? Student { get; set; }

    [Range(1, 10000000)]
    public decimal Amount { get; set; }

    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(15);

    public bool IsPaid { get; set; }

    [StringLength(250)]
    public string Notes { get; set; } = string.Empty;
}
