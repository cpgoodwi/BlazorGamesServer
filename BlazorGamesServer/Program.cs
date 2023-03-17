// add namespace for Hubs (SignalR tutorial)
using Microsoft.AspNetCore.ResponseCompression;
using BlazorGamesServer.Hubs;

// add namespace for Data and program logic
using BlazorGamesServer.Data;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// add games as services?
builder.Services.AddSingleton<TicTacToeService>();

// add response compression middleware
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] {"application/octet-stream"});
});

var app = builder.Build();

app.UseResponseCompression(); // from SignalR tutorial

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

// including hub routes?
app.MapHub<ChatHub>("/chathub"); // from SignalR tutorial

app.MapFallbackToPage("/_Host");

app.Run();
