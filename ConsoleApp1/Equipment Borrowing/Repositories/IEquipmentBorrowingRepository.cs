using Equipment_Borrowing.Models.Domain;

namespace Equipment_Borrowing.Repositories
{
    public interface IEquipmentBorrowingRepository
    {
        IEnumerable<EquipmentBorrowing> GetAll(string? searchTerm = null);
        EquipmentBorrowing? GetById(int id);
        void Add(EquipmentBorrowing item);
        void Update(EquipmentBorrowing item);
    }
}