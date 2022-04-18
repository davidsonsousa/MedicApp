var builder = WebApplication.CreateBuilder(args);

// Initializing Logger
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
                                               .Enrich.FromLogContext().CreateLogger();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClinicManagementContext>(options => options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
                                                                  .UseSqlServer(connectionString,
                                                                                o => o.MigrationsAssembly("ClinicManagement.Infrastructure")
                                                                                      .UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery)));

// Configure DI
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IClinicService, ClinicService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Log.Debug("DEV API: https://localhost:7002/swagger/index.html");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
