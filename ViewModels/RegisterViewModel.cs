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
        private string[] Errors;
        public bool IsOpen { get; private set; } 

        public async Task Save(MongoDb mongo)
        {
            await Task.Yield();
            if (User.Validate(out Errors))
            {
                User = await User.Save(mongo);
            }
            else
            {
                ToggleOpen(true);
            }

        }
        public void ToggleOpen(bool isOpen,Register page)
        {
            IsOpen = isOpen;
            page.StateHasChanged();
        }
    }
}
