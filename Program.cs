using Blogs_Api_DotNet.Extensions;
using Blogs_Api_DotNet.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddValidators();
builder.Services.AddServices();
builder.Services.AddAutenticacao(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwt();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorMiddleware));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
