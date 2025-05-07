using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaDeComentariosBackend.Repository;
using SistemaDeComentariosBackend.Services;

var builder = WebApplication.CreateBuilder(args);
var MyCors = "MyCors";
// Add services to the container.

//Login Sistem



//Services
builder.Services.AddTransient<IUsersServices, UsersServices>();
builder.Services.AddScoped<ICommentsServices, CommentsServices>();
builder.Services.AddScoped<IImagesServices, ImagesServices>();


//Repositories
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();



// DBContext
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

//Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

//Area de Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

//Se crea un metodo asyncrono, recibe dos variables la primera es el controlador y la segunda una para invocar el siguiente middleware
app.Use(async (contexto, next) =>
{
    //Viene la peticion
    var logger = contexto.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation($"Peticion: {contexto.Request.Method} {contexto.Request.Path}");

    await next.Invoke();

    //se va la respuesta

    logger.LogInformation($"Respuesta: {contexto.Response.StatusCode}");
});

//Cors
app.UseCors(MyCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
