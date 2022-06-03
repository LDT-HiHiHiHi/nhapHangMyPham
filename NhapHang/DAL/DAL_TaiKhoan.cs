using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_TaiKhoan
    {
        QlyMyPhamDataContext qlmp = new QlyMyPhamDataContext();

        public string getID_Name(string _id)
        {
            return qlmp.TAIKHOANs.Where(tk => tk.USERNAME == _id).Select(t => t.ID).FirstOrDefault();
        }
    }
}
