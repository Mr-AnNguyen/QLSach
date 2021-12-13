using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial interface ISachBus
    {
        List<SachModel> GetAll(); 
        SachModel GetID(int id);
        bool Create(SachModel model);
        bool Update(SachModel model);
        bool Delete(string id);
    }
}
