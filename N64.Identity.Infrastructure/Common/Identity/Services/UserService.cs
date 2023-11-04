using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.NotificationService;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContext;
using System.Linq.Expressions;

namespace N64.Identity.Infrastructure.Common.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly IEmailOrchestrationService _emailOrchestrationService;
        private readonly EmailSenderSettings _emailSenderSettings;

        public UserService(AppDbContext appDbContext, IVerificationCodeService verificationCodeService, IEmailOrchestrationService emailOrchestrationService, IOptions<EmailSenderSettings> emailSenderSettings)
        {
            _appDbContext = appDbContext;
            _verificationCodeService = verificationCodeService;
            _emailOrchestrationService = emailOrchestrationService;
            _emailSenderSettings = emailSenderSettings.Value;
        }

        public async ValueTask<User> CreateUserAsync(User user)
        {
            var exsistingUser = _appDbContext.Users.FirstOrDefault(x => x.Email == user.Email);
            if (exsistingUser != null)
                throw new InvalidOperationException("This User Already exsisting!!");

            var result = await _verificationCodeService.Generate(user.Id = Guid.Empty);

            await _emailOrchestrationService.SendVerificationCodeAsync(user.Email,result);

            await _appDbContext.Users.AddAsync(user);

            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
            => _appDbContext.Users.Where(predicate.Compile()).AsQueryable();

        public ValueTask<User> GetUserByIdAsync(Guid userId)
        {
            var foundingUser = _appDbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (foundingUser == null)
                throw new InvalidOperationException("This user does not exsist!!");

            return new(foundingUser);

        }

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            var updatingUser = _appDbContext.Users.FirstOrDefault(x => x.Id == user.Id);
            if (updatingUser == null)
                throw new InvalidOperationException("This User does not exsist!!");

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };

            await _appDbContext.Users.AddAsync(newUser);
            await _appDbContext.SaveChangesAsync();
            return newUser;
        }
    }
}
