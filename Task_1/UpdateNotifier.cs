using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1 {
    class UpdateNotifier : IObserver {
        public void Update(ISubject subject) {
            if (subject is BlogPost post) {
                Console.WriteLine(String.Format("Blogpost {{0}} has been updated to {{1}}"), post.Id, post.Text);
            }
            else if (subject is Blog blog) {
                Console.WriteLine(String.Format("A post has been updated on {{0}}'s blog! "), blog.User);
            }
        }
    }
}
