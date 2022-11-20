using common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = MyProject.Repositories.Entities.Claim;

namespace Services.Interfaces
{
    public interface IClaimService
    {
        List<ClaimDTO> GetAll();
        ClaimDTO GetById(int Id);
        ClaimDTO Add(int id, int roleId, int premissionId, EPolicy policy);
        ClaimDTO Update(Claim c);
        void Delete(int id);
    }
}
