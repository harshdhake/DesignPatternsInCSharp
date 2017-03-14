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

    public class IAuthorRepository: IRepository<Author>
    {
        List<Author> _dbContext;

        public IAuthorRepository()
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


        }
    }
}
