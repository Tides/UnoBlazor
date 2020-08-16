using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using UnoBlazor.Shared.Utils;

namespace UnoBlazor.Shared.Entities
{
    public class Lobby
    {
        /// <summary>
        /// Id of the lobby
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The lobby owners id
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Name of the lobby
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Password of the lobby
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The amount of players that are allowed to join
        /// </summary>
        public int MaxPlayers { get; set; }

        /// <summary>
        /// The current state of the lobby
        /// </summary>
        public LobbyState State { get; set; }

        /// <summary>
        /// Currently connected players
        /// </summary>
        [JsonIgnore]
        public Dictionary<Guid, Player> ConnectedPlayers { get; } = new Dictionary<Guid, Player>();

        /// <summary>
        /// Returns true if the lobby has a password
        /// </summary>
        [JsonIgnore]
        public bool Locked => this.Password != null;

        /// <summary>
        /// Lobbies message history
        /// </summary>
        /// ...?
        public List<string> MessageHistory { get; set; } = new List<string>();

        public Player GetPlayer(Guid id) => this.ConnectedPlayers.GetValueOrDefault(id);

        public void AddPlayer(Player user) => this.ConnectedPlayers.Add(user.Id, user);

        public void AddPlayer(string name)
        {
            var player = new Player
            {
                Username = name
            };
            this.ConnectedPlayers.Add(player.Id, player);
        }

        public bool RemovePlayer(Guid id) => this.ConnectedPlayers.Remove(id);

        public void ChangePlayerStatus(Guid id, PlayerStatus newStatus)
        {
            var user = this.ConnectedPlayers.GetValueOrDefault(id);

            if (user == null)
                throw new NullReferenceException(nameof(user));

            this.ConnectedPlayers[id].Status = newStatus;
        }
    }

    public enum LobbyState
    {
        InLobby,

        InGame,

        Finished
    }
}
