using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;
using Sample.Questionnaire.Di;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var isRunningInContainer = bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var result) && result;
var configuration = builder.Configuration;

// Configure Serilog
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger());

// Configure connection to database
var connectionString = isRunningInContainer
    ? configuration.GetConnectionString("Docker")
    : configuration.GetConnectionString("Default");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServices(connectionString);

builder.Services.AddHealthChecks()
    .AddSqlServer(connectionString, timeout: TimeSpan.FromSeconds(5))
    .AddCheck("example", () => HealthCheckResult.Healthy("Example check is healthy"), ["example"]);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseStatusCodePagesWithReExecute("~/error");
    //app.UseExceptionHandler("~/error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Configure Prometheus
app.UseMetricServer();
app.UseHttpMetrics();

app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapMetrics();
app.MapHealthChecks("/health");

app.Run();
