﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataClassPluginInterfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetRepositories();
    }
}
