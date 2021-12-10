using System;
using System.Linq;

namespace PetVet.Application.Common.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class SecretContentAttribute : Attribute
    {
    }

    public static class SecretContent
    {
        public static bool HasSecretContent(this object obj)
        {
            return obj.GetType().CustomAttributes.Any(x =>
                x.AttributeType == typeof(SecretContentAttribute));
        }
    }
}