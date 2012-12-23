﻿#region GPLv3

// 
// Copyright (C) 2012  Chris Chenery
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

#endregion

using Bluedot.HabboServer.Network;

namespace Bluedot.HabboServer.ApiUsage.Packets
{
    public class MVolumeLevel : OutgoingMessage
    {
        private byte _volume;
        public byte Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value > 100)
                    _volume = 100;
                else
                    _volume = value;
            }
        }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.Id == 0)
            {
                InternalOutgoingMessage.Initialize(308).
                    AppendInt32(Volume);
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}