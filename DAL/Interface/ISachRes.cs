using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial interface ISachRes
    {
        List<SachModel> GetAll();
        SachModel GetID(int id);
        bool Create(SachModel model);
        bool Update(SachModel model);
        bool Delete(string id);
    }
}
