//using chatAppWebApi.Services;
//using chatAppWebApi.SignalR;
//using System.Security.Cryptography.X509Certificates;

//namespace chatAppWebApi
//{
//    public static class Api
//    {
//        public static void ConfigureApi(this WebApplication app)
//        {
//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapHub<ChatHub>("/chatHub");

//                endpoints.MapPost("/api/messages", CreateMessage);
//            });

//            static async  
//        }
//    }

//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapHub<ChatHub>("/chatHub");

//    endpoints.MapPost("/api/messages", async(IChatroomService chatRoom, string username, string message) =>
//    {
//        var response = await chatRoom.CreateMessage(username, message);
//        return Results.Ok(response);
//    });

//endpoints.MapGet("/api/messages", async (IChatroomService chatRoom) =>
//{
//    var response = await chatRoom.GetAllMessages();
//    return Results.Ok(response);
//});

//endpoints.MapGet("/api/users", async (IChatroomService chatRoom) =>
//{
//    var response = await chatRoom.GetAllUsers();
//    return Results.Ok(response);
//});

//endpoints.MapPost("/api/users", async (IChatroomService chatRoom, string username) =>
//{
//    var response = await chatRoom.CreateUser(username);
//    return Results.Ok(response);
//});

//endpoints.MapGet("/api/users/{id}", async (IChatroomService chatRoom, int id) =>
//{
//    var response = await chatRoom.GetUser(id);
//    return Results.Ok(response);
//});

//endpoints.MapFallback(async context =>
//{
//    context.Response.ContentType = "text/html";
//    await context.Response.SendFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"));
//});
//});
//    }
//}

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<ChatHub>("/chatHub");

//    endpoints.MapPost("/api/messages", async(IChatroomService chatRoom, string username, string message) =>
//    {
//        var response = await chatRoom.CreateMessage(username, message);
//        return Results.Ok(response);
//    });

//    endpoints.MapGet("/api/messages", async(IChatroomService chatRoom) =>
//    {
//        var response = await chatRoom.GetAllMessages();
//        return Results.Ok(response);
//    });

//endpoints.MapGet("/api/users", async (IChatroomService chatRoom) =>
//{
//    var response = await chatRoom.GetAllUsers();
//    return Results.Ok(response);
//});

//endpoints.MapPost("/api/users", async (IChatroomService chatRoom, string username) =>
//{
//    var response = await chatRoom.CreateUser(username);
//    return Results.Ok(response);
//});

//endpoints.MapGet("/api/users/{id}", async (IChatroomService chatRoom, int id) =>
//{
//    var response = await chatRoom.GetUser(id);
//    return Results.Ok(response);
//});

//endpoints.MapFallback(async context =>
//{
//    context.Response.ContentType = "text/html";
//    await context.Response.SendFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"));
//});
//});
//    }
//}
