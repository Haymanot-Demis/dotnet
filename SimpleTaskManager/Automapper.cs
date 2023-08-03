using Automapper;
class Automapper
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TaskDTO, Task>();
        });

        return config;
    }    
}