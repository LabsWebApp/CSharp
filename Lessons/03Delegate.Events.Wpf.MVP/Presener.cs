using System;

namespace Delegate.Events.Wpf.MVP;

class Presenter
{
    private readonly MainWindow _mainWindow;
    private readonly Model _model;

    public Presenter(MainWindow mainWindow)
    {
        this._mainWindow = mainWindow;
        this._model = new Model();
        this._mainWindow.DoItButtonClickEvent += new EventHandler(MainWindow_myEvent);
    }

    private void MainWindow_myEvent(object? sender, System.EventArgs _)
    {
        var variable = _model.Logic(this._mainWindow.TextBox.Text);

        this._mainWindow.TextBox.Text = variable;
    }
}