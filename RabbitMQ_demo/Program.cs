using Microsoft.EntityFrameworkCore;
using RabbitMQ_demo.Data;
using RabbitMQ_demo.RabbitMQ;
using RabbitMQ_demo.Service;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<ApplicationDBContext>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"))


        );
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