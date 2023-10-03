using API.Dtos;
using Domain;
using AutoMapper;

namespace API.Profiles;

    public class MappingPofiles : Profile
    {
      public MappingPofiles(){


      //Define un mapeo unidireccional desde la clase User a 
      //.ReverseMap(): Habilita el mapeo en ambas direcciones, es decir, de User a UserDto y viceversa. Esto permite la conversión en ambas direcciones sin necesidad de configuraciones adicionales.
       CreateMap<User, UserDto>().ReverseMap();

      }
    }
