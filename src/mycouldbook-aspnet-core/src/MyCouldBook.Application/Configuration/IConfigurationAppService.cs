using System.Threading.Tasks;
using MyCouldBook.Configuration.Dto;

namespace MyCouldBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
