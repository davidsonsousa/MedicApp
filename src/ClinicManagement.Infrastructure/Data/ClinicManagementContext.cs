namespace ClinicManagement.Infrastructure.Data;

public class ClinicManagementContext : DbContext
{
    public DbSet<Clinic> Clinics => Set<Clinic>();

    public DbSet<Branch> Branches => Set<Branch>();

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Doctor> Doctor => Set<Doctor>();

    public DbSet<Nurse> Nurses => Set<Nurse>();

    public DbSet<WorkSchedule> WorkSchedules => Set<WorkSchedule>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<Language> Languages => Set<Language>();

    public ClinicManagementContext(DbContextOptions<ClinicManagementContext> options)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ClinicEntityConfiguration().Configure(modelBuilder.Entity<Clinic>());
        new BranchEntityConfiguration().Configure(modelBuilder.Entity<Branch>());
        new DepartmentEntityConfiguration().Configure(modelBuilder.Entity<Department>());
        new LanguageEntityConfiguration().Configure(modelBuilder.Entity<Language>());

        new PersonEntityConfiguration().Configure(modelBuilder.Entity<Person>());
        new PatientEntityConfiguration().Configure(modelBuilder.Entity<Patient>());
        new AppointmentEntityConfiguration().Configure(modelBuilder.Entity<Appointment>());

        new DoctorEntityConfiguration().Configure(modelBuilder.Entity<Doctor>());
        new NurseEntityConfiguration().Configure(modelBuilder.Entity<Nurse>());
        new WorkScheduleEntityConfiguration().Configure(modelBuilder.Entity<WorkSchedule>());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.DetectChanges();
        var entries = ChangeTracker.Entries().Where(e => e.Entity is EntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified));

        // TODO: Get the user who triggered the operation
        //var currentUsername = httpContextAccessor.HttpContext.User.Identity.Name;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                //entry.Property("UserCreated").CurrentValue = currentUsername;
            }

            entry.Property("DateModified").CurrentValue = DateTime.Now;
            //entry.Property("UserModified").CurrentValue = currentUsername;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
