using AutoMapper;
using Domain.Clients;

namespace Application.Clients
{
    // Clase que define un perfil de AutoMapper para mapear objetos entre clases de dominio y clases de aplicación
    public class ClientProfile : Profile
    {
        // Constructor de la clase ClientProfile
        public ClientProfile()
        {
            // Definición de mapeo entre CreateClient y Client
            CreateMap<CreateClient, Client>()

                // Se especifica que el campo PhoneNumber de Client se asignará desde el campo MobileNumber de CreateClient
                .ForMember(destination => destination.PhoneNumber,
                    source => source.MapFrom(s => s.MobileNumber));

            // Definición de mapeo entre UpdateClient y Client
            CreateMap<UpdateClient, Client>()
                // Se indica que el campo Id de Client será ignorado durante el mapeo
                .ForMember(destination => destination.Id, source => source.Ignore());
        }
    }
}
