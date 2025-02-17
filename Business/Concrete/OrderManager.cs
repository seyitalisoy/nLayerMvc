using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order entity)
        {
            _orderDal.Add(entity);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        IResult IOrderService.Add(Order entity)
        {
            _orderDal.Add(entity);
            return new SuccessResult("Sipariş eklendi");
        }

        IDataResult<List<Order>> IOrderService.GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());    }
    }
}
