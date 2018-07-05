using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Persons3.Models;

namespace Persons3.API
{
    public interface IPersonHandler
    {

        Task<List<Person>> LoadPersonsAsync();

    }
}
