namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IClinicRepository : IRepository<Clinic>
{
    Task<IEnumerable<Clinic>> GetAllClinicsWithBranchesAsync(CancellationToken cancellationToken = default);
}
