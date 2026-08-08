using System.ComponentModel.DataAnnotations;

namespace Equipment_Borrowing.Models.Domain
{
    public class EquipmentBorrowing
    {
        public int Id { get; set; }

        [Display(Name = "Transaction Number")]
        public string TransactionNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Borrower name is required.")]
        [StringLength(100)]
        [Display(Name = "Borrower Name")]
        public string BorrowerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Borrower type is required.")]
        [Display(Name = "Borrower Type")]
        public string BorrowerType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student/Employee ID is required.")]
        [Display(Name = "Student/Employee ID")]
        public string BorrowerId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department or Course is required.")]
        [Display(Name = "Department / Course")]
        public string DepartmentOrCourse { get; set; } = string.Empty;

        [Required(ErrorMessage = "Equipment name is required.")]
        [Display(Name = "Equipment Name")]
        public string EquipmentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Equipment category is required.")]
        [Display(Name = "Equipment Category")]
        public string EquipmentCategory { get; set; } = string.Empty;

        [Required]
        [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50.")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Borrow Date & Time")]
        public DateTime BorrowDateTime { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Expected Return Date")]
        public DateTime ExpectedReturnDate { get; set; } = DateTime.Now.AddDays(1);

        [DataType(DataType.DateTime)]
        [Display(Name = "Actual Return Date")]
        public DateTime? ActualReturnDateTime { get; set; }

        public string Status { get; set; } = "Borrowed";

        [Required(ErrorMessage = "Purpose is required.")]
        [StringLength(500)]
        public string Purpose { get; set; } = string.Empty;

        public string? Notes { get; set; }
    }
}