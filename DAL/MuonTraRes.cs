using DAL.Connect;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class MuonTraRes: IMuonTraRes
    {
        private IDBContext _dBContext;
        public MuonTraRes(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public List<MuonModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dBContext.ExecuteSProcedureReturnDataTable(out msgError, "Muon_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MuonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MuonModel> GetAllTra()
        {
            string msgError = "";
            try
            {
                var dt = _dBContext.ExecuteSProcedureReturnDataTable(out msgError, "Tra_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MuonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MuonModel GetID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dBContext.ExecuteSProcedureReturnDataTable(out msgError, "Muon_get_id",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MuonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Muon(MuonModel model)
        {
            string msgError = "";
            try
            {
                var result = _dBContext.ExecuteScalarSProcedureWithTransaction(out msgError, "Muon",
                    "@MaMuonTra", model.MaMuonTra,
                    "@MaSach", model.MaSach,
                    "@MaDocGia", model.MaDocGia,
                    "@TienCoc", model.TienCoc,
                    "@SoLuong", model.SoLuong);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Tra(MuonModel model) 
        {
            string msgError = "";
            try
            {
                var result = _dBContext.ExecuteScalarSProcedureWithTransaction(out msgError, "Tra",
                    "@MaMuonTra", model.MaMuonTra);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
