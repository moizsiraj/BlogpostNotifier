using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1 {
    class Blog : ISubject {

        private List<IObserver> _Observers;
        private List<BlogPost> _BlogPosts;

        private string _User;

        public string User {
            get { return _User; }
            set { _User = value; }
        }


        public Blog(string user) {
            _User = user;
            _Observers = new List<IObserver>();
            _BlogPosts = new List<BlogPost>();
            CreateNotifier createNotifier = new();
            UpdateNotifier updateNotifier = new();
            DeleteNotifier deleteNotifier = new();
            Register(createNotifier);
            Register(updateNotifier);
            Register(deleteNotifier);
        }

        public void CreateBlogPost(string text) {
            
            foreach (IObserver observer in _Observers) {
                
                if (observer is CreateNotifier createNotifier) {
                    Notify(createNotifier);
                }
            }
            
            int id = _BlogPosts.Count + 1;
            BlogPost blogPost = new(id, text);
            _BlogPosts.Add(blogPost);
        }


        private BlogPost GetBlogPostById(int id) {
            for (int i = 0; i < _BlogPosts.Count; i++) {

                if (_BlogPosts[i].Id == id) {

                    return _BlogPosts[i];
                }
            }

            return null;

        }


        public void DeletePost(int id) {

            
            BlogPost blogPost = GetBlogPostById(id);
            if (blogPost is BlogPost post) {
                post.DeletePost();
                _BlogPosts.Remove(post);
                post = null;
                GC.Collect();

                foreach (IObserver observer in _Observers) {
                    if (observer is DeleteNotifier deleteNotifier) {
                        Notify(deleteNotifier);
                    }
                }
            }

        }

        public void EditPost(int id) {
            
            BlogPost blogPost = GetBlogPostById(id);
            if (blogPost is BlogPost post) {
                string text = Console.ReadLine();
                post.EditPost(text);

                foreach (IObserver observer in _Observers) {
                    if (observer is UpdateNotifier updateNotifier) {
                        Notify(updateNotifier);
                    }
                }
            }
            
        }

        public void Register(IObserver observer) {
            _Observers.Add(observer);
        }

        public void Notify(IObserver observer) {
            observer.Update(this);
        }

    }
}
