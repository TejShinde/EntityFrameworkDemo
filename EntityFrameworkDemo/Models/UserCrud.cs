namespace EntityFrameworkDemo .Models
    {
    public class UserCrud
        {
        private readonly ApplicationDbContext db;
        public UserCrud ( ApplicationDbContext db )
            {
            this .db = db;
            }

        //public UserLogin ValidateUser ( UserLogin login )
        //    {
        // Using LINQ to validate user credentials
        //var user = db .UserLogins
        //             .Where(u => u .Username == login .Username && u .Password == login .Password)
        //             .SingleOrDefault();

        //return user;


        // Method for registering a user
        public int RegisterUser ( UserLogin user )
            {
            db .UserLogins .Add(user);
            return db .SaveChanges();
            }
        public UserLogin ValidateUser ( UserLogin login )
            {
            // Using LINQ to validate user credentials
            var result = db .UserLogins
                         .Where(u => u .Username == login .Username && u .Password == login .Password);
            //if ( result != null )
            //    {
            //    return 1;
            //    }
            //else
            //    {
            //    return 0;
            //    }
            //}
            return (UserLogin) result;
            }
        }
    }

        //return user;
        // Method for validating login credentials
        //public UserLogin ValidateUser ( string username , string password )
        //    {
        //    return db .UserLogins
        //              .SingleOrDefault(u => u .Username == username && u .Password == password);
        //    }

      
