using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Ongkon.Business;
using Ongkon.Business.CommandHandlers;
using Ongkon.Business.QueryHandlers;
using Ongkon.Contracts.Commands;
using Ongkon.Contracts.Interfaces;
using Ongkon.Contracts.Models;
using Ongkon.Database;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICommandHandler<CreateWhiteBoardCommand>, CreateWhiteBoardCommandHandler>();
builder.Services.AddTransient<ICommandHandler<AddElementCommand>, AddElementCommandHandler>();
builder.Services.AddTransient<ICommandHandler<AddNodeCommand>, AddNodeCommandHandler>();
builder.Services.AddTransient<ICommandHandler<AddNodeAnnotationCommand>, AddNodeAnnotationCommandHandler>();
builder.Services.AddTransient<ICommandHandler<AddConnectorCommand>, AddConnectorCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateSourcePointCommand>, UpdateSourcePointCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateNodePositionCommand>, UpdateNodePositionCommandHandler>();

builder.Services.AddTransient<IQueryHandler<WhiteBoard>, WhiteBoardQueryHandler>();
builder.Services.AddSingleton<IDbClient, MongoDbClient>();
builder.Services.AddTransient<IRepositoryContext, RepositoryContext>();
BsonClassMap.RegisterClassMap<WhiteBoard>();
var objectSerializer = new ObjectSerializer(type =>
{
    Console.WriteLine(type.FullName);
    return ObjectSerializer.DefaultAllowedTypes(type) || type.FullName.StartsWith("Ongkon.Contracts") ||
           type.FullName.StartsWith("MongoDB.Driver");
});
BsonSerializer.RegisterSerializer(objectSerializer);


builder.Services.AddCors(o => o.AddPolicy("AllowedOrigins", builder =>
{
    //TODO: For Prod environment we will allow only the configured cors
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowedOrigins");
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class Cors
{
    public string[] Origins { get; set; }
}
