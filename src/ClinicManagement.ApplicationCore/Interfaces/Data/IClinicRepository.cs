namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IClinicRepository : IRepository<Clinic>
{
    Task<IEnumerable<Clinic>> GetAllClinicsWithBranchesAsync(CancellationToken cancellationToken = default);

    Task<Clinic?> GetClinicWithBranchesByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
