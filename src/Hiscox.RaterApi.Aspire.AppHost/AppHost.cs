// Copyright (c) Hiscox Insurance. All rights reserved.

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hiscox_RaterApi_Presentation_Api>("hiscox-RaterApi-presentation-api");

builder.Build().Run();
