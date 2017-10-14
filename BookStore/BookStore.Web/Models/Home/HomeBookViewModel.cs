using BookStore.Data.Model;
using BookStore.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;

namespace BookStore.Web.Models.Home
{
    public class HomeBookViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public Decimal Price { get; set; }

        public string BookImageUrl { get; set; }

        public string CategoryName { get; set; }

        public string OwnerUsername { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, HomeBookViewModel>()
                .ForMember(x => x.OwnerUsername, cfg => cfg.MapFrom(y => y.Owner.UserName))
                .ForMember(x => x.CategoryName, cfg => cfg.MapFrom(y => y.Category.Name));
        }
    }
}