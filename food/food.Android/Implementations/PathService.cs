[assembly:Xamarin.Forms.Dependency(typeof(food.Droid.Implementations.PathService))]
namespace food.Droid.Implementations
{
    using Interfaces;
    using System;
    using System.IO;
    public class PathService:IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, "food.db3");
        }
    }
}