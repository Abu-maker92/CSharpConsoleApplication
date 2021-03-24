using ProjectA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.DataInMemory
{
    class ProductsData : IData<Products>
    {
        static List<Products> data = new List<Products>() {
            new Products () { ProductID= 101,    ProductName= "Aluminium LED Bulb",  IsActive= true, Quantity=4, Warranty="1 year ",  Price=30},
            new Products () { ProductID= 102,    ProductName= "Celling Fans",        IsActive= false,Quantity=2, Warranty="2 year",   Price=120 },
            new Products () { ProductID= 103,    ProductName= "LED Foodlight",       IsActive= true, Quantity=5, Warranty="6 months", Price=130 },
            new Products () { ProductID= 104,    ProductName= "Air Coolers",         IsActive= true, Quantity=1, Warranty="3 year",   Price=500 },
            new Products () { ProductID= 105,    ProductName= "Air Conditioner",     IsActive= false,Quantity=1, Warranty="3 year",   Price=1000 },
            new Products () { ProductID= 106,    ProductName= "Decorative Lamps",    IsActive= false,Quantity=5, Warranty="6 months", Price=110 }

        };

        public Products Add(Products obj)
        {

            obj.ProductID = 1;
            if (data != null && data.Count > 0)
                obj.ProductID = data.Max(a => a.ProductID) + 1;
            data.Add(obj);
            return obj;


        }

        public Products Get(long id)
        {
            Products cust = data.Find(p => p.ProductID == id);
            return cust;
        }

        public Products Get(string name)
        {
            return data.FirstOrDefault(p => p.ProductName == name);

        }

        public IEnumerable<Products> GetAll()
        {
            return data;
        }

        public IEnumerable<Products> GetByName(string name)
        {
            var gets = data.Where(a => a.ProductName.Contains(name));
            return gets;
        }

        public void LoadSampleData()
        {
            this.Add(new Products { ProductName = "Bulb",      IsActive = false,Quantity=10, Warranty = "6 months", Price = 800 });
            this.Add(new Products { ProductName = "Fan",       IsActive = true, Quantity=5,  Warranty = "5 years",  Price = 7500 });
            this.Add(new Products { ProductName = "Foodlight", IsActive = true, Quantity=12, Warranty = "3 months", Price = 500 });
            this.Add(new Products { ProductName = "Lamps",     IsActive = false,Quantity=15, Warranty = "2 months", Price = 600 });

        }

        public Products Name(string name)
        {
            return data.FirstOrDefault(p => p.ProductName.Contains(name));
        }

        public bool Remove(long id)
        {
            data.RemoveAll(p => p.ProductID == id);
            return true;
        }

        public bool Remove(Products obj)
        {
            data.RemoveAll(p => p.ProductID == obj.ProductID);
            return true;
        }

        public Products Update(Products obj)
        {
            Products r = data.FirstOrDefault(q => q.ProductID == obj.ProductID);
            //r.ProductName = obj.ProductName;
            //r.IsActive = obj.IsActive;
            //r.Warranty = obj.Warranty;
            //r.Price = obj.Price;


            if (obj.ProductName != null && obj.ProductName.Trim() != "")
            {
                r.ProductName = obj.ProductName;
            }
            else if (obj.IsActive != null)
            {
                r.IsActive = obj.IsActive;
            }
            else if (obj.Warranty != null && obj.Warranty.Trim() != "")
            {
                r.Warranty = obj.Warranty;
            }
            else if (obj.Price != null)
            {
                r.Price = obj.Price;
            }
            return r;
        }

    }
}
