using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Firma.Dtos.Api;
using Firma.Models.Entities;
using Firma.Models.Values;
using Firma.Models.Values.Legal;
using Firma.Models.Values.TaxationModel;

namespace Firma
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cnae, CnaeDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<LegalNature, LegalNatureDto>();
            CreateMap<TaxRegime, TaxRegimeDto>();
            CreateMap<Qualification, QualificationDto>();
            CreateMap<Mei, MeiDto>();
            CreateMap<Simples, SimplesDto>();
            CreateMap<Lucro, LucroDto>();
        }
    }
}