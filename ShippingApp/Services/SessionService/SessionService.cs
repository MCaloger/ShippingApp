
using ShippingApp.Data;
using ShippingApp.Models;

namespace ShippingApp.Services
{
    public class SessionService
    {
        DataContext _dataContext;

        public SessionService(DataContext dataContext)
        {
            this._dataContext = dataContext;
            dataContext.Database.EnsureCreated();
        }

        /// <summary>
        /// Generate a uuid for session token
        /// </summary>
        /// <returns></returns>
        public string GenerateSessionToken()
        {
            string sessionToken = Guid.NewGuid().ToString();
            return sessionToken;
        }

        /// <summary>
        /// Create a session
        /// </summary>
        /// <param name="session"></param>
        public void CreateSession(SessionModel session)
        {
            session.Active = true;
            _dataContext.Sessions.Add(session);        
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Removes session
        /// </summary>
        /// <param name="session"></param>
        public void InvalidateSession(SessionModel session)
        {
            session.Active = false;
            _dataContext.Sessions.Update(session);
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Removes session by ID
        /// </summary>
        /// <param name="session"></param>
        public void InvalidateSession(long sessionId)
        {
            var session = _dataContext.Sessions.Where(sess => sess.SessionId == sessionId).FirstOrDefault();
            session.Active = false;
            _dataContext.Sessions.Update(session);
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Gets current user by session id
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns>User (nullable)</returns>
        public UserModel? GetCurrentUserBySessionToken(string sessionToken)
        {

            SessionModel? foundSession = _dataContext.Sessions.Where(sess => sess.SessionToken == sessionToken).FirstOrDefault();
            if(foundSession.Active)
            {
                _dataContext.Entry(foundSession).Reference(user => user.User).Load();
                return foundSession.User;
            }

            return null;
        }
    }
}
