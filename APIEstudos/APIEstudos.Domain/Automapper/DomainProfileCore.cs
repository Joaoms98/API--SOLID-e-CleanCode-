﻿using AutoMapper;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Core.Models;

namespace APIEstudos.Domain.Automapper
{
    public class DomainProfileCore : Profile
    {
        public DomainProfileCore()
        {
            ClienteMap();
        }

        private void ClienteMap()
        {
            CreateMap<CreateUserRequest, UserModel>();
            CreateMap<UpdateUserRequest, UserModel>();
            CreateMap<DeleteUserRequest, UserModel>();
            CreateMap<UserModel, UserResponse>();
        }
    }
}
