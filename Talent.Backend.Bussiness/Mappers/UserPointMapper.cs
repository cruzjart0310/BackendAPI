using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class UserPointMapper
    {
        public static Talent.Backend.Bussiness.Models.UserPointResponse<User> Map(DataAccessEF.Models.UserPointResponse<DataAccessEF.Entities.User> userPointResponse)
        {
            return new Talent.Backend.Bussiness.Models.UserPointResponse<User>
            {
                Element = new User
                {
                    Id = userPointResponse.Element.Id,
                    FirstName = userPointResponse.Element.FirstName,
                    LastName = userPointResponse.Element.LastName,
                },
                Points = userPointResponse.Points,
            };
        }

    }
}
