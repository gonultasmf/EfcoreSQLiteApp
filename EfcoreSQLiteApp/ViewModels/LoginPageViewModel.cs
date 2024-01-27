using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace EfcoreSQLiteApp.ViewModels;

public partial class LoginPageViewModel(MyContext context) : BaseViewModel
{
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    public ICommand LoginCommand => new Command(async () =>
    {
        var table = context.Set<User>();

        var control = await table.AnyAsync(x => x.Email == Email && x.Password == Password);

        if (!control)
        {
            var temp = await table.AddAsync(new User
            {
                Email = Email,
                Password = Password,
                Name = $"{Email} - {Password}"
            });

            await context.SaveChangesAsync();
        }
    });
}
