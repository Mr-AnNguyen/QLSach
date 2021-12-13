using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Connect;
using Models;

namespace DAL
{
    public partial class LoaiRes: ILoaiRes
    {
        private IDBContext _dBContext;
        public LoaiRes(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public List<LoaiModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dBContext.ExecuteSProcedureReturnDataTable(out msgError, "LoaiSach_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LoaiModel GetId(string Id)
        {
            string msgError = "";
            try
            {
                var dt = _dBContext.ExecuteSProcedureReturnDataTable(out msgError, "LoaiSach_get_id",
                    "@Id", Id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(LoaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dBContext.ExecuteScalarSProcedureWithTransaction(out msgError, "LoaiSach_create",
                    "@TenLoai", model.TenLoai);
                if((result != null && !string.IsNullOrEmpty(result.ToString()))||(!string.IsNullOrEmpty(msgError)))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }catch( Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(LoaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dBContext.ExecuteScalarSProcedureWithTransaction(out msgError, "LoaiSach_update",
                    "@MaLoai", model.MaLoai,
                    "@TenLoai", model.TenLoai);
                if((result !=null && !string.IsNullOrEmpty(result.ToString())) || (!string.IsNullOrEmpty(msgError)))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch( Exception ex) {
                throw ex;
            }
        }
        public bool Delete(string Id)
        {
            string msgError = "";
            try
            {
                var result = _dBContext.ExecuteScalarSProcedureWithTransaction(out msgError, "LoaiSach_delete",
                    "@Id", Id);
                if((result != null && !string.IsNullOrEmpty(result.ToString())) || (!string.IsNullOrEmpty(msgError)))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }
    }
}
