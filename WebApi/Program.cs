using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Repositories;






var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>( x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CommentRepository>();






var app = builder.Build();




app.UseCors( x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
