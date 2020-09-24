using ObrasBibliograficasWeb.Extension;
using ObrasBibliograficasWeb.Models;
using ObrasBibliograficasWeb.Repositories.Interfaces;
using ObrasBibliograficasWeb.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ObrasBibliograficasWeb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task GetAllAsync(BibliographiesModel model)
        {
            var users = await _userRepository.GetAllAsnc(x => x.Name != null, false, model.Number, 1);

            throw new NotImplementedException();
        }

        public async Task PostAsync()
        {
            var users = UserExtension.List();
            await _userRepository.AddRangeAsync(users);
            await _userRepository.SaveChangeAsync();
        }
    }
}
