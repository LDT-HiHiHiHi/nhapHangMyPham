using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dal_tk = new DAL_TaiKhoan();

        public string getID_Name(string _id)
        {
            return dal_tk.getID_Name(_id);
        }
    }
}
