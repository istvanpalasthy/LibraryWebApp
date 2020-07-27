using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using LibraryWebApp.Domain;

namespace LibraryWebApp.Services
{
    public class DataBaseService : IDataBaseService
    {
        private static readonly string _conn = Program.ConnectionString;
        private static NpgsqlConnection conn = new NpgsqlConnection(_conn);

        public List<Books> GetAllBook()
        {
            List<Books> allBook = new List<Books>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Books", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int book_id = int.Parse(reader["book_id"].ToString());
                        string Book_Title = reader["Book_Title"].ToString();
                        string Book_Author = reader["Book_Author"].ToString();
                        string lang = reader["Lang"].ToString();
                        int No_Copies_Actual = int.Parse(reader["No_Copies_Actual"].ToString());
                        int No_Copies_Current = int.Parse(reader["No_Copies_Current"].ToString());
                        int Publication_year = int.Parse(reader["Publication_year"].ToString());
                        Books books = new Books(book_id, Book_Title, Book_Author, lang, No_Copies_Actual, No_Copies_Current, Publication_year);
                        allBook.Add(books);
                    }

                }
            }

            return allBook;


        }

        public List<Books> GetThreeBook()
        {
            List<Books> threebook = new List<Books>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Books", conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int book_id = int.Parse(reader["book_id"].ToString());
                        string Book_Title = reader["Book_Title"].ToString();
                        string Book_Author = reader["Book_Author"].ToString();
                        string lang = reader["Lang"].ToString();
                      
                        Books books = new Books( book_id,Book_Title, Book_Author, lang);
                        threebook.Add(books);
                    }

                }
            }

            return threebook;


        }
        public List<MemberRecord> GetAllUser()
        {
            List<MemberRecord> allUser = new List<MemberRecord>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM MemberRecord", conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string User_Idint = reader["User_Idint"].ToString();
                        string User_Name = reader["User_Name"].ToString();
                        string pw = reader["pw"].ToString();
                        MemberRecord books = new MemberRecord(User_Idint, User_Name, pw);
                        allUser.Add(books);
                    }

                    return allUser;

                }
            }
        }
        public MemberRecord GetOneUser(string user_name)
        {
            using (var conn = new NpgsqlConnection(_conn))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM MemberRecord WHERE User_Name = (@user_name) ", conn))
                {
                    cmd.Parameters.AddWithValue("@user_name",user_name);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int user_id = int.Parse(reader["User_Idint"].ToString());
                        string User_Name = reader["User_Name"].ToString();
                        string pw = reader["pw"].ToString();
                        return new MemberRecord(user_id,User_Name, pw);
                    }
                }

            }
            return null;
            }
        
        public void LinkBookToProfile(int book_id, int user_id)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT into Transactions (User_Idint,book_id) VALUES((@user_id),(@book_id))", conn))
                {
                    cmd.Parameters.AddWithValue("user_id", user_id);
                    cmd.Parameters.AddWithValue("book_id", book_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Books> BookOnProfile(int user_id)
        {
            List<Books> returnbook = new List<Books>();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT Transactions.book_id,Book_title, Book_Author,Lang from Transactions INNER JOIN  Books ON Transactions.book_id = Books.book_id where User_Idint = (@user_id) ", conn))
                {
                    cmd.Parameters.AddWithValue("user_id", user_id);
                    cmd.ExecuteNonQuery();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        int book_id = int.Parse(reader["book_id"].ToString());
                        string author = reader["Book_Author"].ToString();
                        string title = reader["Book_title"].ToString();
                        string lang = reader["Lang"].ToString();
                        Books sanyika = new Books(book_id,author,title,lang);
                        returnbook.Add(sanyika);


                    }
                }
                return returnbook;
            }
        }




        public void AddBooks(string book_title, string book_author, string lang)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO Books(Book_Title, Book_Author, Lang) VALUES(@book_title, @book_author, @lang)", conn))
                {
                    cmd.Parameters.AddWithValue("Book_Title", book_title);
                    cmd.Parameters.AddWithValue("Book_Author", book_author);
                    cmd.Parameters.AddWithValue("Lang", lang);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddUsers(string user_name, string pw)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO MemberRecord(User_Name,pw) VALUES(@user_name, @pw)", conn))
                {
                    cmd.Parameters.AddWithValue("User_Name", user_name);
                    cmd.Parameters.AddWithValue("pw", pw);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void ModifyBook(string realbooktitle, string book_title, string book_author, string lang)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE Books SET Book_Title = @book_title, Book_Author = @book_author,  Lang = @lang WHERE @realbooktitle = Book_Title", conn))
                {
                    cmd.Parameters.AddWithValue("realbooktitle", realbooktitle);
                    cmd.Parameters.AddWithValue("book_title", book_title);
                    cmd.Parameters.AddWithValue("book_author", book_author);
                    cmd.Parameters.AddWithValue("lang", lang);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFromProfile(int book_id)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM Transactions WHERE  book_id = @book_id", conn))
                {
                    cmd.Parameters.AddWithValue("book_id", book_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(int book_id)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Program.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM Books WHERE  book_id = @book_id", conn))
                    {
                        cmd.Parameters.AddWithValue("book_id", book_id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

               
            }
        }
        

        public MemberRecord Login(string user_name, string pw)
        {
            var user = GetOneUser(user_name);
            if (user == null)
            {
                return null;
            }
            else if (user.pw != pw)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
    }
}








