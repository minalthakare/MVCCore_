namespace CRUDUsingEFCoreCodeFirstApproach.Profiles
{
    using AutoMapper;
    using CRUDUsingEFCoreCodeFirstApproach.Models;
    using CRUDUsingEFCoreCodeFirstApproach.Models.Entities;

    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>().ReverseMap();

            //CreateMap<UserViewModel, User>().ForMember("Name", options =>
            //{
            //    options.MapFrom("ProductName");
            //}).ForMember("Rating", options =>
            //{
            //options.MapFrom("ProductRating");
            //}).ReverseMap();
        }
    }
}
