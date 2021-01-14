using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MyNotePad.Business.Abstract;
using MyNotePad.Business.Concrete;
using MyNotePad.DataAccess.Abstract;
using MyNotePad.DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace MyNotePad.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfNoteDal>().As<INoteDal>();
            builder.RegisterType<NoteManager>().As<INoteService>();

            builder.RegisterAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
