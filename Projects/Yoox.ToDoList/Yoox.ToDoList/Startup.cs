using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yoox.ToDoList.Startup))]
namespace Yoox.ToDoList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
