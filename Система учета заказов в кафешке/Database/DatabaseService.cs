using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Система_учета_заказов_в_кафешке.Models;
using System.Windows.Forms;
using MenuItemModel = Система_учета_заказов_в_кафешке.Models.MenuItem;

namespace Система_учета_заказов_в_кафешке.Database
{
    public class DatabaseService
    {
        private readonly string _connectionString;
        private static DatabaseService _instance;

        public static DatabaseService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseService();
                return _instance;
            }
        }

        private DatabaseService()
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "cafe_database.db");
            string directory = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _connectionString = $"Data Source={dbPath}";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Таблица пользователей
                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        Role TEXT NOT NULL,
                        CreatedAt TEXT NOT NULL,
                        IsActive INTEGER NOT NULL DEFAULT 1
                    )";

                using (var cmd1 = new SQLiteCommand(createUsersTable, connection))
                    cmd1.ExecuteNonQuery();

                // Таблица меню
                string createMenuTable = @"
                    CREATE TABLE IF NOT EXISTS MenuItems (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Category TEXT NOT NULL,
                        Price REAL NOT NULL,
                        IsAvailable INTEGER NOT NULL DEFAULT 1
                    )";

                using (var cmd2 = new SQLiteCommand(createMenuTable, connection))
                    cmd2.ExecuteNonQuery();

                // Таблица заказов
                string createOrdersTable = @"
                    CREATE TABLE IF NOT EXISTS Orders (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        OrderNumber INTEGER NOT NULL UNIQUE,
                        Status TEXT NOT NULL,
                        OrderTime TEXT NOT NULL,
                        StartTime TEXT,
                        ReadyTime TEXT,
                        Total REAL NOT NULL,
                        CookId INTEGER
                    )";

                using (var cmd3 = new SQLiteCommand(createOrdersTable, connection))
                    cmd3.ExecuteNonQuery();

                // Таблица позиций заказа
                string createOrderItemsTable = @"
                    CREATE TABLE IF NOT EXISTS OrderItems (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        OrderId INTEGER NOT NULL,
                        MenuItemId INTEGER NOT NULL,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL,
                        Quantity INTEGER NOT NULL,
                        Total REAL NOT NULL
                    )";

                using (var cmd4 = new SQLiteCommand(createOrderItemsTable, connection))
                    cmd4.ExecuteNonQuery();

                // Добавление тестовых данных
                InsertTestData(connection);
            }
        }

        private void InsertTestData(SQLiteConnection connection)
        {
            // Проверяем, есть ли пользователи
            string checkUsers = "SELECT COUNT(*) FROM Users";
            using (var checkCmd = new SQLiteCommand(checkUsers, connection))
            {
                long userCount = (long)checkCmd.ExecuteScalar();

                if (userCount == 0)
                {
                    // Добавляем администратора по умолчанию
                    string insertAdmin = @"
                        INSERT INTO Users (Username, PasswordHash, Role, CreatedAt, IsActive)
                        VALUES (@username, @password, @role, @createdAt, 1)";

                    using (var cmd = new SQLiteCommand(insertAdmin, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", "admin");
                        cmd.Parameters.AddWithValue("@password", HashPassword("admin123"));
                        cmd.Parameters.AddWithValue("@role", "Администратор");
                        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Проверяем, есть ли позиции меню
            string checkMenu = "SELECT COUNT(*) FROM MenuItems";
            using (var checkMenuCmd = new SQLiteCommand(checkMenu, connection))
            {
                long menuCount = (long)checkMenuCmd.ExecuteScalar();

                if (menuCount == 0)
                {
                    var menuItems = new[]
                    {
                        new { Name = "Капучино", Category = "Напитки", Price = 180m },
                        new { Name = "Латте", Category = "Напитки", Price = 200m },
                        new { Name = "Эспрессо", Category = "Напитки", Price = 120m },
                        new { Name = "Чай черный", Category = "Напитки", Price = 100m },
                        new { Name = "Чай зеленый", Category = "Напитки", Price = 100m },
                        new { Name = "Яблочный сок", Category = "Напитки", Price = 89m },
                        new { Name = "Апельсиновый сок", Category = "Напитки", Price = 89m },
                        new { Name = "Круассан", Category = "Десерты", Price = 150m },
                        new { Name = "Чизкейк", Category = "Десерты", Price = 250m },
                        new { Name = "Тирамису", Category = "Десерты", Price = 280m },
                        new { Name = "Салат Цезарь", Category = "Салаты", Price = 320m },
                        new { Name = "Чизбургер", Category = "Горячие блюда", Price = 367m },
                        new { Name = "Классический бургер", Category = "Горячие блюда", Price = 242m },
                        new { Name = "Пицца 4 сыра", Category = "Горячие блюда", Price = 489m },
                        new { Name = "Пицца Маргарита", Category = "Горячие блюда", Price = 462m },
                        new { Name = "Сэндвич с курицей", Category = "Закуски", Price = 220m },
                        new { Name = "Сэндвич с говядиной", Category = "Закуски", Price = 224m }
                    };

                    string insertMenu = @"
                        INSERT INTO MenuItems (Name, Category, Price, IsAvailable)
                        VALUES (@name, @category, @price, 1)";

                    foreach (var item in menuItems)
                    {
                        using (var cmd = new SQLiteCommand(insertMenu, connection))
                        {
                            cmd.Parameters.AddWithValue("@name", item.Name);
                            cmd.Parameters.AddWithValue("@category", item.Category);
                            cmd.Parameters.AddWithValue("@price", item.Price);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Методы для работы с пользователями
        public bool AuthenticateUser(string username, string password, out string role)
        {
            role = null;
            string hashedPassword = HashPassword(password);

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Role FROM Users WHERE Username = @username AND PasswordHash = @password AND IsActive = 1";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        role = result.ToString();
                        return true;
                    }
                    return false;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Username, Role, CreatedAt, IsActive FROM Users";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Role = reader.GetString(2),
                            CreatedAt = DateTime.Parse(reader.GetString(3)),
                            IsActive = reader.GetInt32(4) == 1
                        });
                    }
                }
            }
            return users;
        }

        public bool AddUser(string username, string password, string role)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Username, PasswordHash, Role, CreatedAt, IsActive) VALUES (@username, @password, @role, @createdAt, 1)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", HashPassword(password));
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // Методы для работы с меню
        public List<MenuItemModel> GetAllMenuItems()
        {
            var items = new List<MenuItemModel>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Name, Category, Price, IsAvailable FROM MenuItems ORDER BY Category, Name";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new MenuItemModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Category = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            IsAvailable = reader.GetInt32(4) == 1
                        });
                    }
                }
            }
            return items;
        }

        public bool AddMenuItem(string name, string category, decimal price)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO MenuItems (Name, Category, Price, IsAvailable) VALUES (@name, @category, @price, 1)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // Методы для работы с заказами
        public int CreateOrder(int orderNumber, List<OrderItem> items, decimal total)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertOrder = @"
                            INSERT INTO Orders (OrderNumber, Status, OrderTime, Total, CookId)
                            VALUES (@orderNumber, @status, @orderTime, @total, NULL);
                            SELECT last_insert_rowid();";

                        int orderId;
                        using (var cmd = new SQLiteCommand(insertOrder, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                            cmd.Parameters.AddWithValue("@status", "Ожидает");
                            cmd.Parameters.AddWithValue("@orderTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@total", total);
                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string insertItem = @"
                            INSERT INTO OrderItems (OrderId, MenuItemId, Name, Price, Quantity, Total)
                            VALUES (@orderId, @menuItemId, @name, @price, @quantity, @total)";

                        foreach (var item in items)
                        {
                            using (var cmd = new SQLiteCommand(insertItem, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@orderId", orderId);
                                cmd.Parameters.AddWithValue("@menuItemId", 0);
                                cmd.Parameters.AddWithValue("@name", item.Name);
                                cmd.Parameters.AddWithValue("@price", item.Price);
                                cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                                cmd.Parameters.AddWithValue("@total", item.Total);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return orderId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Id, OrderNumber, Status, OrderTime, StartTime, ReadyTime, Total, CookId FROM Orders ORDER BY OrderNumber DESC";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order();
                        order.Id = reader.GetInt32(0);
                        order.OrderNumber = reader.GetInt32(1);
                        order.Status = reader.GetString(2);
                        order.OrderTime = DateTime.Parse(reader.GetString(3));

                        if (!reader.IsDBNull(4))
                            order.StartTime = DateTime.Parse(reader.GetString(4));
                        else
                            order.StartTime = null;

                        if (!reader.IsDBNull(5))
                            order.ReadyTime = DateTime.Parse(reader.GetString(5));
                        else
                            order.ReadyTime = null;

                        order.Total = reader.GetDecimal(6);

                        if (!reader.IsDBNull(7))
                            order.CookId = reader.GetInt32(7);
                        else
                            order.CookId = null;

                        // Загружаем позиции заказа
                        order.Items = GetOrderItems(order.Id);
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        private List<OrderItem> GetOrderItems(int orderId)
        {
            var items = new List<OrderItem>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Id, OrderId, MenuItemId, Name, Price, Quantity, Total FROM OrderItems WHERE OrderId = @orderId";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new OrderItem
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
                                MenuItemId = reader.GetInt32(2),
                                Name = reader.GetString(3),
                                Price = reader.GetDecimal(4),
                                Quantity = reader.GetInt32(5),
                                Total = reader.GetDecimal(6)
                            });
                        }
                    }
                }
            }
            return items;
        }

        public bool UpdateOrderStatus(int orderId, string status, int? cookId = null)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string setClause = "Status = @status";
                var parameters = new List<SQLiteParameter>
                {
                    new SQLiteParameter("@status", status),
                    new SQLiteParameter("@id", orderId)
                };

                if (status == "В работе")
                {
                    setClause += ", StartTime = @startTime";
                    parameters.Add(new SQLiteParameter("@startTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else if (status == "Готов")
                {
                    setClause += ", ReadyTime = @readyTime";
                    parameters.Add(new SQLiteParameter("@readyTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }

                if (cookId.HasValue)
                {
                    setClause += ", CookId = @cookId";
                    parameters.Add(new SQLiteParameter("@cookId", cookId.Value));
                }

                string query = $"UPDATE Orders SET {setClause} WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Статистика для отчетов
        public decimal GetTotalRevenue(DateTime? startDate = null, DateTime? endDate = null)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COALESCE(SUM(Total), 0) FROM Orders WHERE Status = 'Завершен'";
                if (startDate.HasValue)
                    query += " AND date(OrderTime) >= date(@startDate)";
                if (endDate.HasValue)
                    query += " AND date(OrderTime) <= date(@endDate)";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (startDate.HasValue)
                        cmd.Parameters.AddWithValue("@startDate", startDate.Value.ToString("yyyy-MM-dd"));
                    if (endDate.HasValue)
                        cmd.Parameters.AddWithValue("@endDate", endDate.Value.ToString("yyyy-MM-dd"));

                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public int GetCompletedOrdersCount(DateTime? startDate = null, DateTime? endDate = null)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Orders WHERE Status = 'Завершен'";
                if (startDate.HasValue)
                    query += " AND date(OrderTime) >= date(@startDate)";
                if (endDate.HasValue)
                    query += " AND date(OrderTime) <= date(@endDate)";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (startDate.HasValue)
                        cmd.Parameters.AddWithValue("@startDate", startDate.Value.ToString("yyyy-MM-dd"));
                    if (endDate.HasValue)
                        cmd.Parameters.AddWithValue("@endDate", endDate.Value.ToString("yyyy-MM-dd"));

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public System.Collections.Generic.Dictionary<string, int> GetPopularItems(int topCount = 5)
        {
            var result = new System.Collections.Generic.Dictionary<string, int>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT Name, SUM(Quantity) as TotalQuantity
                    FROM OrderItems
                    GROUP BY Name
                    ORDER BY TotalQuantity DESC
                    LIMIT @topCount";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@topCount", topCount);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(0), reader.GetInt32(1));
                        }
                    }
                }
            }
            return result;
        }

        public double GetAverageCookingTime()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT AVG(
                        (julianday(ReadyTime) - julianday(OrderTime)) * 24 * 60
                    ) as AvgMinutes
                    FROM Orders
                    WHERE Status = 'Завершен' AND ReadyTime IS NOT NULL";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
        }
    }
}