using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IHangRepos
    {
        List<Hang> GetAllHang();
        List<Hang> GetHangByAll(string name);
        bool CreateHang(Hang hang);
        bool DeleteHang(int Id);
        bool UpdateHang(Hang hang);

    }
}
