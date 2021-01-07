using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
           var user = await _context.Users
           .Where(x => x.UserName == username)
           .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
           .SingleOrDefaultAsync();
           return _mapper.Map<MemberDto>(user);
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
           .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
           .ToListAsync();
        }

     
    }
}