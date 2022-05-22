namespace ClinicManagement.Infrastructure.Services;

public class PatientService : ServiceBase<Patient>, IPatientService
{
    private readonly IPatientRepository patientRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly ILanguageRepository languageRepository;
    private readonly IAppointmentRepository appointmentRepository;

    public PatientService(IPatientRepository patientRepository, ILoggerFactory loggerFactory,
                        IDepartmentRepository departmentRepository, ILanguageRepository languageRepository, IAppointmentRepository appointmentRepository)
        : base(patientRepository, loggerFactory)
    {
        this.patientRepository = patientRepository;
        this.departmentRepository = departmentRepository;
        this.languageRepository = languageRepository;
        this.appointmentRepository = appointmentRepository;
    }

    public async Task<IResult> GetAllPatients(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllPatients));
        var result = new Result<IEnumerable<PatientResponse>>();

        try
        {
            var patients = await Repository.GetAllAsync(cancellationToken);
            Guard.Against.Null(patients, nameof(patients));

            result.Value = patients.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(PatientService), nameof(GetAllPatients));
            result.SetErrorMessage("An error has occurred while loading the patients");
        }

        return result;
    }

    public async Task<IResult> GetAllPatientAppointments(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllPatientAppointments));
        var result = new Result<IEnumerable<AppointmentPatientResponse>>();

        try
        {
            var appointments = await appointmentRepository.GetAppointmentsWithPatientAsync(cancellationToken);
            Guard.Against.Null(appointments, nameof(appointments));

            result.Value = appointments.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(PatientService), nameof(GetAllPatientAppointments));
            result.SetErrorMessage("An error has occurred while loading the appointments");
        }

        return result;
    }

    public async Task<IResult> GetPatientById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(PatientService), nameof(GetPatientById), id);
        var result = new Result<PatientResponse>();

        try
        {
            var patient = await Repository.GetByIdAsync(id, cancellationToken);
            Guard.Against.Null(patient, nameof(patient));

            result.Value = patient.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(PatientService), nameof(GetPatientById));
            result.SetErrorMessage("An error has occurred while loading the patient");
        }

        return result;
    }

    public async Task<IResult> SaveAsync(PatientRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(PatientService), nameof(SaveAsync), model);
        var result = new Result($"Patient '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await Repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(PatientService), nameof(GetPatientById));
            result.SetErrorMessage("An error has occurred while saving the patient");
        }

        return result;
    }

    public async Task<IResult> SavePatientAppointmentAsync(AppointmentPatientRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(PatientService), nameof(SavePatientAppointmentAsync), model);
        var result = new Result($"Appointment for employee '{model.PersonId}' saved.");

        try
        {
            await AddOrUpdateAppointmentAsync(model, cancellationToken);
            await appointmentRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(PatientService), nameof(SavePatientAppointmentAsync));
            result.SetErrorMessage("An error has occurred while saving the appointments");
        }

        return result;
    }

    private async Task AddOrUpdateAsync(PatientRequest model, CancellationToken cancellationToken = default)
    {
        Patient? patient;
        //var departments = await departmentRepository.GetByIdsAsync(model.SelectedDepartments, cancellationToken);
        //var languages = await languageRepository.GetByIdsAsync(model.SelectedLanguages, cancellationToken);

        if (model.IsNew)
        {
            patient = model.MapToEntity();
            await patientRepository.AddAsync(patient, cancellationToken);
            await patientRepository.SaveChangesAsync(cancellationToken);

            //await patientRepository.AddDepartmentsToEmployeeAsync(patient, departments, cancellationToken);
            //await patientRepository.AddLanguagesToPersonAsync(patient, languages, cancellationToken);
        }
        else
        {
            patient = model.MapToEntity(await patientRepository.GetByIdAsync(model.VanityId, cancellationToken));
            //await patientRepository.UpdateEmployeeDepartmentsAsync(patient, departments, cancellationToken);
            //await patientRepository.UpdatePersonLanguagesAsync(patient, languages, cancellationToken);
            patientRepository.Update(patient, cancellationToken);
        }
    }

    private async Task AddOrUpdateAppointmentAsync(AppointmentPatientRequest model, CancellationToken cancellationToken = default)
    {
        if (model.IsNew)
        {
            var appointments = model.MapToEntity(await patientRepository.GetByIdAsync(model.PersonId, cancellationToken));
            await appointmentRepository.AddAsync(appointments, cancellationToken);
        }
        else
        {
            var appointments = model.MapToEntity(await appointmentRepository.GetByIdAsync(model.VanityId, cancellationToken));
            appointmentRepository.Update(appointments, cancellationToken);
        }
    }
}
