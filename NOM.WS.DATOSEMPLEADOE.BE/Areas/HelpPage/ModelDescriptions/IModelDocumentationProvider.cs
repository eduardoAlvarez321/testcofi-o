using System;
using System.Reflection;

namespace NOM.WS.DATOSEMPLEADOE.BE.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}