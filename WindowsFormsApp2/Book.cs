using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Npgsql;

namespace WindowsFormsApp1
{
    public class Book
    {
        public Guid Id { get; set; }  // Идентификатор книги (UUID)
        public string Title { get; set; }  // Название книги
        public string Author { get; set; }  // Автор книги
        public int Year { get; set; }  // Год издания книги

        // Конструктор для инициализации книги с передачей всех данных, включая ID
        public Book(Guid id, string title, string author, int year)
        {
            Id = id;  // Устанавливаем Id
            Title = title;
            Author = author;
            Year = year;
        }

        // Конструктор без Id, для случаев, когда Id присваивается после создания
        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        // Переопределенный метод ToString для удобного вывода информации о книге
        public override string ToString()
        {
            return $"ID: {Id}, Название: {Title}, Автор: {Author}, Год: {Year}";
        }
    }
}
