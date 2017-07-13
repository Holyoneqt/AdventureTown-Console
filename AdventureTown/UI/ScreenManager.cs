using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureTown.UI.Screens;

namespace AdventureTown.UI
{
    public class ScreenManager
    {
        private static ScreenManager _instance = null;

        private IScreen _screen = null;
        private Stack<IScreen> _lastScreens;

        private ScreenManager()
        {
            _lastScreens = new Stack<IScreen>();
            ChangeScreen(ScreenContainer.Town);
        }

        public void ChangeScreen(IScreen nextScreen)
        {
            ChangeScreen(nextScreen, true);
        }

        public void ChangeScreen(IScreen nextScreen, bool pushToStack)
        {
            if (_screen != null && pushToStack)
            {
                _screen.OnClose();
                _lastScreens.Push(_screen);
            }

            _screen = nextScreen;

            _screen.OnLoad();
        }

        public void Render()
        {
            Console.Clear();
            _screen.Render();
        }

        public string HandleInput(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Q)
            {
                BackToLastScreen();
                return "";
            }
            else
                return _screen.HandleInput(input);
        }

        private void BackToLastScreen()
        {
            if(_lastScreens.Count != 0)
            {
                IScreen lastScreen = _lastScreens.Pop();
                ChangeScreen(lastScreen, false);
            }
        }

        public static ScreenManager GetInstance()
        {
            if (_instance == null)
                _instance = new ScreenManager();
            return _instance;
        }

    }
}
