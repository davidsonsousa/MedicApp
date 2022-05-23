namespace ClinicManagement.Infrastructure.Services;

public class NurseService : ServiceBase<Nurse>, INurseService
{
    private readonly INurseRepository nurseRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly ILanguageRepository languageRepository;
    private readonly IWorkScheduleRepository workScheduleRepository;

    public NurseService(INurseRepository nurseRepository, ILoggerFactory loggerFactory,
                        IDepartmentRepository departmentRepository, ILanguageRepository languageRepository, IWorkScheduleRepository workScheduleRepository)
        : base(nurseRepository, loggerFactory)
    {
        this.nurseRepository = nurseRepository;
        this.departmentRepository = departmentRepository;
        this.languageRepository = languageRepository;
        this.workScheduleRepository = workScheduleRepository;
    }

    public async Task<IResult> GetAllNurses(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllNurses));
        var result = new Result<IEnumerable<EmployeeResponse>>();

        try
        {
            var nurses = await nurseRepository.GetAllEmployeesWithDepartmentsAndLanguageAsync(cancellationToken);
            Guard.Against.Null(nurses, nameof(nurses));

            result.Value = nurses.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(NurseService), nameof(GetAllNurses));
            result.SetErrorMessage("An error has occurred while loading the nurses");
        }

        return result;
    }

    public async Task<IResult> GetAllNurseWorkSchedules(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllNurseWorkSchedules));
        var result = new Result<IEnumerable<WorkScheduleEmployeeResponse>>();

        try
        {
            var workSchedules = await workScheduleRepository.GetWorkSchedulesWithEmployeeAndDepartmentByEmployeeTypeAsync(Constants.Discriminator.Nurse, cancellationToken);
            Guard.Against.Null(workSchedules, nameof(workSchedules));

            result.Value = workSchedules.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(NurseService), nameof(GetAllNurseWorkSchedules));
            result.SetErrorMessage("An error has occurred while loading the workSchedules");
        }

        return result;
    }

    public async Task<IResult> GetNurseById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(NurseService), nameof(GetNurseById), id);
        var result = new Result<EmployeeDetailResponse>();

        try
        {
            var nurse = await nurseRepository.GetEmployeeWithDepartmentsAndLanguagesByIdAsync(id, cancellationToken);
            Guard.Against.Null(nurse, nameof(nurse));

            result.Value = nurse.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(NurseService), nameof(GetNurseById));
            result.SetErrorMessage("An error has occurred while loading the nurse");
        }

        return result;
    }

    public async Task<IResult> SaveAsync(NurseRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(NurseService), nameof(SaveAsync), model);
        var result = new Result($"Nurse '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await Repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(NurseService), nameof(GetNurseById));
            result.SetErrorMessage("An error has occurred while saving the nurse");
        }

        return result;
    }

    public async Task<IResult> SaveNurseWorkScheduleAsync(WorkScheduleEmployeeRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(NurseService), nameof(SaveNurseWorkScheduleAsync), model);
        var result = new Result($"WorkSchedule for employee '{model.EmployeeId}' saved.");

        try
        {
            await AddOrUpdateWorkScheduleAsync(model, cancellationToken);
            await workScheduleRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(NurseService), nameof(SaveNurseWorkScheduleAsync));
            result.SetErrorMessage("An error has occurred while saving the workSchedules");
        }

        return result;
    }

    private async Task AddOrUpdateAsync(NurseRequest model, CancellationToken cancellationToken = default)
    {
        Nurse? nurse;
        var departments = await departmentRepository.GetByIdsAsync(model.SelectedDepartments, cancellationToken);
        var languages = await languageRepository.GetByIdsAsync(model.SelectedLanguages, cancellationToken);

        if (model.IsNew)
        {
            nurse = model.MapToEntity();
            await nurseRepository.AddAsync(nurse, cancellationToken);
            await nurseRepository.SaveChangesAsync(cancellationToken);

            await nurseRepository.AddDepartmentsToEmployeeAsync(nurse, departments, cancellationToken);
            await nurseRepository.AddLanguagesToPersonAsync(nurse, languages, cancellationToken);
        }
        else
        {
            nurse = model.MapToEntity(await nurseRepository.GetEmployeeWithDepartmentsAndLanguagesByIdAsync(model.VanityId, cancellationToken));
            await nurseRepository.UpdateEmployeeDepartmentsAsync(nurse, departments, cancellationToken);
            await nurseRepository.UpdatePersonLanguagesAsync(nurse, languages, cancellationToken);
            nurseRepository.Update(nurse, cancellationToken);
        }
    }

    private async Task AddOrUpdateWorkScheduleAsync(WorkScheduleEmployeeRequest model, CancellationToken cancellationToken = default)
    {
        if (model.IsNew)
        {
            var workSchedules = model.MapToEntity(await nurseRepository.GetByIdAsync(model.EmployeeId, cancellationToken),
                                                  await departmentRepository.GetByIdAsync(model.DepartmentId, cancellationToken));
            await workScheduleRepository.AddAsync(workSchedules, cancellationToken);
        }
        else
        {
            var workSchedules = model.MapToEntity(await workScheduleRepository.GetByIdAsync(model.VanityId, cancellationToken));
            workScheduleRepository.Update(workSchedules, cancellationToken);
        }
    }
}
