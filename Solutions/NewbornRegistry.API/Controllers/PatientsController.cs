using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewbornRegistry.API.ViewModels.Create;
using NewbornRegistry.API.ViewModels.Get;
using NewbornRegistry.API.ViewModels.Update;
using NewbornRegistry.BLL.Models.Create;
using NewbornRegistry.BLL.Models.Update;
using NewbornRegistry.BLL.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace NewbornRegistry.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;
    private readonly IMapper _mapper;

    public PatientsController(IPatientService patientService,
        IMapper mapper)
    {
        _patientService = patientService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Создание нового пациента")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Пациент успешно создан", Type = typeof(PatientViewModel), ContentTypes = new[] { MediaTypeNames.Application.Json })]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Ошибка валидации", Type = typeof(ValidationProblemDetails), ContentTypes = new[] { MediaTypeNames.Application.Json })]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Внутренняя ошибка сервера", ContentTypes = new[] { MediaTypeNames.Application.Json })]
    public async Task<IActionResult> Create(CreatePatientViewModel patientViewModel)
    {
        var patientModel = _mapper.Map<CreatePatientModel>(patientViewModel);
        var createdPatientModel = await _patientService.CreateAsync(patientModel);
        var createdPatientViewModel = _mapper.Map<PatientViewModel>(createdPatientModel);

        return Ok(createdPatientViewModel);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Получение пациента по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Пациент найден", Type = typeof(PatientViewModel), ContentTypes = new[] { MediaTypeNames.Application.Json })]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Пациент не найден")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Внутренняя ошибка сервера", ContentTypes = new[] { MediaTypeNames.Application.Json })]
    public async Task<IActionResult> Get(Guid id)
    {
        var patientModel = await _patientService.GetByIdAsync(id);
        var patientViewModel = _mapper.Map<PatientViewModel>(patientModel);

        return Ok(patientViewModel);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Получение всех пациентов с возможностью фильтрации по дате рождения")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Список пациентов", Type = typeof(List<PatientViewModel>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Неверный формат параметра")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Внутренняя ошибка сервера")]
    public async Task<IActionResult> GetAll([FromQuery] string birthDate)
    {
        var patientModels = await _patientService.GetAllAsync(birthDate);
        var patientViewModels = _mapper.Map<List<PatientViewModel>>(patientModels);
        return Ok(patientViewModels);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Обновление данных пациента по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Пациент обновлён", Type = typeof(PatientViewModel), ContentTypes = new[] { MediaTypeNames.Application.Json })]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Ошибка валидации", Type = typeof(ValidationProblemDetails), ContentTypes = new[] { MediaTypeNames.Application.Json })]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Пациент не найден")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Внутренняя ошибка сервера", ContentTypes = new[] { MediaTypeNames.Application.Json })]
    public async Task<IActionResult> Update(Guid id, UpdatePatientViewModel patientViewModel)
    {
        var patientModel = _mapper.Map<UpdatePatientModel>(patientViewModel);
        patientModel.Name.Id = id;

        var updatedPatientModel = await _patientService.UpdateAsync(patientModel);
        var updatedPatientViewModel = _mapper.Map<PatientViewModel>(updatedPatientModel);

        return Ok(updatedPatientViewModel);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Удаление пациента по ID")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "Пациент удалён")]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Пациент не найден")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Внутренняя ошибка сервера", ContentTypes = new[] { MediaTypeNames.Application.Json })]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _patientService.DeleteAsync(id);
        return Ok();
    }
}