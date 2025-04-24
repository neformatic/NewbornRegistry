using NewbornRegistry.DAL.Entities;

namespace NewbornRegistry.DAL.Repositories.Interfaces;

public interface IPatientRepository
{
    Task CreateAsync(Patient patient);
    Task<Patient> GetByIdAsync(Guid id);
    Task<List<Patient>> GetAllAsync(string prefix = null, DateTime? birthDate = null);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(Guid id);
}