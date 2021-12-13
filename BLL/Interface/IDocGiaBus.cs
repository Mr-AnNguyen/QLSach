using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial interface IDocGiaBus
    {
        List<DocGiaModel> GetAll();
        DocGiaModel GetID(int id);
        bool Create(DocGiaModel model);
        bool Update(DocGiaModel model);
        bool Delete(string id);
    }
}
