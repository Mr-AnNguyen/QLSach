using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public partial interface ILoaiRes
    {
        List<LoaiModel> GetAll();
        LoaiModel GetId(string Id);
        bool Create(LoaiModel model);
        bool Update(LoaiModel model);
        bool Delete(string Id);
    }
}
