using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IChipRepos
    {
        List<Chip> GetAllChip();
        List<Chip> GetChipByAll(string name);
        bool CreateChip(Chip chip);
        bool DeleteChip(int Id);
        bool UpdateChip(Chip chip);
    }
}
