using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
    }

    public class Reader
    {
        public int ReaderId { get; set; }
        public string  ReaderName { get; set; }
        public string ReaderContact { get; set; }
    }

    public interface IRepository<T> where T:class
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
    }

    public class AuthorRepository: IRepository<Author>
    {
        List<Author> _dbContext;

        public AuthorRepository()
        {
            _dbContext = new List<Author>();
        }

        public IEnumerable<Author> List
        {
            get
            {
                return _dbContext;
            }
        }


        public void Add(Author entity)
        {

            _dbContext.Add(entity);
        }

        public void Delete(Author entity)
        {
          if(_dbContext.Exists(e=>e.AuthorId==entity.AuthorId))
          {
              _dbContext.Remove(entity);
              Console.WriteLine("Author is deleted sucessfully!!");
          }
          else
          {
              Console.WriteLine("Author is not found");
          }
        }
    }
        

    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Author> repo = new AuthorRepository();
            repo.Add(new Author() { AuthorId = 11, AuthorName = "harshal", AuthorEmail = "harsh@df.df" });
            repo.Add(new Author() { AuthorId = 12, AuthorName = "jay ", AuthorEmail = "jay@df.com" });
            repo.Add(new Author() { AuthorId = 13, AuthorName = "Vij", AuthorEmail = "vijay@df.jp" });

            foreach (var item in repo.List)
            {
                Console.WriteLine(item.AuthorId +" - "+item.AuthorName+" - "+item.AuthorEmail);
            }
            Console.WriteLine(  "----------------------------------------------------------------------\n");
            repo.Delete(new Author() { AuthorId = 12, AuthorName = "jay ", AuthorEmail = "jay@df.com" });

            foreach (var item in repo.List)
            {
                Console.WriteLine(item.AuthorId + " - " + item.AuthorName + " - " + item.AuthorEmail);
            }
        }
    }
}
