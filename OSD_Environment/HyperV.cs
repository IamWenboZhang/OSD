using System;
using OSD_Utility;

namespace OSD_Environment
{
    public class HyperV
    {
        public bool CreateVM(VMInfo_Base vm)
        {
            // New-VM -MemoryStartupBytes 2GB -Name PowerShellCreated -Path I:\v-wenbo
            // New-VHD -Path I:\v-wenbo\pwdtest.vhdx -SizeBytes 100GB -Dynamic
            // Add-VMHardDiskDrive -VMName PowerShellCreated -Path I:\v-wenbo\pwdtest.vhdx
            // Set-VMDvdDrive -VMName PowerShellCreated -ControllerNumber 1 -Path "E:\ISO-20H2-ESRP-Build\19042.508.200907-1718.20h2_release_svc_refresh_CLIENT_CONSUMER_x64FRE_en-gb.iso"
            // Start-VM -Name PowerShellCreated
            string memory_info = vm.MemorySize + "MB";
            string newVMCmd = $"New-VM -MemoryStartupBytes {memory_info} -Name {vm.Name} -Path {vm.StoragePath}";
            PowerShellHelper.RunScript("");
            return true;
        }
    }
}
