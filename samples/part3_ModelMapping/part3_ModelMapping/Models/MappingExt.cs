namespace part3_ModelMapping.Models {
    using AutoMapper;

    public static class MappingExt {
        static MappingExt() {
            Mapper.CreateMap<Person, PersonViewModel>();
        }
        public static PersonViewModel ToViewModel(this Person person) {
            return Mapper.Map<Person, PersonViewModel>(person);
        }
    }
}