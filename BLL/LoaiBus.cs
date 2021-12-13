using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class LoaiBus: ILoaiBus
    {
        private ILoaiRes _loaiRes;

        public LoaiBus (ILoaiRes loaiRes)
        {
            _loaiRes = loaiRes;
        }
        public List<LoaiModel> GetAll()
        {
            return _loaiRes.GetAll();
        }
        public LoaiModel GetId(string Id)
        {
            return _loaiRes.GetId(Id);
        }
        public bool Create(LoaiModel model)
        {
            return _loaiRes.Create(model);
        }
        public bool Update(LoaiModel model)
        {
            return _loaiRes.Update(model);
        }
        public bool Delete(string Id)
        {
            return _loaiRes.Delete(Id);
        }
    }
}
