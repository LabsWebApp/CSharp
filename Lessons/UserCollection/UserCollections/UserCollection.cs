using System.Collections;

namespace Enumerations.UserCollections;

// Класс UserCollection коллекция (набор) объектов класса Element.
// Для применения foreach, необходимо, чтобы класс
//      - реализовывал интерфейс - IEnumerator.
//      - имел метод - GetEnumerator(), к-ый возвращает IEnumerator -> (this)
public class UserCollection //: IEnumerable, IEnumerator
{
    private readonly Element[] _elementsArray;

    public UserCollection()
    {
        _elementsArray = new Element[4];
        _elementsArray[0] = new Element("A", 1, 10);
        _elementsArray[1] = new Element("B", 2, 20);
        _elementsArray[2] = new Element("C", 3, 30);
        _elementsArray[3] = new Element("D", 4, 40);
    }

    // Указатель текущей позиции элемента в массиве.
    private int _position = -1;

    // ------------------------------------------------------------------------------------------------------------------
    // Реализация интерфейса IEnumerator.

    // Передвинуть внутренний указатель (position) на одну позицию.
    public bool MoveNext()
    {
        if (_position < _elementsArray.Length - 1)
        {
            _position++;
            return true;
        }
        else
        { 
            return false;
        }
    }

    // Установить указатель (position) перед началом набора.
    public void Reset()
    {
        _position = -1;
    }

    // Получить текущий элемент набора. 
    public object Current => _elementsArray[_position];

    // -----------------------------------------------------------------------------------------------------------------
    // Реализация интерфейса - IEnumerable.

    //IEnumerator IEnumerable.GetEnumerator() => this;

    public UserCollection GetEnumerator() => this;
}