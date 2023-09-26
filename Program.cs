using DataLibrary.DataAccess;
using DataLibrary.DataAccess.Interfaces;
using DataLibrary.Model;
using DataLibrary.SqlHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration["ConnectionStringQA:QA_Context"]
builder.Services.AddSingleton<ISqlHelper>(new SqlHelper(Environment.GetEnvironmentVariable("appConnection")));
builder.Services.AddTransient<IQuccContext, QuccContext>();
builder.Services.AddTransient<ICarDataAccess, CarDataAccess>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



