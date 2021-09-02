using Microsoft.EntityFrameworkCore;
using S4_NETCOREWEB_JQUERYMVC.DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S4_NETCOREWEB_JQUERYMVC.DatabaseFirst.Repository
{
    public class CustomerRepo
    {

        public static IEnumerable<Customer> GetCustomers()
        {
            using var data = new Sales2021Context();
            return data.Customer.ToList();
        }

        public static async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            using var data = new Sales2021Context();
            return await data.Customer.Include(x=>x.Order).ToListAsync();
        }

        public static Customer GetCustomerById(int id)
        {
            using var data = new Sales2021Context();
            return data.Customer.Where(x => x.Id == id).FirstOrDefault();
        }

        public static async Task<Customer> GetCustomerByIdAsync(int id)
        {
            using var data = new Sales2021Context();
            return await data.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public static IEnumerable<Customer> GetCustomersSP()
        {
            using var data = new Sales2021Context();
            return data.Customer.FromSqlRaw("SP_GET_CUSTOMERS");
        }

        public static async Task<bool> Insert(Customer customer)
        {
            bool exito = true;

            try
            {
                using var data = new Sales2021Context();
                data.Customer.Add(customer);
                await data.SaveChangesAsync();
            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }

        public static async Task<bool> Update(Customer customer)
        {
            bool exito = true;
            try
            {
                using var data = new Sales2021Context();

                var customerNow = await data.Customer.Where(x => x.Id == customer.Id).FirstOrDefaultAsync();

                customerNow.FirstName = customer.FirstName;
                customerNow.LastName = customer.LastName;
                customerNow.City = customer.City;
                customerNow.Phone = customer.Phone;
                customerNow.Country = customer.Country;

                await data.SaveChangesAsync();

                //data.Customer.Update()

            }
            catch (Exception)
            {

                throw;
            }

            return exito;
        }

        public static async Task<bool> Delete(int id)
        {
            bool exito = true;

            try
            {
                using var data = new Sales2021Context();
                var customerNow = await data.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();

                data.Customer.Remove(customerNow);
                await data.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return exito;
        }
    }
}
