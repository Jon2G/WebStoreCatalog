using Microsoft.AspNetCore.Components;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.ViewModels
{
    public class LoginViewModel
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string[] Errors;
        private MongoDb Db { get; set; } = new MongoDb();
        public bool IsOpen { get; private set; }

        private IPage Page;
        public LoginViewModel(IPage page)
        {
            this.Page = page;

        }

        public bool ValidateLog(out string[] errors)
        {
            List<string> internalErrors = new List<string>();
            if (string.IsNullOrEmpty(Nickname?.Trim()))
            {
                internalErrors.Add("El usuario no debe estar vacío");
            }

            if (string.IsNullOrEmpty(Password?.Trim()))
            {
                internalErrors.Add("La contraseña no debe estar vacía");
            }
            errors = internalErrors.ToArray();
            return !errors.Any();
        }
        public async Task LogIn(NavigationManager manager)
        {
            await Task.Yield();
            if (ValidateLog(out Errors))
            {
                AppData.User = UserModel.LogIn(this.Db, this.Nickname, this.Password);
                if (AppData.IsLogedIn)
                {
                    manager.NavigateTo("/Index");
                }
            }
            else
            {
                ToggleOpen(true);
            }

        }
        public void ToggleOpen(bool isOpen)
        {
            IsOpen = isOpen;
            this.Page.RefreshState();
        }

    }
}
