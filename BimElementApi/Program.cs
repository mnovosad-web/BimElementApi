using System.Reflection;
using BimElementApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();              
builder.Services.AddEndpointsApiExplorer();     
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<ElementStore>();  

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();   

app.MapControllers();     

app.Run();