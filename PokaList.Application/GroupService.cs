﻿using AutoMapper;
using PokaList.Application.Contracts;
using PokaList.Application.Dtos;
using PokaList.Domain;
using PokaList.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace PokaList.Application
{
    public class GroupService : IGroupService
    {
        private readonly IDefaultPersist _defaultPersist;
        private readonly IGroupPersist _groupPersist;
        private readonly IMapper _mapper;

        public GroupService(IDefaultPersist defaultPersist, IGroupPersist groupPersist, IMapper mapper)
        {
            _defaultPersist = defaultPersist;
            _groupPersist = groupPersist;
            _mapper = mapper;
        }
        public async Task<GroupDto> AddGroup(int userId, GroupDto model)
        {
            try
            {
                var group = _mapper.Map<Group>(model);
                group.UserId = userId;

                _defaultPersist.Add<Group>(group);

                if (await _defaultPersist.SaveChangesAsync())
                {
                    var result = await _groupPersist.GetGroupByIdAsync(userId, group.Id);
                    return _mapper.Map<GroupDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GroupDto> UpdateGroup(int userId, int groupId, GroupDto model)
        {
            try
            {
                var group = await _groupPersist.GetGroupByIdAsync(userId, groupId);
                if (group == null) return null;

                model.Id = group.Id;
                model.UserId = group.UserId;

                _mapper.Map(model, group);

                _defaultPersist.Update<Group>(group);

                if (await _defaultPersist.SaveChangesAsync())
                {
                    var result = await _groupPersist.GetGroupByIdAsync(userId, group.Id);
                    return _mapper.Map<GroupDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeleteGroup(int userId, int groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<GroupDto[]> GetAllGroupsAsync(int userId)
        {
            try
            {
                var groups = await _groupPersist.GetAllGroupsAsync(userId);
                if (groups == null) return null;

                var result = _mapper.Map<GroupDto[]>(groups);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GroupDto> GetGroupByIdAsync(int userId, int groupId)
        {
            try
            {
                var group = await _groupPersist.GetGroupByIdAsync(userId, groupId);
                if (group == null) return null;

                var result = _mapper.Map<GroupDto>(group);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
