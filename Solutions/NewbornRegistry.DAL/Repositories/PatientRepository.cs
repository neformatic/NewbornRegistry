using Microsoft.EntityFrameworkCore;
using NewbornRegistry.Common.Exceptions;
using NewbornRegistry.DAL.Entities;
using NewbornRegistry.DAL.Repositories.Interfaces;

namespace NewbornRegistry.DAL.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly NewbornRegistryDbContext _dbContext;

    public PatientRepository(NewbornRegistryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Patient patient)
    {
        await _dbContext.Patients.AddAsync(patient);
    }

    public async Task<Patient> GetByIdAsync(Guid id)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);

        return patient;
    }

    public async Task<List<Patient>> GetAllAsync(string prefix = null, DateTime? birthDate = null)
    {
        var query = _dbContext.Patients.AsQueryable();

        if (prefix != null && birthDate.HasValue)
        {
            query = ApplyBirthDateFilter(query, prefix, birthDate.Value);
        }

        return await query.ToListAsync();
    }

    public Task UpdateAsync(Patient patient)
    {
        _dbContext.Patients.Update(patient);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var patient = await _dbContext.Patients.FindAsync(id);

        if (patient == null)
        {
            throw new EntityNotFoundException("Entity was not found");
        }

        _dbContext.Patients.Remove(patient);
    }

    private IQueryable<Patient> ApplyBirthDateFilter(IQueryable<Patient> query, string prefix, DateTime birthDate)
    {
        switch (prefix)
        {
            case "eq":
                return query.Where(p => p.BirthDate.Date == birthDate.Date);
            case "ne":
                return query.Where(p => p.BirthDate.Date != birthDate.Date);
            case "gt":
                return query.Where(p => p.BirthDate.Date > birthDate.Date);
            case "lt":
                return query.Where(p => p.BirthDate.Date < birthDate.Date);
            case "ge":
                return query.Where(p => p.BirthDate.Date >= birthDate.Date);
            case "le":
                return query.Where(p => p.BirthDate.Date <= birthDate.Date);
            case "ap":
                var minDate = birthDate.AddDays(-1).Date;
                var maxDate = birthDate.AddDays(1).Date;
                return query.Where(p => p.BirthDate.Date >= minDate && p.BirthDate.Date <= maxDate);
            case "sa":
                return query.Where(p => p.BirthDate.Date > birthDate.Date);
            case "eb":
                return query.Where(p => p.BirthDate.Date < birthDate.Date);
            default:
                return query;
        }
    }
}