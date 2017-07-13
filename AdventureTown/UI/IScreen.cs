using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI
{
    public interface IScreen
    {
        /// <summary>
        /// Steuert den Input welcher der User eingibt.
        /// Dieser wird von jedem Dialog einzeln behandelt.
        /// Wird immer am Ende der GameLoop()-Methode aufgerufen.
        /// </summary>
        /// <param name="input">Input des Users</param>
        /// <returns>Meldung, welche als Information auf dem Bildschirm angezeigt werden soll.</returns>
        string HandleInput(ConsoleKeyInfo input);
        void OnLoad();
        void Render();
        void OnClose();
    }
}
