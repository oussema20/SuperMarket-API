using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Supermarket.Domain.Models
{
    public enum EUnitOfMeasurement
    {

        [Description("UN")]
        Unity = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        Gram = 3,

        [Description("KG")]
        Kilogram = 4,

        [Description("L")]
        Liter = 5
    }
}
