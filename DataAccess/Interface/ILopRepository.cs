using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ILopRepository
    {
        //List<Lop> GetLopHocs();
        List<Lop> Search(int page, int pageSize, string malop, string tenlop, out long total);
        Lop GetById(string id);
        bool Create(Lop model);
        bool Update(Lop model);
        bool Delete(List<string> ids);
    }
}