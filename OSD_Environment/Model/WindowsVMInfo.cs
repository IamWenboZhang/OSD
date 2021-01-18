using System;

namespace OSD_Environment
{
    public class WindowsVMInfo: OSD_Environment.VMInfo_Base
    {
        public void GetMemory(string memory_info)
        {
            int size = -1;
            if (memory_info.Contains("GB"))
            {
               var tmp = memory_info.Split("GB".ToCharArray());
               size = Convert.ToInt32(tmp[0].Trim());
               size = size * 1024;
               if (size > 0)
               {                   
                    this.MemorySize = size;
               }
            }
            else if (memory_info.Contains("MB"))
            {
                var tmp = memory_info.Split("MB".ToCharArray());
                size = Convert.ToInt32(tmp[0].Trim());
                if (size > 0)
                {                   
                        this.MemorySize = size;
                }
            }
            else if (int.TryParse(memory_info,out size))
            {
                 if (size > 0)
                {                   
                        this.MemorySize = size;
                }
            }
        }
        
    }

}