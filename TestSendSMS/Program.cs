using Twilio;
using Twilio.Rest.Api.V2010.Account;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//string accountSid = Environment.GetEnvironmentVariable("AC59314e427d14ebd0e6c07d774374cfc1");
//string authToken = Environment.GetEnvironmentVariable("1bf2e64aefefecb1ecff5ca86edacfcb");

//TwilioClient.Init(accountSid, authToken);

//var message = MessageResource.Create(
//    body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
//    from: new Twilio.Types.PhoneNumber("+17623004628"),
//    to: new Twilio.Types.PhoneNumber("+8562098814513")
//);

//Console.WriteLine(message.Sid);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
