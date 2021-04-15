using BTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTAPI.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public List<KhachHang> GetCustomerLists()
        {
            BTAPIEntities dbCustomer = new BTAPIEntities();
            return dbCustomer.KhachHangs.ToList();
        }
        //2. Dịch vụ lấy thông tin một khách hàng với mã nào đó
        [HttpGet]
        public KhachHang GetCustomer(int id)
        {
            BTAPIEntities dbCustomer = new BTAPIEntities();
            return dbCustomer.KhachHangs.FirstOrDefault(x => x.ID == id);
        }
        //3. httpPost, dịch vụ thêm mới một khách hàng
        [HttpPost]
        public bool InsertNewCustomer(string name, string adress, string phoneNumber)
        {
            try
            {
                BTAPIEntities dbCustomer = new BTAPIEntities();
                KhachHang customer = new KhachHang();
                customer.TenKhach = name;
                customer.DiaChi = adress;
                customer.DienThoai = phoneNumber;
                dbCustomer.KhachHangs.Add(customer);
                dbCustomer.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //4. httpPut để chỉnh sửa thông tin một khách hàng
        [HttpPut]
        public bool UpdateCustomer(int id,string name, string adress, string phoneNumber)
        {
            try
            {
                BTAPIEntities dbCustomer = new BTAPIEntities();
                //Lấy mã khách đã có
                KhachHang customer = dbCustomer.KhachHangs.FirstOrDefault(x => x.ID == id);
                if (customer == null) return false;
                customer.TenKhach = name;
                customer.DiaChi = adress;
                customer.DienThoai = phoneNumber;
                dbCustomer.SaveChanges();//Xác nhận chỉnh sửa
                return true;
            }
            catch
            {
                return false;
            }
        }
        //5.httpDelete để xóa một Khách hàng
        [HttpDelete]
        public bool DeleteCustomer(int id)
        {
            try
            {
                BTAPIEntities dbCustomer = new BTAPIEntities();
                //Lấy mã khách đã có
                KhachHang customer = dbCustomer.KhachHangs.FirstOrDefault(x => x.ID == id);
                if (customer == null) return false;
                dbCustomer.KhachHangs.Remove(customer);
                dbCustomer.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}