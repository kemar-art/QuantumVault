using AutoMapper;
using QuantumVault.Application.Features.Commands.BranchCommands.CreateBranch;
using QuantumVault.Application.Features.Commands.BranchCommands.UpdateBranch;
using QuantumVault.Application.Features.Queries.BranchesQuery.GetAllBranch;
using QuantumVault.Application.Features.Queries.BranchesQuery.GetBranch;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchDTO>().ReverseMap();
            CreateMap<Branch, AllBranchDTO>().ReverseMap();
            CreateMap<Branch, CreateBranchCommand>().ReverseMap();
            CreateMap<Branch, UpdateBranchCommand>().ReverseMap();
        }
    }
}
