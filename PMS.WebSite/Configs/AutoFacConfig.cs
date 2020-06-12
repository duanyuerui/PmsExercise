using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace PMS.WebSite.Configs
{
    /// <summary>
    /// AutoFac配置
    /// </summary>
    public class AutoFacConfig
    {
        /// <summary>
        /// 注入
        /// </summary>
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired(); //将所有Controller注入到MVC中

            //Assembly controllerAss = Assembly.Load("Wchl.WMBlog.WebUI");
            //builder.RegisterControllers(controllerAss);

            //告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            Assembly respAss = Assembly.Load("PMS.Repository");
            //创建respAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(respAss.GetTypes()).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope().PropertiesAutowired();
            ////或者统一全部注入
            //builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterfaces().PropertiesAutowired();

            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serpAss = Assembly.Load("PMS.Business");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(serpAss.GetTypes()).Where(x => x.Name.EndsWith("Business")).AsImplementedInterfaces().PropertiesAutowired();
            ////或者统一全部注入
            //builder.RegisterTypes(serpAss.GetTypes()).AsImplementedInterfaces().PropertiesAutowired();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //更改MVC的注入方式为AutoFac
        }
    }
}