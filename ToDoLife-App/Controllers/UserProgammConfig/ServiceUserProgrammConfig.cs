using ToDoLife_App.Data;
using ToDoLife_App.Models;
namespace ToDoLife_App.Controllers.UserProgammConfig
{
    public class ServiceUserProgrammConfig
    {
        private Guid _user;
        private ApplicationDbContext _context;
        private UserProgrammConfig _config;
        public ServiceUserProgrammConfig(ApplicationDbContext context, Guid userGuid)
        {
            _user = userGuid;
            _context = context;
            if (isConfigForUserExists())
            {

                _config = getConfig();
            }
            else
            {
                _config = createConfig();
                _context.Add(_config);
                _context.SaveChanges();

            }

        }

        private UserProgrammConfig createConfig()
        {
            return new UserProgrammConfig { User = _user };
        }
        private bool isConfigForUserExists()
        {
            return _context.UserProgrammConfig.Any(config => config.User.Equals(_user));
        }
        public UserProgrammConfig getConfig()
        {
            return _context.UserProgrammConfig.First(config => config.User.Equals(_user));
        }
    }
}
