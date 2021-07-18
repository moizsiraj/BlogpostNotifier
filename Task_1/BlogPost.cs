using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1 {
    class BlogPost : ISubject{

        private List<IObserver> _Observers;

        public BlogPost(int id, string text) {
            _Id = id;
            _Text = text;
            _Observers = new List<IObserver>();
            IObserver createNotifier = new CreateNotifier();
            IObserver updateNotifier = new UpdateNotifier();
            IObserver deleNotifier = new DeleteNotifier();
            Register(createNotifier);
            Register(updateNotifier);
            Register(deleNotifier);
            Notify(createNotifier);
        }

        private int _Id;

        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Text;

        public string Text {
            get { return _Text; }
            set { _Text = value; }
        }

        public void EditPost(string text) {
            _Text = text;
            foreach (IObserver observer in _Observers) {
                if (observer is UpdateNotifier updateNotifier) {
                    Notify(updateNotifier);
                }
            }
        }

        public void DeletePost() {
            foreach (IObserver observer in _Observers) {
                if (observer is DeleteNotifier deleteNotifier) {
                    Notify(deleteNotifier); 
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
