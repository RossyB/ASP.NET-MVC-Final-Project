using System;
using AutoMapper;
using BookStore.Data.Model;
using BookStore.Web.Infrastructure;

namespace BookStore.Web.Models.Comments
{
    public class CommentViewModel: IMapFrom<Comment>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.AuthorName, cfg => cfg.MapFrom(y => y.User.UserName));
        }
    }
}