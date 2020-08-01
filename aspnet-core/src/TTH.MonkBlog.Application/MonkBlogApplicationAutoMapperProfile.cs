using TTH.MonkBlog.Pastorals;
using TTH.MonkBlog.StudyHistories;
using TTH.MonkBlog.ReligousLives;
using System;
using TTH.MonkBlog.Shared;
using Volo.Abp.AutoMapper;
using TTH.MonkBlog.Monks;
using AutoMapper;

namespace TTH.MonkBlog
{
    public class MonkBlogApplicationAutoMapperProfile : Profile
    {
        public MonkBlogApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<MonkCreateDto, Monk>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<MonkUpdateDto, Monk>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Monk, MonkDto>();

            CreateMap<ReligousLifeCreateDto, ReligousLife>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<ReligousLifeUpdateDto, ReligousLife>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<ReligousLife, ReligousLifeDto>();

            CreateMap<StudyHistoryCreateDto, StudyHistory>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<StudyHistoryUpdateDto, StudyHistory>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<StudyHistory, StudyHistoryDto>();

            CreateMap<PastoralCreateDto, Pastoral>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<PastoralUpdateDto, Pastoral>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Pastoral, PastoralDto>();
        }
    }
}