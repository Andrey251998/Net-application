using Ninject.Modules;
using spaceBLL.Interfaces;
using spaceBLL.Services;

namespace Space_App_ASP_MVC.Util
{
    public class UserModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<UserService>();
        }
    }
}
