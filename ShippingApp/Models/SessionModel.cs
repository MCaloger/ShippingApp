

using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ShippingApp.Models
{
    public class SessionModel
    {
        [Key]
        public long SessionId { get; set; }
        public virtual UserModel User { get; set; }
        public string SessionToken { get; set; }
        public bool Active { get; set; }

        private ILazyLoader LazyLoader { get; set; }

        protected SessionModel()
        {

        }

        public SessionModel(long sessionId, UserModel user, string sessionToken, bool active)
        {
            SessionId = sessionId;
            User = user;
            SessionToken = sessionToken;
            Active = active;
        }

        public SessionModel(UserModel user, string sessionToken, bool active)
        {
            User = user;
            SessionToken = sessionToken;
            Active = active;
        }
    }
}
