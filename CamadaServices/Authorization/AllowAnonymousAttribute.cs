using System;

namespace Teste.NET.CamadaServices.Authorization
{


    [AttributeUsage(AttributeTargets.Method)]

    public class AllowAnonymousAttribute : Attribute
    {
    }
}
