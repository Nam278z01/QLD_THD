﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public interface ILopBusiness
    {
        List<Lop> GetLopHocs();
    }
}