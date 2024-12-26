using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element; // Для Text в iTextSharp
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas.Parser;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing; // Для Text в Open XML SDK
using DocumentFormat.OpenXml.ExtendedProperties;
using Npgsql;
using System.Drawing;
using ZXing;

namespace WindowsFormsApp1
{
    public class BookManager
    {
        private readonly string _connectionString;

        // Конструктор с передачей строки подключения
        public BookManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Метод для получения всех книг из базы данных
        public List<Book> GetAllBooks()
        {
            // Создаем список для хранения книг
            var books = new List<Book>();

            // Создаем подключение к базе данных
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                // Пример SQL-запроса для получения всех книг
                var cmd = new NpgsqlCommand("SELECT * FROM books", conn);
                var reader = cmd.ExecuteReader();

                // Чтение данных из базы данных и добавление в список
                while (reader.Read())
                {
                    var book = new Book(
                        reader.GetString(1),  // Title
                        reader.GetString(2),  // Author
                        reader.GetInt32(3)    // Year
                    )
                    {
                        Id = reader.GetGuid(0)
                    };

                    books.Add(book); // Добавляем книгу в список
                }
            }

            return books;
        }
        public void AddBook(Book book)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                // SQL-запрос для вставки новой книги в базу данных
                var cmd = new NpgsqlCommand("INSERT INTO books (title, author, year) VALUES (@title, @author, @year) RETURNING id", conn);

                // Добавление параметров в запрос для предотвращения SQL-инъекций
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@year", book.Year);

                // Извлечение сгенерированного id из базы данных
                var id = cmd.ExecuteScalar(); // Получаем результат выполнения запроса, который будет UUID

                // Присваиваем сгенерированный Id объекту book
                book.Id = (Guid)id; // Преобразуем результат в тип Guid

                // Теперь у вас есть объект book с заполненным Id
            }
        }
        public List<Book> FindBookByName(string title)
        {
            var books = new List<Book>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                // Запрос для поиска книг по названию
                var command = new NpgsqlCommand("SELECT * FROM books WHERE title ILIKE @Title", connection);
                command.Parameters.AddWithValue("@Title", "%" + title + "%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var book = new Book(
                            reader.GetString(1),  // Title
                            reader.GetString(2),  // Author
                            reader.GetInt32(3)    // Year
                        )
                        {
                            Id = reader.GetGuid(0) // Id устанавливаем отдельно
                        };

                        books.Add(book); // Добавляем книгу в список
                    }
                }
            }

            return books;
        }

        // Метод для поиска книги по автору
        public List<Book> FindBookByAuthor(string author)
        {
            var books = new List<Book>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                // Запрос для поиска книг по автору
                var command = new NpgsqlCommand("SELECT * FROM books WHERE author ILIKE @Author", connection);
                command.Parameters.AddWithValue("@Author", "%" + author + "%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var book = new Book(
                            reader.GetString(1),  // Title
                            reader.GetString(2),  // Author
                            reader.GetInt32(3)    // Year
                        )
                        {
                            Id = reader.GetGuid(0) // Id устанавливаем отдельно
                        };

                        books.Add(book); // Добавляем книгу в список
                    }
                }
            }

            return books;
        }
        public void RemoveBook(Guid bookId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                // Запрос для удаления книги по Id
                var command = new NpgsqlCommand("DELETE FROM books WHERE id = @BookId", connection);
                command.Parameters.AddWithValue("@BookId", bookId);

                command.ExecuteNonQuery();  // Выполнение запроса
            }
        }
        public void ExportBooksToJson(string filePath)
        {
            var books = new List<Book>();
            string json = JsonConvert.SerializeObject(books, Formatting.Indented); // Преобразуем список в JSON
            File.WriteAllText(filePath, json); // Записываем в файл
        }
        public void ImportBooksFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var books = new List<Book>();
                string json = File.ReadAllText(filePath); // Читаем JSON из файла
                var importedBooks = JsonConvert.DeserializeObject<List<Book>>(json); // Преобразуем JSON в список книг
                if (importedBooks != null)
                {
                    books.AddRange(importedBooks); // Добавляем книги в существующий список
                }
            }
        }
        // Экспорт в PDF
        public void ExportBooksToPdf(string filePath, List<Book> books)
        {

            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {

                    // Получаем доступ к метаданным документа
                    var docInfo = pdf.GetDocumentInfo();

                    // Устанавливаем метаданные
                    docInfo.SetTitle("Список книг");
                    docInfo.SetAuthor("Your Author Name");
                    docInfo.SetSubject("Список книг в библиотеке");
                    docInfo.SetCreator("Book Manager Application");
                    docInfo.SetKeywords("Books, Library, Export, PDF");

                    // Создаем Document для добавления содержимого
                    var document = new iText.Layout.Document(pdf);

                    // Заголовок PDF документа
                    // Используем шрифт, поддерживающий кириллицу
                    var font = PdfFontFactory.CreateFont("C:/Windows/Fonts/arial.ttf", PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
                    document.Add(new iText.Layout.Element.Paragraph("Список книг").SetFont(font));

                    // Добавление каждой книги в PDF
                    foreach (var book in books)
                    {
                        document.Add(new iText.Layout.Element.Paragraph($"ID: {book.Id}").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph($"Название: {book.Title}").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph($"Автор: {book.Author}").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph($"Год: {book.Year}").SetFont(font));
                        document.Add(new iText.Layout.Element.Paragraph("\n").SetFont(font));
                    }

                    // Закрытие документа
                    document.Close();
                }
            }
        }

        // Экспорт в DOCX
        public void ExportBooksToDocx(string filePath, List<Book> books)
        {
            using (var wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                var mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document(new Body());

                var body = mainPart.Document.Body;

                // Заголовок Word документа
                body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Список книг")))); // Явно указываем Open XML для Text

                // Добавление каждой книги в Word документ
                foreach (var book in books)
                {
                    body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text($"ID: {book.Id}"))));
                    body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text($"Название: {book.Title}"))));
                    body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text($"Автор: {book.Author}"))));
                    body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text($"Год: {book.Year}"))));
                    body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text("\n"))));
                }

                wordDoc.Save();
            }
        }
        public List<Book> ImportBooksFromPdf(string filePath)
        {
            List<Book> books = new List<Book>();

            using (PdfReader reader = new PdfReader(filePath))
            {
                using (PdfDocument pdfDoc = new PdfDocument(reader))
                {
                    // Прочитаем все страницы PDF
                    int numPages = pdfDoc.GetNumberOfPages();
                    for (int i = 1; i <= numPages; i++)
                    {
                        var page = pdfDoc.GetPage(i);
                        var text = PdfTextExtractor.GetTextFromPage(page);

                        // Разделяем текст на строки
                        var lines = text.Split('\n');

                        Book book = null;

                        // Допустим, что формат текста всегда одинаковый
                        foreach (var line in lines)
                        {
                            if (line.Contains("ID:"))
                            {
                                book = new Book("", "", 0); // Инициализация с пустыми значениями

                                // Преобразуем строку в Guid, используя Guid.Parse
                                var idString = line.Replace("ID:", "").Trim();
                                if (Guid.TryParse(idString, out Guid id))
                                {
                                    book.Id = id;
                                }
                                else
                                {
                                    // Если преобразование не удалось, обрабатываем ошибку (например, можно записать в лог)
                                    book.Id = Guid.Empty; // Можно присвоить пустой Guid
                                }
                            }
                            else if (line.Contains("Название:") && book != null)
                            {
                                book.Title = line.Replace("Название:", "").Trim();
                            }
                            else if (line.Contains("Автор:") && book != null)
                            {
                                book.Author = line.Replace("Автор:", "").Trim();
                            }
                            else if (line.Contains("Год:") && book != null)
                            {
                                if (int.TryParse(line.Replace("Год:", "").Trim(), out int year))
                                {
                                    book.Year = year;
                                }

                                books.Add(book);
                                book = null; // Сброс после добавления книги
                            }
                        }
                    }
                }
            }

            return books;
        }
        public List<Book> ImportBooksFromDocx(string filePath)
        {
            List<Book> books = new List<Book>();

            // Открываем документ DOCX
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, false))
            {
                // Получаем тело документа
                Body body = wordDocument.MainDocumentPart.Document.Body;

                Book book = null;

                // Проходим по каждому параграфу в документе
                foreach (var paragraph in body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>())
                {
                    // Получаем текст из параграфа
                    string text = paragraph.InnerText.Trim();

                    // Проверка на наличие ключевых слов для поиска
                    if (text.Contains("ID:"))
                    {
                        book = new Book("", "", 0); // Инициализация книги с пустыми значениями

                        // Извлекаем ID
                        var idString = text.Replace("ID:", "").Trim();
                        if (Guid.TryParse(idString, out Guid id))
                        {
                            book.Id = id;
                        }
                        else
                        {
                            // Если ID не удалось разобрать, записываем пустой Guid
                            book.Id = Guid.Empty;
                        }
                    }
                    else if (text.Contains("Название:") && book != null)
                    {
                        // Извлечение названия книги
                        book.Title = text.Replace("Название:", "").Trim();
                    }
                    else if (text.Contains("Автор:") && book != null)
                    {
                        // Извлечение автора книги
                        book.Author = text.Replace("Автор:", "").Trim();
                    }
                    else if (text.Contains("Год:") && book != null)
                    {
                        // Извлечение года
                        if (int.TryParse(text.Replace("Год:", "").Trim(), out int year))
                        {
                            book.Year = year;
                        }

                        // Добавляем книгу в список
                        books.Add(book);
                        book = null;  // Сброс книги после добавления
                    }
                }
            }

            // Возвращаем список книг
            return books;
        }
        public void ConvertFile(string inputFilePath, string outputFilePath)
        {
            if (Path.GetExtension(inputFilePath).ToLower() == ".pdf")
            {
                var books = ImportBooksFromPdf(inputFilePath);
                ExportBooksToDocx(outputFilePath, books);
            }
            else if (Path.GetExtension(inputFilePath).ToLower() == ".docx")
            {
                var books = ImportBooksFromDocx(inputFilePath);
                ExportBooksToPdf(outputFilePath, books);
            }
            else
            {
                throw new NotSupportedException("Формат файла не поддерживается для конвертации.");
            }
        }
        private void ConvertDocument()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Supported Files|*.pdf;*.docx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFilePath = openFileDialog.FileName;

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = inputFilePath.EndsWith(".pdf")
                            ? "Word Document|*.docx"
                            : "PDF File|*.pdf";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string outputFilePath = saveFileDialog.FileName;
                            try
                            {
                                ConvertFile(inputFilePath, outputFilePath);
                                MessageBox.Show("Конвертация завершена!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка конвертации: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
    }
}
