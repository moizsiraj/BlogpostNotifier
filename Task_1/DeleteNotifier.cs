using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1 {
    class DeleteNotifier : IObserver {
        public void Update(ISubject subject) {
            if (subject is BlogPost post) {
                Console.WriteLine(String.Format("Blogpost {{0}} has been deleted"), post.Text);
            }
            else if (subject is Blog blog) {
                Console.WriteLine(String.Format("A post has been deleted from {{0}}'s blog! "), blog.User);
            }
        }
    }
}
