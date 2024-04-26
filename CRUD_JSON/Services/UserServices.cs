using Blazored.Toast.Services;
using CRUD_JSON.Model;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CRUD_JSON.Services
{
    public class UserServices
    {
        public readonly string path = "AppData";
        private readonly IToastService _toastService;

        public UserServices(IToastService toastService) {
            _toastService = toastService;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public async Task CreateUser(int id, User user)
        {
            string filePath = Path.Combine(path, $"{id}.json");
            var users = await GetUser(id);
            users.Add(user);
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, json);
        }

        public async Task<List<User>> GetUser(int id)
        {
            string filePath = Path.Combine(path, $"{id}.json");
            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<User>>(json);
            }
            return new List<User>();
        }

        public async Task<List<User>> GetUserAllData()
        {
            List<User> users = new List<User>();
            string[] jsonFiles = Directory.GetFiles(path, "*.json");

            if (jsonFiles.Any())
            {
                foreach (var jsonFile in jsonFiles)
                {
                    if (File.Exists(jsonFile))
                    {
                        var json = await File.ReadAllTextAsync(jsonFile);
                        var alldata = JsonSerializer.Deserialize<List<User>>(json);
                        users.AddRange(alldata);
                    }
                }
            }
            else
            {
                Console.WriteLine("No JSON files found in the folder.");
            }
            return users;
        }

        public async Task UpdateUser(int id, string name, User user)
        {
            string filePath = Path.Combine(path, $"{id}.json");
            var users = await GetUser(id);
            if (users != null)
            {
                List<User> userList = users;
                User userToUpdate = userList.FirstOrDefault(u => u.Id == id && u.Name == name);
                if (userToUpdate != null)
                {
                    userToUpdate.Id = user.Id;
                    userToUpdate.Name = user.Name;
                    userToUpdate.Email = user.Email;

                    string updatedJsonArray = JsonSerializer.Serialize(userList);
                    File.WriteAllText(filePath, updatedJsonArray);
                }
            }
        }

        public async Task DeleteUser(int id, string name)
        {
            string filePath = Path.Combine(path, $"{id}.json");
            var users = await GetUser(id); 
            if (users != null && users.Count > 1) 
            {
                List<User> userList = users;
                User userToDelete = userList.FirstOrDefault(u => u.Id == id && u.Name == name);
                if (userToDelete != null)
                {
                    userList.Remove(userToDelete);
                    string updatedJsonArray = JsonSerializer.Serialize(userList);
                    await File.WriteAllTextAsync(filePath, updatedJsonArray);
                }
            }
            else
            {
                File.Delete(filePath);
            }
        }
    }
}
