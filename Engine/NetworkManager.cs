using Engine.Enums;
using Engine.Networking;

namespace Engine;

public static class NetworkManager
{
    public static NetworkingKind NetworkingKind { get; private set; } = NetworkingKind.None;
    private static GameServer? _server;
    private static GameClient? _client;

    public static void AsHost()
    {
        NetworkingKind = NetworkingKind.Server;
    }

    public static void AsClient()
    {
        NetworkingKind = NetworkingKind.Client;
    }
}
