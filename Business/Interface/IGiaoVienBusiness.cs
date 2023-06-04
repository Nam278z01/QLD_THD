using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public interface IGiaoVienBusiness
    {
        List<GiaoVien> Search(int page, int pageSize, string magv, string tenmgv, out long total);
        GiaoVien GetById(string id);
        bool Create(GiaoVien model);
        bool Update(GiaoVien model);
        bool Delete(List<string> ids);
        //List<GiaoVien> GetGiaoViens();
    }
}
