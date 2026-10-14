using System;

namespace Demo_CSharp
{
    public class SemacTerminal
    {
        public string ReaderCode { get; set; }
        public string ChannelID { get; set; }
        public int TerminalID { get; set; }
        public string IPAddress { get; set; }
        public string Location { get; set; }
        public bool IsConnected { get; set; }
        public DateTime? LastSyncedOn { get; set; }
        public string LastError { get; set; }
    }
}