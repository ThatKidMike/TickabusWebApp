﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;

namespace TickabusWebApp.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDTO>();
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Track, TrackDTO>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<CityModifiedDTO, City>();
                cfg.CreateMap<TrackAddDTO, Track>();
                cfg.CreateMap<Track, TrackAdminViewDTO>();
                cfg.CreateMap<TrackAdminViewDTO, Track>();
                cfg.CreateMap<TrackToModifyDTO, Track>();
            })
            .CreateMapper();
    }
}
