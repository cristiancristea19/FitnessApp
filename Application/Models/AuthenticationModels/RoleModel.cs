using Domain.Entities;

namespace Application.Models.AuthenticationModels
{
    public class RoleModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public RoleTypeEnum? RoleType { get; set; }
    }

    public class RegisterRoleModel
    {
        public RoleTypeEnum? RoleType { get; set; }
    }
}