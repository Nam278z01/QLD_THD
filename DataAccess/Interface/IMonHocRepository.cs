using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IMonHocRepository
    {
        List<MonHoc> Search(int page, int pageSize, string mamh, string tenmh, out long total);
        MonHoc GetById(string id);
        bool Create(MonHoc model);
        bool Update(MonHoc model);
        bool Delete(List<string> ids);
    }
}
