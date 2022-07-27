using System.Reflection;
using PhoneBook.WebApi.Definitions.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDefinitions(builder, typeof(Program));
var app = builder.Build();
app.UseDefinitions();
