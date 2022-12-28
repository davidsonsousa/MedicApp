namespace ClinicManagement.Infrastructure.Services;

public class DepartmentService : ServiceBase<Department>, IDepartmentService
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IBranchRepository branchRepository;

    public DepartmentService(IDepartmentRepository departmentRepository, IBranchRepository branchRepository, ILoggerFactory loggerFactory)
        : base(departmentRepository, loggerFactory)
    {
        this.departmentRepository = departmentRepository;
        this.branchRepository = branchRepository;
    }

    public async Task<IResult> GetAllDepartments(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllDepartments));
        var result = new Result<IEnumerable<DepartmentResponse>>();

        try
        {
            var departments = await departmentRepository.GetAllAsync(cancellationToken);
            Guard.Against.Null(departments, nameof(departments));

            result.Value = departments.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DepartmentService), nameof(GetAllDepartments));
            result.SetErrorMessage("An error has occurred while loading the departments");
        }

        return result;
    }

    public async Task<IResult> GetDepartmentById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(DepartmentService), nameof(GetDepartmentById), id);
        var result = new Result<DepartmentResponse>();

        try
        {
            var department = await departmentRepository.GetDepartmentWithBranchByIdAsync(id, cancellationToken);
            Guard.Against.Null(department, nameof(department));

            result.Value = department.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DepartmentService), nameof(GetDepartmentById));
            result.SetErrorMessage("An error has occurred while loading the department");
        }

        return result;
    }

    public async Task<IResult> GetDepartmentsByBranchId(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(DepartmentService), nameof(GetDepartmentsByBranchId), id);
        var result = new Result<IEnumerable<DepartmentResponse>>();

        try
        {
            var departments = await departmentRepository.GetDepartmentsWithBranchByBranchIdAsync(id, cancellationToken);
            Guard.Against.Null(departments, nameof(departments));

            result.Value = departments.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DepartmentService), nameof(GetDepartmentsByBranchId));
            result.SetErrorMessage("An error has occurred while loading the department");
        }

        return result;
    }

    public async Task<IResult> SaveAsync(DepartmentRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(DepartmentService), nameof(SaveAsync), model);
        var result = new Result($"Department '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await departmentRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(DepartmentService), nameof(GetDepartmentById));
            result.SetErrorMessage("An error has occurred while saving the department");
        }

        return result;
    }

    private async Task AddOrUpdateAsync(DepartmentRequest model, CancellationToken cancellationToken = default)
    {
        if (model.IsNew)
        {
            var department = model.MapToEntity(await branchRepository.GetByIdAsync(model.BranchId, cancellationToken));
            await departmentRepository.AddAsync(department, cancellationToken);
        }
        else
        {
            var department = model.MapToEntity(await departmentRepository.GetByIdAsync(model.VanityId, cancellationToken),
                                               await branchRepository.GetByIdAsync(model.BranchId, cancellationToken));
            departmentRepository.Update(department, cancellationToken);
        }
    }
}
