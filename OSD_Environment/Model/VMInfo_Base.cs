namespace OSD_Environment
{
    public abstract class VMInfo_Base
    {
        public string Name {get;set;}
        public string OSName {get;set;}
        public string StoragePath {get;set;}
        public string VHDPath {get;set;}
        public string Description {get;set;}
        public int MemorySize{get;set;}
    }
}