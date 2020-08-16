using System;
using System.Text.Json.Serialization;

namespace UnoBlazor.Shared.Entities
{
    public class Player
    {
        /// <summary>
        /// THe id of the player
        /// </summary>
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// The username of the player
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The current player status
        /// </summary>
        public PlayerStatus Status { get; set; } = PlayerStatus.Unknown;

        /// <summary>
        /// The current player connection id 
        /// </summary>
        public string ConnectionId { get; private set; }

        /// <summary>
        /// The current contextId from the players websocket session
        /// </summary>
        public string ContextIdentifier { get; private set; }

        /// <summary>
        /// The lobby the player is currently connection to
        /// returns null if the player is not in any lobby
        /// </summary>
        [JsonIgnore]
        public Lobby Lobby { get; set; }

        public Player SetContextValues(string connectionId, string contextId)
        {
            this.ConnectionId = connectionId;
            this.ContextIdentifier = contextId;
            return this;
        }
    }

    public enum PlayerStatus
    {
        NotReady,

        Ready,

        Waiting,

        Playing,

        Unknown
    }
}
