using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IKhoiRepository
    {
        //List<Khoi> GetKhois();
        List<Khoi> Search(int page, int pageSize, string mamh, string tenmh, out long total);
        Khoi GetById(string id);
        bool Create(Khoi model);
        bool Update(Khoi model);
        bool Delete(List<string> ids);
    }
}
