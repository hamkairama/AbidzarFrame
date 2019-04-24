using StructureMap;

namespace AbidzarFrame.Mvc.Infrastructures.DI
{
    public static class IoC
    {
        public static IContainer Container { get; set; }

        static IoC()
        {
            Container = new Container();
        }
    }
}
