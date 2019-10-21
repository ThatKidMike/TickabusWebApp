using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.Repositories;

namespace TickabusWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(Guid id)
        {
            var user = await _userRepo.GetUser(id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
