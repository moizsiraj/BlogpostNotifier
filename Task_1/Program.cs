using System;

namespace Task_1 {
    class Program {
        static void Main(string[] args) {
            Blog blog = new("Moiz");
            blog.CreateBlogPost("Hello");
            blog.EditPost(1);
            blog.DeletePost(1);
        }
    }
}
