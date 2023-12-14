﻿using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IAnhRepos
    {
        List<Hinhanh> GetAllAnh();
        bool CreateAnh(Hinhanh anh);
        bool UpdateAnh(Hinhanh anh);
    }
}
