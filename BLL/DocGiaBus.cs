using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class DocGiaBus: IDocGiaBus
    {
        private IDocGiaRes _docGiaRes;
        public DocGiaBus(IDocGiaRes docGiaRes)
        {
            _docGiaRes = docGiaRes;
        }
        public List<DocGiaModel> GetAll()
        {
            return _docGiaRes.GetAll();
        }
        public DocGiaModel GetID(int id)
        {
            return _docGiaRes.GetID(id);
        }
        public bool Create(DocGiaModel model)
        {
            return _docGiaRes.Create(model);
        }
        public bool Update(DocGiaModel model)
        {
            return _docGiaRes.Update(model);
        }
        public bool Delete(string id)
        {
            return _docGiaRes.Delete(id);
        }
    }
}
