﻿#region GPLv3

// 
// Copyright (C) 2012  Chris Chenery
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General internal License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General internal License for more details.
// 
// You should have received a copy of the GNU General internal License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

#endregion

#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Bluedot.HabboServer.Install
{
    internal class StringStep : Step
    {
        private string _default;

        internal StringStep(string title = "", string description = "", ICollection<string> examples = null,
                          string @default = "")
        {
            Title = title;
            Description = description;
            Examples = examples;
            _default = @default;
        }

        internal StringStep SetDefault(string @default)
        {
            _default = @default;
            return this;
        }

        internal override object Run()
        {
            CoreManager.InstallerCore.Out.OverwritePageContents(ToString(_default));

            string inputValue = Console.ReadLine();
            return (inputValue.Length == 0 ? _default : inputValue);
        }
    }
}