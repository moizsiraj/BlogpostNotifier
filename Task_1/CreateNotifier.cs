using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1 {
    class CreateNotifier : IObserver {
        public void Update(ISubject subject) {
            if (subject is BlogPost post) {
                Console.WriteLine(String.Format("Blogpost {{0}} has been created"), post.Text);
            }
            else if (subject is Blog blog) {
                Console.WriteLine(String.Format("New post has been added to {{0}}'s blog! "), blog.User);
            }
        }
    }
}

