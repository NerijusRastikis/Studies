public interface IFileManager
{
    List<User> LoadUsers();
    void SaveUsers(List<User> users);
    void UpdateUser(User user);
    Dictionary<int, int> LoadATMFunds();
    void SaveATMFunds(Dictionary<int, int> atmFunds);
}
