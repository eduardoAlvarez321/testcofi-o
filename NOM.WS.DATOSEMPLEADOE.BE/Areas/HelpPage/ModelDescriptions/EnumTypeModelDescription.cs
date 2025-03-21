using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NOM.WS.DATOSEMPLEADOE.BE.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}