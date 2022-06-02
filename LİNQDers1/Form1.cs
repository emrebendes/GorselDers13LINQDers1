using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LİNQDers1
{
    public partial class Form1 : Form
    {
        public List<Product> products = new List<Product>()
        {
            new Product() { id =1, productName ="Acer",price=10000,categoryId=1 },
            new Product() { id =2, productName ="HP",price=55000,categoryId=1 },
            new Product() { id =3, productName ="Lenovo",price=32000,categoryId=1 },
            new Product() { id =4, productName ="Samsung",price=15000,categoryId=2 },
            new Product() { id =5, productName ="Iphone",price=20000,categoryId=2 },
            new Product() { id =6, productName ="Asus",price=1520,categoryId=2 },
            new Product() { id =6, productName ="Asus",price=12000,categoryId=1 }
        };
        public List<Category> categories = new List<Category>()
        {
            new Category() { categoryId = 1, categoryName ="Computer"},
            new Category() { categoryId = 2, categoryName ="Phone"}
        };
        public Form1()
        {
            InitializeComponent();
            int a = 5;
            //MessageBox.Show("f =" + a.faktoriyel());

            // List<Product> p =  priceLimit(9000);

            //IEnumerable<Product>
            /*var products1 = products.
                Select(p => new { p.productName, p.price }).
                Where(p => p.price > 9000);*/

            /*var a =(from p in products 
                            where p.price > 9000
                            select new { p.productName, p.price })*/

            /*dataGridView1.DataSource = (from p in products
                    join c in categories
                    on p.categoryId equals c.categoryId
                    select new {p.productName, p.price,c.categoryName}).ToList();*/

            var aa = from p in products
                    group p by p.categoryId into g
                    select new { g.Key, adet = g.Count(), grup=g };

            foreach (var c in aa)
            {
                listBox1.Items.Add("kategori :"+c.Key+" toplam ürün : "+c.adet);
                foreach (var d in c.grup)
                    listBox1.Items.Add(d.productName);
            }

                  

            //dataGridView1.DataSource=products1.ToList();
            /* foreach (var product in products1)
             {
                 listBox1.Items.Add(product.productName);
             }*/



        }


        public List<Product> priceLimit(double a)
        {
            List<Product> p = new List<Product>();
            foreach (Product product in products)
            { 
                if (product.price>=a)
                    p.Add(product);
            }
            return p;
        }
    }

    public class Product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int categoryId { get; set; }

    }

    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }

    }


    public static class OurFuncs
    {
        public static int faktoriyel(this int n)
        {
            int a=1;
            for (int i = n; i > 0; i--)
            { 
                a*=i;
            }
            return a;
        }
    }


}
