using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTODOclone.Helpers {
    public class StoreState {
        private static StoreState instance;
        private Dictionary<string, object> _store;

        public static StoreState Instance {
            get {
                if (instance == null) {
                    instance = new StoreState();
                }
                return instance;
            }
        }

        private StoreState() {
            _store = new Dictionary<string, object>();
        }

        public void Store(string key, object value) {
            _store.Add(key, value);
        }

        public object Retrive(string key) {
            return _store.GetValueOrDefault(key);
        }
    }
}
