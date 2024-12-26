using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using BCrypt.Net;

namespace WindowsFormsApp2
{
    public class UserManager
    {
        private readonly string _connectionString;

        // Конструктор с передачей строки подключения
        public UserManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Метод для добавления пользователя
        public User Authenticate(string username, string password)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                // Запрос для получения пользователя по логину и паролю
                var cmd = new NpgsqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);  // Сравниваем пароли как обычные строки
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Если нашли пользователя, возвращаем объект User
                    return new User
                    {
                        Username = reader.GetString(0),
                        Password = reader.GetString(1),  // Пароль сохраняем в открытом виде (не рекомендуется)
                        Role = reader.GetString(2)
                    };
                }
            }
            return null;  // Если не нашли, возвращаем null
        }
    }
}