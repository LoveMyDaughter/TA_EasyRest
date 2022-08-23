
namespace TestFramework.Tools
{
    public class DBAddition
    {

        public static void AddRestaurantViaDB(string name, string address = "3807 Brook Street, Huston, TX 77030, USA", int ownerId = 1, int status = 0)
        {
            string addRestaurant = $"INSERT INTO restaurants (name, address_id, owner_id, status) VALUES ('{name}', '{address}', {ownerId}, {status})";
            DBConnectionWrapper.ExecuteQuery(addRestaurant);
        }

    }
}
