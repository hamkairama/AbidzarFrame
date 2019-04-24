using AutoMapper;

namespace AbidzarFrame.Web
{
    public class CustomAutoMapperConfiguration
    {

        public static void PopulateMapperConfig()
        {
            Mapper.Initialize(cfg =>
            {
            });
        }
    }
}