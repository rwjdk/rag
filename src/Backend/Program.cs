using Azure.AI.OpenAI;
using Datasource.YouTubeChannel;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ClientModel;
using Backend.Extensions;
using CommunityToolkit.VectorData.SqlServer;
using Microsoft.Extensions.VectorData;

FunctionsApplicationBuilder builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.Foo(builder.Configuration);

builder.Build().Run();
