using BLL.IServices;
using DAL.IRepo;
using DAL.Model;
using DAL.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public class ConstraintsService : IConstraintsService
    {
        private IConstraintsRepo _constraintsRepo;

        public ConstraintsService()
        {
            _constraintsRepo = new ConstraintsRepo();
        }
        public bool UpdateConstraint(Constraints constraint)
        {
            _constraintsRepo.UpdateConstraint(constraint);
            return true;
        }

        public bool UpdateConstraint(string constraintname, string constraintvalue)
        {
            Constraints constraints = new Constraints()
            {
                ConstraintID = GetConstraintID(constraintname),
                ConstraintName = constraintname,
                ConstraintValue = constraintvalue
            };
            _constraintsRepo.UpdateConstraint(constraints);
            return true;
        }
        public string GetConstraintValue(string name)
        {
            return _constraintsRepo.GetConstraintValue(name);

        }

        public int GetConstraintID(string name)
        {
            return _constraintsRepo.GetConstraintID(name);
        }

    }


}
