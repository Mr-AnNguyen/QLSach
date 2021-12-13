using System.Collections.Generic;
using Models;

namespace BLL
{
    public partial interface ILoaiBus
    {
        List<LoaiModel> GetAll();
        LoaiModel GetId(string Id);
        bool Create(LoaiModel model);
        bool Update(LoaiModel model);
        bool Delete(string Id);
    }
}
