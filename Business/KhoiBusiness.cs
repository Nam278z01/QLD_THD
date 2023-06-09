﻿using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class KhoiBusiness : IKhoiBusiness
    {
        IKhoiRepository _res;
        public KhoiBusiness(IKhoiRepository res) 
        {
            _res = res;
        }

        //public List<Khoi> GetKhoiHocs()
        //{
        //    return _res.GetKhoiHocs();
        //}
        public List<Khoi> Search(int page, int pageSize, string makhoi, string tenkhoi, out long total)
        {
            return _res.Search(page, pageSize, makhoi, tenkhoi, out total);
        }
        public Khoi GetById(string id)
        {
            return _res.GetById(id);
        }
        public bool Create(Khoi model)
        {
            return _res.Create(model);
        }
        public bool Update(Khoi model)
        {
            return _res.Update(model);
        }
        public bool Delete(List<string> ids)
        {
            return _res.Delete(ids);
        }
    }
}
