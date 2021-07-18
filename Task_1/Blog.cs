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
            DeleteNotifier deleteNotifier = new();
            Register(createNotifier);
            Register(deleteNotifier);
        }

        public void CreateBlogPost(string text) {
            
            foreach (IObserver observer in _Observers) {
                
                if (observer is CreateNotifier createNotifier) {
                    createNotifier.Update(this);
                }
            }
            
            int id = _BlogPosts.Count + 1;
            BlogPost blogPost = new(id, text);
            _BlogPosts.Add(blogPost);
        }


        public void DeletePost(int id) {

            for (int i = 0; i < _BlogPosts.Count; i++) {
                
                if (_BlogPosts[i].Id == id) {
                    
                    BlogPost blogPost = _BlogPosts[i];
                    blogPost.DeletePost();
                    _BlogPosts.Remove(blogPost);
                    blogPost = null;
                    GC.Collect();
                    
                    foreach (IObserver observer in _Observers) {
                        if (observer is DeleteNotifier deleteNotifier) {
                            deleteNotifier.Update(this);
                        }
                    }
                    break;
                }
            }
        }

        public void EditPost(int id) {
            for (int i = 0; i < _BlogPosts.Count; i++) {

                if (_BlogPosts[i].Id == id) {

                    BlogPost blogPost = _BlogPosts[i];
                    string text = Console.ReadLine();
                    blogPost.EditPost(text);
                    
                    foreach (IObserver observer in _Observers) {
                        if (observer is UpdateNotifier updateNotifier) {
                            updateNotifier.Update(this);
                        }
                    }
                    break;
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
