using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Database - SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=premium.db"));

// OpenAPI
builder.Services.AddOpenApi();

// CORS - מאפשר ל-Angular ב-StackBlitz לגשת ל-API
builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Services
builder.Services.AddScoped<Service>();
builder.Services.AddScoped<IImportService, ImportService>();
builder.Services.AddScoped<IMetricService, MetricService>();

// Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// OpenAPI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// CORS - חייב להיות לפני MapControllers
app.UseCors("Angular");

// Controllers
app.MapControllers();

// Root endpoint
app.MapGet("/", () => "TaskNMH API is running");

// Seed - הכנסת נתוני בדיקה ל-DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // אם אין נתונים - ניצור נתוני דוגמה
    if (!db.PremiumMethods.Any())
    {
        var method = new PremiumMethod
        {
            MethodNumber = "PM001",
            Description = "שיטת פרמיה לעובדים",
            PremiumPercent = 5,
            CalculationPeriod = "Monthly"
        };

        db.PremiumMethods.Add(method);
        db.SaveChanges();

        var metric = new Metric
        {
            PremiumMethodId = method.Id,
            Name = "נתוני עובדים",
            Description = "מדד נתוני עובדים",
            SourceType = "Excel",
            SourceName = "Workers",
            Frequency = "Monthly"
        };

        db.Metrics.Add(metric);
        db.SaveChanges();

        db.MetricFields.AddRange(
            new MetricField
            {
                MetricId = metric.Id,
                Name = "ת\"ז",
                DataType = "string",
                IsRelevant = true,
                IsRequired = true,
                DisplayOrder = 1
            },
            new MetricField
            {
                MetricId = metric.Id,
                Name = "שם עובד",
                DataType = "string",
                IsRelevant = true,
                IsRequired = true,
                DisplayOrder = 2
            },
            new MetricField
            {
                MetricId = metric.Id,
                Name = "מחלקה",
                DataType = "string",
                IsRelevant = true,
                IsRequired = false,
                DisplayOrder = 3
            },
            new MetricField
            {
                MetricId = metric.Id,
                Name = "סטטוס",
                DataType = "string",
                IsRelevant = true,
                IsRequired = false,
                DisplayOrder = 4
            }
        );

        db.SaveChanges();
    }
}

app.Run();