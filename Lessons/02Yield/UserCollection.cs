using System.Collections;

namespace Yield;

class UserCollection
{
    public static IEnumerable Power() => new ClassPower(-2);

    private sealed class ClassPower :
        IEnumerable<object>,
        IEnumerator<object>,
        IEnumerator,
        IDisposable
    {
        // Поля.
        private int _state;
        private object _current;
        
        // Свойства.
        object IEnumerator<object>.Current => null;
        object IEnumerator.Current => _current;
        
        // Конструктор.
        public ClassPower(int state) => _state = state;

        bool IEnumerator.MoveNext()
        {
            switch (_state)
            {
                case 0:
                    _state = -1;
                    _current = "Привет, Петя!";
                    _state = 1;
                    return true;
                case 1:
                    _state = -1;
                    _current = "Привет, Маша!";
                    _state = 2;
                    return true;
                case 2:
                    _state = -1;
                    _current = 99;
                    _state = 2;
                    return true;
                case 3:
                    _state = -1;
                    break;
            }
            return false;
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            if (_state == -2)
            {
                _state = 0;
                return this;
            }
            return new ClassPower(0);
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            (this as IEnumerable<object>).GetEnumerator();

        void IEnumerator.Reset()
        {
            throw new NotSupportedException();
        }

        void IDisposable.Dispose() { }
    }
}