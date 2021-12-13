using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL
{
    public partial interface IMuonTraBus
    {
        List<MuonModel> GetAll();
        MuonModel GetID(int id);
        bool Muon(MuonModel model);
        bool Tra(MuonModel model);
        List<MuonModel> GetAllTra();
    }
}
