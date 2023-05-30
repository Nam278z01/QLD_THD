using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ILoaiDiemRepository
    {
        //List<LoaiDiem> GetLoaiDiems();
        List<LoaiDiem> Search(int page, int pageSize, string mamh, string tenmh, out long total);
        LoaiDiem GetById(string id);
        bool Create(LoaiDiem model);
        bool Update(LoaiDiem model);
        bool Delete(List<string> ids);
    }
}
