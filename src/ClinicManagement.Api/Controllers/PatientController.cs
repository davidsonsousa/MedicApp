using ClinicManagement.ApplicationCore.Models.Responses.ApointmentPatient;

namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService patientService;
    private readonly IAppointmentService appointmentService;

    public PatientController(IPatientService patientService, IAppointmentService appointmentService)
    {
        this.patientService = patientService;
        this.appointmentService = appointmentService;
    }

    /// <summary>
    /// Gets the list of patients
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of patients</returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var result = await patientService.GetAllPatients(cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<PatientListResponse>());
    }

    /// <summary>
    /// Gets the list of appointments
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of workSchedules</returns>
    [HttpGet("appointments")]
    public async Task<IActionResult> GetAppointmentsAsync(CancellationToken cancellationToken)
    {
        var result = await appointmentService.GetAllAppointments(cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<AppointmentPatientListResponse>());
    }

    /// <summary>
    /// Gets a patient by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await patientService.GetPatientById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<PatientResponse>());
    }

    /// <summary>
    /// Gets a workSchedule by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("appointment/{id}")]
    public async Task<IActionResult> GetAppointmentAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await appointmentService.GetAppointmentById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<AppointmentPatientResponse>());
    }

    /// <summary>
    /// Inserts a new patient
    /// </summary>
    /// <param name="patientRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task PostAsync(PatientRequest patientRequest, CancellationToken cancellationToken)
    {
        await patientService.SaveAsync(patientRequest, cancellationToken);
    }

    /// <summary>
    /// Inserts a new appointment for patients
    /// </summary>
    /// <param name="appointmentRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("appointment")]
    public async Task PostAppointmentAsync(AppointmentPatientRequest appointmentRequest, CancellationToken cancellationToken)
    {
        await patientService.SavePatientAppointmentAsync(appointmentRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing patient
    /// </summary>
    /// <param name="patientRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut]
    public async Task PutAsync(PatientRequest patientRequest, CancellationToken cancellationToken)
    {
        await patientService.SaveAsync(patientRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing workSchedule
    /// </summary>
    /// <param name="appointmentRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("doctor/work-schedule")]
    public async Task PutAppointmentAsync(AppointmentPatientRequest appointmentRequest, CancellationToken cancellationToken)
    {
        await patientService.SavePatientAppointmentAsync(appointmentRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing patient
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await patientService.DeleteAsync(id, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing appointment
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("appointment/{id}")]
    public async Task DeleteAppointmentAsync(Guid id, CancellationToken cancellationToken)
    {
        await appointmentService.DeleteAsync(id, cancellationToken);
    }
}
