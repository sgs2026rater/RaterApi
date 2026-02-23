// Copyright (c) Hiscox Insurance. All rights reserved.

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hiscox_RaterApiWrapper_Presentation_Api>("hiscox-RaterApiWrapper-presentation-api");

builder.Build().Run();
