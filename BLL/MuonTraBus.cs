using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class MuonTraBus: IMuonTraBus
    {
        private IMuonTraRes _muonTraRes;
        public MuonTraBus(IMuonTraRes muonTraRes)
        {
            _muonTraRes = muonTraRes;
        }
        public List<MuonModel> GetAll()
        {
            return _muonTraRes.GetAll();
        }
        public List<MuonModel> GetAllTra()
        {
            return _muonTraRes.GetAllTra();
        }
        public MuonModel GetID(int id)
        {
            return _muonTraRes.GetID(id);
        }
        public bool Muon(MuonModel model)
        {
            return _muonTraRes.Muon(model);
        }
        public bool Tra(MuonModel model)
        {
            return _muonTraRes.Tra(model);
        }
    }
}
