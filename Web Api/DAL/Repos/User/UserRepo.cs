using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class UserRepo : IUserRepo
{
    private readonly FoodyContext _context;

    public UserRepo(FoodyContext context) {
        _context = context;
    }   
    public void Add(User user)
    {
        _context.Set<User>().Add(user);
    }

    public void Delete(User user)
    {
        _context.Set<User>().Remove(user);
    }

    public User? GetUser(string id)
    {
        return _context.Set<User>().Find(id);
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Set<User>().Find(email);
    }

    public IEnumerable<User> GetUsers()
    {
        
        return _context.Set<User>().AsNoTracking();
    }

    public void Update(User user)
    {
        //
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
