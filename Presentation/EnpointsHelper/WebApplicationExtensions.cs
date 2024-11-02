﻿using System.Reflection;
using Microsoft.AspNetCore.OpenApi;
namespace APIs.EnpointsHelper;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
    {
        var groupName = group.GetType().Name; //class name that inherits endpointgroupbase

        return app
            .MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi()
        ; //create routing for the whole class
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase); //get groupbase type

        var assembly = Assembly.GetExecutingAssembly(); //get assembly group base

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType)); //get all classes that inherit group base

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        } //map every class endpoints (methods)

        return app;
    }
}