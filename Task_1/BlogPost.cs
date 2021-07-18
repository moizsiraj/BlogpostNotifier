using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1 {
    class BlogPost {

        public BlogPost(int id, string text) {
            
            _Id = id;
            _Text = text;
 
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
        }

        public static void DeletePost(BlogPost blogPost) {
            blogPost = null;
        }


    }
}
