using MongoDB.Bson.Serialization.Attributes;
using WebStore.Data;
using WebStore.Models;
using WebStore.Pages;

namespace WebStore.ViewModels
{
    public class RegisterViewModel
    {
        [BsonIgnore]
        public string ConfirPassword { get; set; }
        public UserModel User { get; set; }
        public string[] Errors;
        public bool IsOpen { get; private set; }
        public MongoDb Db { get; set; }
        private readonly IPage Page;
        public RegisterViewModel(IPage page)
        {
            this.Page = page;
        }

        public async Task Save()
        {
            await Task.Yield();
            if (Validate(out Errors))
            {
                User = await User.Save(this.Db);
            }
            else
            {
                ToggleOpen(true, this.Page);
            }

        }
        public bool Validate(out string[] errors)
        {
            List<string> internalErrors = new List<string>();
            if (string.IsNullOrEmpty(User.Nickname?.Trim()))
            {
                internalErrors.Add("El usuario no debe estar vacío");
            }

            if (string.IsNullOrEmpty(User.Password?.Trim()))
            {
                internalErrors.Add("La contraseña no debe estar vacía");
            }
            if (string.IsNullOrEmpty(ConfirPassword?.Trim()))
            {
                internalErrors.Add("La confirmacion de la  contraseña no debe estar vacía");
            }
            if (string.IsNullOrEmpty(ConfirPassword?.Trim()) != string.IsNullOrEmpty(User.Password?.Trim()))
            {
                internalErrors.Add("Las contraseñas no coinciden");
            }
            errors = internalErrors.ToArray();
            return !errors.Any();
        }
        public void ToggleOpen(bool isOpen, IPage page)
        {
            IsOpen = isOpen;
            page.RefreshState();
        }
    }
}
