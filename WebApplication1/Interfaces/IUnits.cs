﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUnits
    {
        Response AddUnitsDetails(Units addUnits);
        Response GetAllUnits();
        Response GetUnitsByUnitId(string unitId);

    }
}