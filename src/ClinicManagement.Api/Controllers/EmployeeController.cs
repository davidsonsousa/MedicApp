namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IDoctorService doctorService;
    private readonly INurseService nurseService;
    private readonly IWorkScheduleService workScheduleService;

    public EmployeeController(IDoctorService doctorService, INurseService nurseService, IWorkScheduleService workScheduleService)
    {
        this.doctorService = doctorService;
        this.nurseService = nurseService;
        this.workScheduleService = workScheduleService;
    }

    /// <summary>
    /// Gets the list of doctors
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of doctors</returns>
    [HttpGet("doctors")]
    public async Task<IActionResult> GetDoctorsAsync(CancellationToken cancellationToken)
    {
        var result = await doctorService.GetAllDoctors(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<DoctorResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets the list of workSchedules
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of workSchedules</returns>
    [HttpGet("doctor/work-schedule")]
    public async Task<IActionResult> GetDoctorWorkSchedulesAsync(CancellationToken cancellationToken)
    {
        var result = await doctorService.GetAllDoctorWorkSchedules(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<WorkScheduleEmployeeResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets the list of nurses
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of nurses</returns>
    [HttpGet("nurses")]
    public async Task<IActionResult> GetNurseAsync(CancellationToken cancellationToken)
    {
        var result = await nurseService.GetAllNurses(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<NurseResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets the list of workSchedules
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of workSchedules</returns>
    [HttpGet("nurse/work-schedule")]
    public async Task<IActionResult> GetNurseWorkSchedulesAsync(CancellationToken cancellationToken)
    {
        var result = await nurseService.GetAllNurseWorkSchedules(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<WorkScheduleEmployeeResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets the list of workSchedules
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of workSchedules</returns>
    [HttpGet("work-schedules")]
    public async Task<IActionResult> GetWorkSchedulesAsync(CancellationToken cancellationToken)
    {
        var result = await workScheduleService.GetAllWorkSchedules(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<WorkScheduleEmployeeResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets a doctor by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("doctor/{id}")]
    public async Task<IActionResult> GetDoctorsAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await doctorService.GetDoctorById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<DoctorResponse>());
    }

    /// <summary>
    /// Gets a nurse by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("nurse/{id}")]
    public async Task<IActionResult> GetNurseAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await nurseService.GetNurseById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<NurseResponse>());
    }

    /// <summary>
    /// Gets a workSchedule by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("work-schedule/{id}")]
    public async Task<IActionResult> GetWorkScheduleAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await workScheduleService.GetWorkScheduleById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<WorkScheduleEmployeeResponse>());
    }

    /// <summary>
    /// Inserts a new doctor
    /// </summary>
    /// <param name="doctorRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("doctor")]
    public async Task PostDoctorAsync(DoctorRequest doctorRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveAsync(doctorRequest, cancellationToken);
    }

    /// <summary>
    /// Inserts a new workSchedule for doctors
    /// </summary>
    /// <param name="workScheduleRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("doctor/work-schedule")]
    public async Task PostDoctorWorkScheduleAsync(WorkScheduleEmployeeRequest workScheduleRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveDoctorWorkScheduleAsync(workScheduleRequest, cancellationToken);
    }

    /// <summary>
    /// Inserts a new nurse
    /// </summary>
    /// <param name="nurseRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("nurse")]
    public async Task PostNurseAsync(NurseRequest nurseRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveAsync(nurseRequest, cancellationToken);
    }

    /// <summary>
    /// Inserts a new workSchedule for nurses
    /// </summary>
    /// <param name="workScheduleRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("nurse/work-schedule")]
    public async Task PostNurseWorkScheduleAsync(WorkScheduleEmployeeRequest workScheduleRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveNurseWorkScheduleAsync(workScheduleRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing doctor
    /// </summary>
    /// <param name="doctorRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("doctor")]
    public async Task PutDoctorAsync(DoctorRequest doctorRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveAsync(doctorRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing workSchedule
    /// </summary>
    /// <param name="workScheduleRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("doctor/work-schedule")]
    public async Task PutDoctorWorkScheduleAsync(WorkScheduleEmployeeRequest workScheduleRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveDoctorWorkScheduleAsync(workScheduleRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing nurse
    /// </summary>
    /// <param name="nurseRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("nurse")]
    public async Task PutNurseAsync(NurseRequest nurseRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveAsync(nurseRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing workSchedule
    /// </summary>
    /// <param name="workScheduleRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("nurse/work-schedule")]
    public async Task PutNurseWorkScheduleAsync(WorkScheduleEmployeeRequest workScheduleRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveNurseWorkScheduleAsync(workScheduleRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing doctor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("doctor")]
    public async Task DeleteDoctorAsync(Guid id, CancellationToken cancellationToken)
    {
        await doctorService.DeleteAsync(id, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing nurse
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("nurse")]
    public async Task DeleteNurseAsync(Guid id, CancellationToken cancellationToken)
    {
        await nurseService.DeleteAsync(id, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing work schedule
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("work-schedule")]
    public async Task DeleteWorkScheduleAsync(Guid id, CancellationToken cancellationToken)
    {
        await workScheduleService.DeleteAsync(id, cancellationToken);
    }
}
