using ObrasBibliograficasWeb.Extension;
using ObrasBibliograficasWeb.Models;
using ObrasBibliograficasWeb.Query;
using ObrasBibliograficasWeb.Repositories.Interfaces;
using ObrasBibliograficasWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObrasBibliograficasWeb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddRangeAsync()
        {
            var list = UserExtension.List();

            await _userRepository.AddRangeAsync(list);
            await _userRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable<UserQuery>> GetAllAsync(BibliographiesModel model)
        {
            var users = await _userRepository.GetAllAsnc(x => x.Name != null, false, model.Number, 1);
            var list = new List<UserQuery>();

            foreach (var value in users)
            {
                list.Add(new UserQuery { Name = FormatName(value.Name) });
            }

            return list;
        }

        public string FormatName(string name)
        {
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;

            var arr = name.ToUpper().Split(" ");
            var exists = Filter(arr.LastOrDefault());
            var count = 1;
            var total = arr.ToArray().Length;

            var sb = new StringBuilder();
            var firstName = new StringBuilder();
            var justOnName = count == total;

            foreach (var value in arr)
            {
                var needsToBeLowerCase = ProbableLowerCase(value);
                if (exists && Filter(value) && arr[total - 1] == value)
                {
                    sb.Append($"{value}");
                }
                else if (count == 1)
                {
                    firstName.Append(count == total ? value : $"{FormatWord(value)} ");
                }
                else if (exists && Filter(arr[count]))
                {
                    sb.Append($"{value} ");
                }
                else if (!needsToBeLowerCase && count != total)
                {
                    firstName.Append($"{FormatWord(value)} ");

                }
                else if (needsToBeLowerCase)
                {
                    firstName.Append($"{value.ToLower()} ");
                }
                else
                {
                    sb.Append($"{value}");
                }
                count++;
            }

            if (justOnName)
            {
                return firstName.ToString();
            }
            else
            {
                sb.Append($", {firstName}");

                return sb.ToString();
            }
        }

        private static string FormatWord(string word)
        {
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            return cultInfo.ToTitleCase(word.ToLower());
        }

        private static bool ProbableLowerCase(string text)
        {
            var list = new List<string>
            {
                "DA", "DE", "DO", "DAS", "DOS"
            };

            if (list.Any(x => x.Equals(text)))
            {
                return true;
            }
            return false;
        }

        private static bool Filter(string text)
        {
            var list = new List<string>
            {
                { "FILHO" },
                { "FILHA" },
                { "NETO" },
                { "NETA" },
                { "SOBRINHO" },
                { "SOBRINHA" },
                { "JUNIOR" }
            };

            return list.Any(x => x.Equals(text.ToUpper()));
        }
    }
}
