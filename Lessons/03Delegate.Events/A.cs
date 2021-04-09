using System;

namespace Delegate.Events
{
    public class A
    {
        public event Action ActionEvent;

        private string prop;
        public string Prop
        {
            set
            {
                prop = value;
                ActionEvent?.Invoke();
            }
        }
    }
}
