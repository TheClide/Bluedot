﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluedot.HabboServer.Habbos;
using Bluedot.HabboServer.Network;
using Nito.Async;

namespace Bluedot.HabboServer.ApiUsage.Packets
{
    public static partial class PacketHandlers
    {
        public static void Start()
        {
            CoreManager.ServerCore.GameSocketManager.OnPostIncomingConnection += RegisterLoginHandlers;
            Habbo.OnAnyLogin += SendAuthenticationOkay;
            Habbo.OnAnyLogin += RegisterHabboHandlers;
        }

        private static void RegisterLoginHandlers(object source, GameSocketConnectionEventArgs args)
        {
            args.Socket.PacketHandlers[206, GameSocketMessageHandlerPriority.DefaultAction] += ProcessEncryptionRequest;
            args.Socket.PacketHandlers[2002, GameSocketMessageHandlerPriority.DefaultAction] += ProcessSessionRequest;
            args.Socket.PacketHandlers[204, GameSocketMessageHandlerPriority.DefaultAction] += ProcessSSOTicket;
        }
        private static void RegisterHabboHandlers(object source, HabboEventArgs args)
        {
            (source as Habbo).Socket.PacketHandlers[6, GameSocketMessageHandlerPriority.DefaultAction] += ProcessBalanceRequest;
            (source as Habbo).Socket.PacketHandlers[7, GameSocketMessageHandlerPriority.DefaultAction] += ProcessHabboInfoRequest;
            (source as Habbo).Socket.PacketHandlers[8, GameSocketMessageHandlerPriority.DefaultAction] += ProcessGetVolumeLevel;
        }
    }
}