using System;
using UnoBlazor.Shared.Entities;

namespace UnoBlazor.Shared
{
    public class AppState : IDisposable
    {
        public event Action OnChange;

        public Player CurrentUser { get; private set; }

        public Lobby CurrentLobby { get; private set; }

        public void SetCurrentUser(Player user)
        {
            this.CurrentUser = user;
            this.StateHasChanged();
        }

        public void SetCurrentLobby(Lobby lobby)
        {
            this.CurrentLobby = lobby;
            this.StateHasChanged();
        }

        public void ChangePlayerStatus(Guid userId, PlayerStatus newStatus)
        {
            this.CurrentLobby.ChangePlayerStatus(userId, newStatus);

            this.StateHasChanged();
        }

        private void StateHasChanged() => this.OnChange?.Invoke();

        public void Dispose()
        {
            this.CurrentUser = null;
            this.CurrentLobby = null;
            this.OnChange = null;
        }
    }
}
