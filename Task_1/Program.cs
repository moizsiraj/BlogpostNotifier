using System;

namespace Task_1 {
    class Program {
        static void Main(string[] args) {
            Blog blog = new("Moiz");
            blog.CreateBlogPost("Hello");
            Console.WriteLine("Edit Post: Input text");
            blog.EditPost(1);
            blog.CreateBlogPost("Hi");
            blog.DeletePost(1);
            Console.WriteLine("Edit Post: Input text");
            blog.EditPost(2);
            blog.DeletePost(2);
        }
    }
}
