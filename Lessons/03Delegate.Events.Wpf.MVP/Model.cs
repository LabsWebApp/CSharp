namespace Delegate.Events.Wpf.MVP;

class Model
{
    public string Logic(string s)
    {
        // что-то тут считаем, сохраняем, удаляем и тд
        // *****
        return $"Работа: Model.Logic({s})";
    }
}