﻿global using Dapr;
global using Dapr.Client;
global using Dapr.Extensions.Configuration;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Ecmanage.eProcessor.BuildingBlocks.EventBus;
global using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
global using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
global using Ecmanage.eProcessor.Services.FakeFetch.API;
global using Ecmanage.eProcessor.Services.FakeFetch.API.Infrastructure;
global using Ecmanage.eProcessor.Services.FakeFetch.API.Repositories;
global using Ecmanage.eProcessor.Services.FakeFetch.API.Services;
global using Ecmanage.eProcessor.Services.FakeFetch.API.Infrastructure.EntityConfigurations;
global using Ecmanage.eProcessor.Services.FakeFetch.API.Model;
global using Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates;
global using Ecmanage.eProcessor.Services.FakeFetch.API.ViewModel;
global using Ecmanage.eProcessor.Services.FakeFetch.API.ViewModel.EmailTemplates;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Microsoft.OpenApi.Models;
global using Polly;
global using System.Net;