
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
        public string GenerateSessionToken()
        {
            string sessionToken = Guid.NewGuid().ToString();
            return sessionToken;
        }

        public void CreateSession(SessionModel session)
        {
            session.Active = true;
            _dataContext.Sessions.Add(session);        
            _dataContext.SaveChanges();
        }

        public void InvalidateSession(SessionModel session)
        {
            session.Active = false;
            _dataContext.Sessions.Update(session);
            _dataContext.SaveChanges();
        }

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
