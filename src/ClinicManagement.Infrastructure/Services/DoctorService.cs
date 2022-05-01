namespace ClinicManagement.Infrastructure.Services;

public class DoctorService : ServiceBase<Doctor>, IDoctorService
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly ILanguageRepository languageRepository;

    public DoctorService(IDoctorRepository doctorRepository, IDepartmentRepository departmentRepository, ILanguageRepository languageRepository, ILoggerFactory loggerFactory)
        : base(doctorRepository, loggerFactory)
    {
        this.doctorRepository = doctorRepository;
        this.departmentRepository = departmentRepository;
        this.languageRepository = languageRepository;
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

            await doctorRepository.AddDepartmentsToDoctorAsync(doctor, departments, cancellationToken);
            await doctorRepository.AddLanguagesToPersonAsync(doctor, languages, cancellationToken);
        }
        else
        {
            doctor = model.MapToEntity(await doctorRepository.GetDoctorWithDepartmentsAndLanguagesById(model.VanityId, cancellationToken));
            await doctorRepository.UpdateDoctorDepartmentsAsync(doctor, departments, cancellationToken);
            await doctorRepository.UpdatePersonLanguagesAsync(doctor, languages, cancellationToken);
        }
    }
}
