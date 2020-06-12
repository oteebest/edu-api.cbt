using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Interface.IRepository
{
    public interface ISeederRepoistory
    {
        Task Seed();
    }
}
