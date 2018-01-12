using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFO
{
    public static class status
    {

    }

    public static class selectedBrand
    {
        static string _brandname;
        public static string brandname
        {
            get { return _brandname; }
            set { _brandname = value; }
        }
    }

    public static class selectedProduct
    {
        static string _productname;
        public static string productname
        {
            get { return _productname; }
            set { _productname = value; }
        }
    }

    public static class addToCart
    {
        static string _customerid;
        public static string customerid
        {
            get { return _customerid; }
            set { _customerid = value; }
        }

        static string _productname;
        public static string productname
        {
            get { return _productname; }
            set { _productname = value; }
        }

        static string _size;
        public static string size
        {
            get { return _size; }
            set { _size = value; }
        }

        static string _quantity;
        public static string quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

    }

    public static class checkout
    {
        static List<string> _productname;
        public static List<string> productname
        {
            get { return _productname; }
            set { _productname = value; }
        }

        static List<string> _imageurl;
        public static List<string> imageurl
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }

        static List<string> _price;
        public static List<string> price
        {
            get { return _price; }
            set { _price = value; }
        }
    }

    public static class registrationCustomer
    {
        static string _code;
        public static string code
        {
            get { return _code; }
            set { _code = value; }
        }

        static string _id;
        public static string id
        {
            get { return _id; }
            set { _id = value; }
        }

        static string _lastname;
        public static string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        static string _firstname;
        public static string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        static string _email;
        public static string email
        {
            get { return _email; }
            set { _email = value; }
        }

        static string _contactnumber;
        public static string contactnumber
        {
            get { return _contactnumber; }
            set { _contactnumber = value; }
        }

        static string _username;
        public static string username
        {
            get { return _username; }
            set { _username = value; }
        }

        static string _password;
        public static string password
        {
            get { return _password; }
            set { _password = value; }
        }
    }

    public static class currentUser
    {

        static string _code;
        public static string code
        {
            get { return _code; }
            set { _code = value; }
        }

        static string _usertype;
        public static string usertype
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

        static string _id;
        public static string id
        {
            get { return _id; }
            set { _id = value; }
        }

        static string _lastname;
        public static string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        static string _firstname;
        public static string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        static string _email;
        public static string email
        {
            get { return _email; }
            set { _email = value; }
        }

        static string _contactnumber;
        public static string contactnumber
        {
            get { return _contactnumber; }
            set { _contactnumber = value; }
        }

        static string _username;
        public static string username
        {
            get { return _username; }
            set { _username = value; }
        }

        static string _password;
        public static string password
        {
            get { return _password; }
            set { _password = value; }
        }
    }

    public static class admin
    {

    }

    public static class users
    {

    }

    public static class customers
    {

    }

    public static class products
    {

    }

    public static class orders
    {

    }

    public static class database
    {
        
    }
}
