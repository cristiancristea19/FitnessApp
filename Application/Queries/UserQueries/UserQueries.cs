using Application.Common;
using Application.Models.AuthenticationModels;
using System;
using System.Collections.Generic;

namespace Application.Queries.UserQueries
{
    public class GetUserDetailsQuery : BaseRequest<GetUserDetailsQueryResponse>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserDetailsQueryResponse
    {
        public UserModel User { get; set; }
    }

    public class GetUsersQuery : BaseRequest<GetUsersQueryResponse>
    {
    }

    public class GetUsersQueryResponse
    {
        public List<UserModel> Users { get; set; }
    }
}