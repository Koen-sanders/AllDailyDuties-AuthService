using AllDailyDuties_AuthService.Helpers;
using AllDailyDuties_AuthService.Models.Users;
using AllDailyDuties_AuthService.Services.Interfaces;
using AutoMapper;

namespace AllDailyDuties_AuthService.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(Guid id)
        {
            return getUser(id);
        }
        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");


            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            DateTime now = DateTime.Now;

            user.Created = now;

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Helper method(s)
        private User getUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
