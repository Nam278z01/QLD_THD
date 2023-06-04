using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public interface IHocSinhBusiness
    {
        //List<HocSinh> GetHocSinhs();
        List<HocSinh> Search(int page, int pageSize, string mamh, string tenmh, out long total);
        HocSinh GetById(string id);
        bool Create(HocSinh model);
        bool Update(HocSinh model);
        bool Delete(List<string> ids);
    }
}
