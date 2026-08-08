using Equipment_Borrowing.Models.Domain;

namespace Equipment_Borrowing.Repositories
{
    public class EquipmentBorrowingRepository : IEquipmentBorrowingRepository
    {
        private static readonly List<EquipmentBorrowing> _items = new();

        public IEnumerable<EquipmentBorrowing> GetAll(string? searchTerm = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _items;

            return _items.Where(e =>
                e.BorrowerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.EquipmentName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.TransactionNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.BorrowerId.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public EquipmentBorrowing? GetById(int id) => _items.FirstOrDefault(x => x.Id == id);

        public void Add(EquipmentBorrowing item)
        {
            item.Id = _items.Any() ? _items.Max(x => x.Id) + 1 : 1;
            item.TransactionNumber = $"TXN-{DateTime.Now:yyyyMMdd}-{item.Id:D4}";
            _items.Add(item);
        }

        public void Update(EquipmentBorrowing item)
        {
            var existing = GetById(item.Id);
            if (existing != null)
            {
                existing.BorrowerName = item.BorrowerName;
                existing.BorrowerType = item.BorrowerType;
                existing.BorrowerId = item.BorrowerId;
                existing.DepartmentOrCourse = item.DepartmentOrCourse;
                existing.EquipmentName = item.EquipmentName;
                existing.EquipmentCategory = item.EquipmentCategory;
                existing.Quantity = item.Quantity;
                existing.BorrowDateTime = item.BorrowDateTime;
                existing.ExpectedReturnDate = item.ExpectedReturnDate;
                existing.ActualReturnDateTime = item.ActualReturnDateTime;
                existing.Status = item.Status;
                existing.Purpose = item.Purpose;
                existing.Notes = item.Notes;
            }
        }
    }
}