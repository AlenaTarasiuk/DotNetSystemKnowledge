using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using DotNetSystemKnowledge.Domain.Entities;
using DotNetSystemKnowledge.Domain.Interfaces;
using Moq;
using DotNetSystemKnowledge.Domain.Concrete;

namespace DotNetSystemKnowledge.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<ITechnologyRepository>().To<TechnologyDbRipository>();
            ninjectKernel.Bind<IUserRepository>().To<UserDbRepository>();

        }
     
    }
}