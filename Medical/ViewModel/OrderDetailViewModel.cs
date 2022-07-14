using Medical.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.ViewModel
{
    public class OrderDetailViewModel
    {
        private OrderDetail _OrderDetail;
        private Order _Order;
        private Product _Product;
        private Review _Review;
        private Member _member;
        public OrderDetailViewModel()
        {
            _member = new Member();
            _OrderDetail = new OrderDetail();
            _Order = new Order();
            _Product = new Product();
            _Review = new Review();
        }
        public OrderDetail OrderDetail
        {
            get { return _OrderDetail; }
            set { _OrderDetail = value; }
        }
        public Review Review
        {
            get { return _Review; }
            set { _Review = value; }
        }
        public Member Member
        {
            get { return _member; }
            set { _member = value; }
        }


        public int OrderDetailId
        {
            get { return _OrderDetail.OrderDetailId; }
            set { _OrderDetail.OrderDetailId = value; }
        }
        public int OrderId
        {
            get { return _OrderDetail.OrderId; }
            set { _OrderDetail.OrderId = value; }
        }
        public int ProductId
        {
            get { return _OrderDetail.ProductId; }
            set { _OrderDetail.ProductId = value; }
        }
        [DisplayName("購買數量")]
        public int Quantity
        {
            get { return _OrderDetail.Quantity; }
            set { _OrderDetail.Quantity = value; }
        }

        public virtual Order Order
        {
            get { return _OrderDetail.Order; }
            set { _OrderDetail.Order = value; }
        }
        public virtual Product Product
        {
            get { return _OrderDetail.Product; }
            set { _OrderDetail.Product = value; }
        }
    }
}
