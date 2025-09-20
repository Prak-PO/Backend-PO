using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_PO.Models;

namespace Backend_PO.Interfaces
{
    public interface IKursService
    {
        Task<Kurs> CreateKursAsync(Kurs kurs);
        Task<Kurs?> GetKursByIdAsync(int id);
        Task<List<Kurs>> GetAllKursAsync();
        Task<bool> UpdateKursAsync(int id, Kurs updatedKurs);
        Task<bool> DeleteKursAsync(int id);
    }
}