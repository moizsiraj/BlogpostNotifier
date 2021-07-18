using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1 {
    interface ISubject {

        public void Register(IObserver observer);

        public void Notify(IObserver observer);


    }
}
