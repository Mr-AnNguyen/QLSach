using DAL.Connect;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class SachRes: ISachRes
    {
        private IDBContext _dbContext;
        public SachRes(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SachModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbContext.ExecuteSProcedureReturnDataTable(out msgError, "Sach_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SachModel GetID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbContext.ExecuteSProcedureReturnDataTable(out msgError, "Sach_get_id",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SachModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(SachModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbContext.ExecuteScalarSProcedureWithTransaction(out msgError, "Sach_create",
                "@MaSach", model.MaSach,
                "@MaLoai", model.MaLoai,
                "@TenSach", model.TenSach,
                "@TacGia", model.TacGia,
                "@NhaXB", model.NhaXB,
                "@NamXB", model.NamXB,
                "@SoLuong", model.SoLuong,
                "@Gia", model.Gia);
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

        public bool Update(SachModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbContext.ExecuteScalarSProcedureWithTransaction(out msgError, "Sach_update",
                "@MaSach", model.MaSach,
                "@MaLoai", model.MaLoai,
                "@TenSach", model.TenSach,
                "@TacGia", model.TacGia,
                "@NhaXB", model.NhaXB,
                "@NamXB", model.NamXB,
                "@SoLuong", model.SoLuong,
                "@Gia", model.Gia);
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
                var result = _dbContext.ExecuteScalarSProcedureWithTransaction(out msgError, "Sach_delete",
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
