using AutoMapper;
using NewbornRegistry.BLL.Common;
using NewbornRegistry.BLL.Models.Create;
using NewbornRegistry.BLL.Models.Get;
using NewbornRegistry.BLL.Models.Update;
using NewbornRegistry.BLL.Services.Interfaces;
using NewbornRegistry.Common.Exceptions;
using NewbornRegistry.DAL;
using NewbornRegistry.DAL.Entities;
using NewbornRegistry.DAL.Repositories.Interfaces;

namespace NewbornRegistry.BLL.Services;

public class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IPatientRepository _patientRepository;
    private readonly NewbornRegistryDbContext _dbContext;

    public PatientService(IMapper mapper, IPatientRepository patientRepository, NewbornRegistryDbContext dbContext)
    {
        _mapper = mapper;
        _patientRepository = patientRepository;
        _dbContext = dbContext;
    }

    public async Task<PatientModel> CreateAsync(CreatePatientModel patientModel)
    {
        var patient = _mapper.Map<Patient>(patientModel);

        await _patientRepository.CreateAsync(patient);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<PatientModel>(patient);
    }

    public async Task<PatientModel> GetByIdAsync(Guid id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);

        if (patient == null)
        {
            throw new EntityNotFoundException("Entity was not found");
        }

        return _mapper.Map<PatientModel>(patient);
    }

    public async Task<List<PatientModel>> GetAllAsync(string birthDate)
    {
        var patients = new List<Patient>();

        if (string.IsNullOrEmpty(birthDate))
        {
            patients = await _patientRepository.GetAllAsync();

            return _mapper.Map<List<PatientModel>>(patients);
        }

        string prefix = null;
        var birthDateValue = birthDate;

        var supportedPrefixes = new List<string> { "eq", "ne", "gt", "lt", "ge", "le", "sa", "eb", "ap" };

        foreach (var p in supportedPrefixes)
        {
            if (birthDate.StartsWith(p))
            {
                prefix = p;
                birthDateValue = birthDate.Substring(p.Length);
                break;
            }
        }

        if (prefix == null)
        {
            throw new BadRequestException($"Invalid prefix in birthDate parameter. Supported prefixes are: {string.Join(", ", supportedPrefixes)}");
        }

        if (!DateTime.TryParse(birthDateValue, out var parsedDate))
        {
            throw new BadRequestException("Invalid birthDate format");
        }

        patients = await _patientRepository.GetAllAsync(prefix, parsedDate);

        return _mapper.Map<List<PatientModel>>(patients);
    }

    public async Task<PatientModel> UpdateAsync(UpdatePatientModel patient)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(patient.Name.Id);

        if (existingPatient == null)
        {
            throw new EntityNotFoundException("Entity was not found");
        }

        _mapper.Map(patient, existingPatient);

        await _patientRepository.UpdateAsync(existingPatient);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<PatientModel>(existingPatient);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _patientRepository.DeleteAsync(id);
        await _dbContext.SaveChangesAsync();
    }
}