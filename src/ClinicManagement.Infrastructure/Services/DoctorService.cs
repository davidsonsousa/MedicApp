namespace ClinicManagement.Infrastructure.Services;

public class DoctorService : ServiceBase<Doctor>, IDoctorService
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly ILanguageRepository languageRepository;
    private readonly IWorkScheduleRepository workScheduleRepository;

    public DoctorService(IDoctorRepository doctorRepository, ILoggerFactory loggerFactory, IDepartmentRepository departmentRepository,
                         ILanguageRepository languageRepository, IWorkScheduleRepository workScheduleRepository)
        : base(doctorRepository, loggerFactory)
    {
        this.doctorRepository = doctorRepository;
        this.departmentRepository = departmentRepository;
        this.languageRepository = languageRepository;
        this.workScheduleRepository = workScheduleRepository;
    }

    public async Task<IResult> GetAllDoctors(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllDoctors));
        var result = new Result<IEnumerable<DoctorResponse>>();

        try
        {
            var doctors = await Repository.GetAllAsync(cancellationToken);
            Guard.Against.Null(doctors, nameof(doctors));

            result.Value = doctors.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DoctorService), nameof(GetAllDoctors));
            result.SetErrorMessage("An error has occurred while loading the doctors");
        }

        return result;
    }

    public async Task<IResult> GetAllDoctorWorkSchedules(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllDoctorWorkSchedules));
        var result = new Result<IEnumerable<WorkScheduleEmployeeResponse>>();

        try
        {
            var workSchedules = await workScheduleRepository.GetWorkSchedulesWithEmployeeAndDepartmentByEmployeeTypeAsync(Constants.Discriminator.Doctor, cancellationToken);
            Guard.Against.Null(workSchedules, nameof(workSchedules));

            result.Value = workSchedules.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DoctorService), nameof(GetAllDoctorWorkSchedules));
            result.SetErrorMessage("An error has occurred while loading the workSchedules");
        }

        return result;
    }

    public async Task<IResult> GetDoctorById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(DoctorService), nameof(GetDoctorById), id);
        var result = new Result<DoctorResponse>();

        try
        {
            var doctor = await Repository.GetByIdAsync(id, cancellationToken);
            Guard.Against.Null(doctor, nameof(doctor));

            result.Value = doctor.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DoctorService), nameof(GetDoctorById));
            result.SetErrorMessage("An error has occurred while loading the doctor");
        }

        return result;
    }

    public async Task<IResult> SaveAsync(DoctorRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(DoctorService), nameof(SaveAsync), model);
        var result = new Result($"Doctor '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await Repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DoctorService), nameof(GetDoctorById));
            result.SetErrorMessage("An error has occurred while saving the doctor");
        }

        return result;
    }

    public async Task<IResult> SaveDoctorWorkScheduleAsync(WorkScheduleEmployeeRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(DoctorService), nameof(SaveDoctorWorkScheduleAsync), model);
        var result = new Result($"WorkSchedule for employee '{model.EmployeeId}' saved.");

        try
        {
            await AddOrUpdateWorkScheduleAsync(model, cancellationToken);
            await workScheduleRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DoctorService), nameof(SaveDoctorWorkScheduleAsync));
            result.SetErrorMessage("An error has occurred while saving the workSchedules");
        }

        return result;
    }

    private async Task AddOrUpdateAsync(DoctorRequest model, CancellationToken cancellationToken = default)
    {
        Doctor? doctor;
        var departments = await departmentRepository.GetByIdsAsync(model.SelectedDepartments, cancellationToken);
        var languages = await languageRepository.GetByIdsAsync(model.SelectedLanguages, cancellationToken);

        if (model.IsNew)
        {
            doctor = model.MapToEntity();
            await doctorRepository.AddAsync(doctor, cancellationToken);
            await doctorRepository.SaveChangesAsync(cancellationToken);

            await doctorRepository.AddDepartmentsToEmployeeAsync(doctor, departments, cancellationToken);
            await doctorRepository.AddLanguagesToPersonAsync(doctor, languages, cancellationToken);
        }
        else
        {
            doctor = model.MapToEntity(await doctorRepository.GetEmployeeWithDepartmentsAndLanguagesById(model.VanityId, cancellationToken));
            await doctorRepository.UpdateEmployeeDepartmentsAsync(doctor, departments, cancellationToken);
            await doctorRepository.UpdatePersonLanguagesAsync(doctor, languages, cancellationToken);
            doctorRepository.Update(doctor, cancellationToken);
        }
    }

    private async Task AddOrUpdateWorkScheduleAsync(WorkScheduleEmployeeRequest model, CancellationToken cancellationToken = default)
    {
        if (model.IsNew)
        {
            var workSchedules = model.MapToEntity(await doctorRepository.GetByIdAsync(model.EmployeeId, cancellationToken),
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
