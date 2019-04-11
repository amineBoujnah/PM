//using AutoMapper;
//using Domain.Entities;
//using Web.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;



//namespace Web.ProfileAM
//{
//    public class AutoMapperWebProfile : Profile
//    {
//        public AutoMapperWebProfile()
//        {
//            //Domain to View
//            CreateMap<adherent, AdherentPhysiqueVM>();
//            //View to Domain
//            CreateMap<AdherentPhysiqueVM, adherent>();

//            //Domain to View
//            CreateMap<adherent, AdherentMoraleVM>();
//            //View to Domain
//            CreateMap<AdherentMoraleVM, adherent>();
//            //Domain to View
//            CreateMap<declaration, DecLiteratureVM>();

//            //View to Domain
//            CreateMap<DecLiteratureVM, declaration>();
//            //Domain to View
//            CreateMap<declaration, DecArtistiqueVM>();
//            //View to Domain
//            CreateMap<DecArtistiqueVM, declaration>();

//            //Domain to View
//            CreateMap<declaration, DecTheatreVM>();
//            //View to Domain
//            CreateMap<DecTheatreVM, declaration>();


//            //Domain to View
//            CreateMap<declaration, DecMusiqueVM>();
//            //View to Domain
//            CreateMap<DecMusiqueVM, declaration>();








//        }


//        public static void Run()
//        {
//            AutoMapper.Mapper.Initialize(a => { a.AddProfile<AutoMapperWebProfile>(); });
//        }




//    }
//}
