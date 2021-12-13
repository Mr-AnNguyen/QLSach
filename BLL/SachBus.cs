using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class SachBus: ISachBus
    {
        private ISachRes _sachRes;
        public SachBus(ISachRes res)
        {
            _sachRes = res;
        }
        public List<SachModel> GetAll()
        {
            return _sachRes.GetAll();
        }
        public SachModel GetID(int id)
        {
            return _sachRes.GetID(id);
        }
        public bool Create(SachModel model)
        {
            return _sachRes.Create(model);
        }
        public bool Update(SachModel model)
        {
            return _sachRes.Update(model);
        }
        public bool Delete(string id)
        {
            return _sachRes.Delete(id);
        }
    }
}
