using System.Text;
using API.Extensions;
using Application.Common.Interface;
using Application.Service;
using Domain.Model;
using Infra;
using Infra.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

await app.SeedDatabaseAsync();
app.UseApplicationPipeline();

app.Run();