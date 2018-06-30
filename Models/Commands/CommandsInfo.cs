using System;

namespace ManchkinGameApi.Models.Commands
{
    public static partial class CommandsInfo{
        public static readonly CommandInfo Hello = new CommandInfo(){Command="/hello",StateAllow=0b1111_1111,Name="hello"};
        public static readonly CommandInfo EndGame = new CommandInfo(){Command="/EndGame",StateAllow=0b1111_1111,Name="EndGame"};
        public static readonly CommandInfo NewGame = new CommandInfo(){Command="/NewGame",StateAllow=0b1111_1111,Name="NewGame"};
        public static readonly CommandInfo StarGame = new CommandInfo(){Command="/StarGame",StateAllow=0b0000_0001,Name="StarGame"};
        public static readonly CommandInfo TakeInGamePlace = new CommandInfo(){Command="/TakeInGamePlace",StateAllow=0b000_0001,Name="TakeInGamePlace"};
    }

    public class CommandInfo
    {
        public string Command;
        public string Name;
        public byte StateAllow;
        
    }
}