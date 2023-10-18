using AutoMapper;
using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Account, AccountModels>().ReverseMap();
            CreateMap<Role, RoleModels>().ReverseMap();
            CreateMap<Patient, PatientModels>().ReverseMap();
            CreateMap<Schedule, ScheduleModels>().ReverseMap();
            CreateMap<Medicine, MedicineModels>().ReverseMap();
            CreateMap<Location, LocationModals>().ReverseMap();
            CreateMap<Nation, NationModels>().ReverseMap();
            CreateMap<TypeService, TypeServiceModels>().ReverseMap();
            CreateMap<EmployeeRole, EmployeeRoleModels>().ReverseMap();
            CreateMap<Certificate, CertificateModels>().ReverseMap();
            CreateMap<HospitalHealthInsurance, HospitalHealthInsuranceModels>().ReverseMap();
            CreateMap<Blog, BlogModels>().ReverseMap();
            CreateMap<Comment, CommentModels>().ReverseMap();
            CreateMap<Service, ServiceModels>().ReverseMap();
            CreateMap<Employee, EmpModels>().ReverseMap();
            CreateMap<MedicineBill, MedicineBillModels>().ReverseMap();
            CreateMap<Class, ClassesModel>().ReverseMap();
            CreateMap<Class, ClassesModellist>().ReverseMap();
        }
    }
}
