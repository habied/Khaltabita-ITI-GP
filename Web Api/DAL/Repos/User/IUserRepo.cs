using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserRepo
    {
        //all quieries my busniess need 
        IEnumerable <User> GetUsers ();

        User? GetUser(String id);
        User? GetUserByEmail (String email);
        void Add( User user);
        void Update (User user );
        void Delete ( User user );
        int SaveChanges();




    }
}
