using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Services;
using VolleyballManagementAppBackend;
using VolleyballManagementAppBackend.Interfaces;
using VolleyballManagementAppBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
);
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IUserService, UserService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
var app = builder.Build();

app.MapGet("/username", (HttpContext ctx) =>
{
    var authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth"));
    var payload = authCookie.Split("=").Last();
    var parts = payload.Split(":");
    var key = parts[0];
    var value = parts[1];
    return value;
});

app.MapGet("/login", (HttpContext ctx) =>
{
    ctx.Response.Headers["set-cookie"] = "auth=usr:betti";
    return "ok";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(o =>
                o.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());

app.MapControllers();

app.Run();
