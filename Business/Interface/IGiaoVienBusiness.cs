﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public interface IGiaoVienBusiness
    {
        List<GiaoVien> GetGiaoViens();
    }
}
