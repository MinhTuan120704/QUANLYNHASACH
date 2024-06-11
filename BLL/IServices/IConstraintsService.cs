using DAL.IRepo;
using DAL.Repo;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    internal interface IConstraintsService
    {

        bool UpdateConstraint(Constraints constraint);
        string GetConstraintValue(string name);

        int GetConstraintID(string name);
        bool UpdateConstraint(string constraintname, string constraintvalue);

    }
}
