using AutoMapper;
using System.Globalization;
public class AutomapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<dynamic, Task>();
        });

        return config;
    }    
}