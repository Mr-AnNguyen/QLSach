using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Connect;
using Models;

namespace DAL
{
    public partial class DocGiaRes: IDocGiaRes
    { 
        private IDBContext _dbContext;
        public DocGiaRes(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<DocGiaModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbContext.ExecuteSProcedureReturnDataTable(out msgError, "DocGia_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DocGiaModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DocGiaModel GetID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbContext.ExecuteSProcedureReturnDataTable(out msgError, "DocGia_get_id",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DocGiaModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DocGiaModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbContext.ExecuteScalarSProcedureWithTransaction(out msgError, "Docgia_create",
                "@MaDocGia", model.MaDocGia,
                "@TenDocGia", model.TenDocGia,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
                "@CCCD", model.CCCD,
                "@GioiTinh", model.GioiTinh,
                "@NgaySinh", model.NgaySinh);
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

        public bool Update(DocGiaModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbContext.ExecuteScalarSProcedureWithTransaction(out msgError, "DocGia_update",
                "@MaDocGia", model.MaDocGia,
                "@TenDocGia", model.TenDocGia,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
                "@CCCD", model.CCCD,
                "@GioiTinh", model.GioiTinh,
                "@NgaySinh", model.NgaySinh);
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
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbContext.ExecuteScalarSProcedureWithTransaction(out msgError, "DocGia_delete",
                "@Id", id);
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
