using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTODOclone.Helpers {
    // https://kudchikarsk.github.io/publish-subscribe-design-pattern-in-csharp/
    public class PubSub {
        private static PubSub instance;

        private PubSub() { }

        public static PubSub Instance {
            get {
                if (instance == null) {
                    instance = new PubSub();
                }
                return instance;
            }
        }
        //Subscribe property containing all the 
        //list of subscribers callback methods
        public event Action Subscribe = delegate { };

        public void Publish() {
            //Invoke OnChange Action
            Subscribe();
        }
    }
}
