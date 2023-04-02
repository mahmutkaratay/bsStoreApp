using Entities.Exceptions;
using System.Runtime.Serialization;

namespace Services
{
    [Serializable]
    public class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException()
            : base($"Invalid client request. The tokenDto has some invalid values")
        {
        }
    }
}