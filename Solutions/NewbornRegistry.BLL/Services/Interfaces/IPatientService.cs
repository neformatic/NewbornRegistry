using NewbornRegistry.BLL.Models.Create;
using NewbornRegistry.BLL.Models.Get;
using NewbornRegistry.BLL.Models.Update;

namespace NewbornRegistry.BLL.Services.Interfaces;

public interface IPatientService
{
    Task<PatientModel> CreateAsync(CreatePatientModel patientModel);
    Task<PatientModel> GetByIdAsync(Guid id);
    Task<List<PatientModel>> GetAllAsync(string birthDate);
    Task<PatientModel> UpdateAsync(UpdatePatientModel patient);
    Task DeleteAsync(Guid id);
}