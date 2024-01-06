using Ninject.Modules;
using spaceBLL.Interfaces;
using spaceBLL.Services;

namespace Space_App_ASP_MVC.Util
{
    public class ClientModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IClient>().To<ClientService>();

        }
    }
}
