using ShippingApp.Data;
using ShippingApp.Models;

namespace ShippingApp.Services
{
    public class RequestService
    {
        DataContext _dataContext;

        public RequestService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateRequest(UserModel user, RequestModel request)
        {
            RequestModel constructedRequest = new RequestModel();

            constructedRequest.Details = request.Details;
            constructedRequest.Requestor = user;

            _dataContext.Requests.Add(constructedRequest);
            _dataContext.SaveChanges();
            
        }

        public List<RequestModel>? GetRequestsByOrderId(long orderId)
        {
            return _dataContext.Requests.Where(request => request.Order.OrderId == orderId).ToList();
        }

        public RequestModel? GetRequestByRequestId(long RequestId)
        {
            return _dataContext.Requests.Where(request => request.RequestId == RequestId).FirstOrDefault();
        }

        public List<RequestModel>? GetRequestsByUser(UserModel user)
        {
            return _dataContext.Requests.Where(request => request.Requestor == user).ToList();
        }
    }
}
