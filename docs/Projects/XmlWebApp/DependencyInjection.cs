using AutoMapper;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        // services.AddControllers();
        // services.AddAutoMapper(typeof(MappingProfile));
        // services.AddAutoMapper(typeof(EmailQueueMappingProfile));
        // services.AddAutoMapper(typeof(XmlDataMappingProfile));
        // services.AddSingleton<XmlReaderService>();
        // services.AddSingleton<EmailQueueMappingProfile>(); // Voeg het mappingprofiel toe

        // // Maak de mapper aan en configureer het mappingprofiel
        // // services.AddSingleton(provider =>
        // // {
        // //     var config = new MapperConfiguration(cfg =>
        // //     {
        // //         cfg.AddProfile<MappingProfile>();
        // //         cfg.AddProfile<EmailQueueMappingProfile>(provider.GetService<EmailQueueMappingProfile>());
        // //     });
        // //     return config.CreateMapper();
        // // });

        // return services;

        services.AddControllers();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddSingleton<XmlReaderService>();

        return services;
    }
}
