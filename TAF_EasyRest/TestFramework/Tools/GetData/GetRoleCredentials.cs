//using Newtonsoft.Json;
using System.Text.Json;

namespace TestFramework.Tools.deserialization
{
    public class GetRoleCredentials
    {
        private static string _roleCredentials = Directory.GetParent(path:@"../../") + "RolesCredentials.json";

        public static void Serialize(List<RoleCredentials> data)
        {
            using (FileStream fs = new FileStream(_roleCredentials, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, data);
            }
        }

        private static List<RoleCredentials> getListRoleCredentials()
        {
            List<RoleCredentials> roles;
            using (FileStream fs = new FileStream(_roleCredentials, FileMode.OpenOrCreate))
            {
                roles = JsonSerializer.Deserialize<List<RoleCredentials>>(fs);
            }

            return roles;
        }

        public static RoleCredentials GetCredentials(string roleName)
        {
            return getListRoleCredentials().Find(role => role.RoleName == roleName);
        }
    }
}
