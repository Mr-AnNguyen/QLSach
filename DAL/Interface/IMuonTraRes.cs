using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial interface IMuonTraRes
    {
        List<MuonModel> GetAll();
        MuonModel GetID(int id);
        bool Muon(MuonModel model);
        bool Tra(MuonModel model);
        List<MuonModel> GetAllTra();

    }
}
