using WebStore.Models;

namespace WebStore.Data
{
    public static class AppData
    {
        public static UserModel User { get; set; }
        public static bool IsLogedIn => User is not null;
        
        
    }
}
