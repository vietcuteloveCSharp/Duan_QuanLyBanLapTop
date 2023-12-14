using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface iRespo<T,B,S,I,DCM,DT,K,O>
    {
        T GetOne(O o);
        List<T> GetAll();
        List<T> GetByBit(B b);
        List<T> GetByString(S name);
        List<T> GetByInt(I name,S key);
        List<T> GetByDecimal(DCM name);
        List<T> GetByDateTime(DT Tu,DT Den);
        bool Create(T t);
        bool Delete(K k);
        bool Update(T t);
    }
}
