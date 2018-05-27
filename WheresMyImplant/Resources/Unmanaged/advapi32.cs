﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace Unmanaged
{
    sealed class advapi32
    {
        [DllImport("advapi32.dll")]
        public static extern Boolean AdjustTokenPrivileges(
            IntPtr TokenHandle,
            Boolean DisableAllPrivileges,
            ref Winnt._TOKEN_PRIVILEGES NewState,
            UInt32 BufferLengthInBytes,
            ref Winnt._TOKEN_PRIVILEGES PreviousState,
            out UInt32 ReturnLengthInBytes
        );

        [Flags]
        public enum LOGON_FLAGS
        {
            WithProfile = 1,
            NetCredentialsOnly
        }

        [DllImport("advapi32.dll")]
        public static extern Boolean AllocateAndInitializeSid(
            ref Winnt._SID_IDENTIFIER_AUTHORITY pIdentifierAuthority,
            byte nSubAuthorityCount,
            Int32 dwSubAuthority0,
            Int32 dwSubAuthority1,
            Int32 dwSubAuthority2,
            Int32 dwSubAuthority3,
            Int32 dwSubAuthority4,
            Int32 dwSubAuthority5,
            Int32 dwSubAuthority6,
            Int32 dwSubAuthority7,
            out IntPtr pSid
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern IntPtr CreateService(
            IntPtr hSCManager,
            String lpServiceName,
            String lpDisplayName,
            Winsvc.dwDesiredAccess dwDesiredAccess,
            Winsvc.dwServiceType dwServiceType,
            Winsvc.dwStartType dwStartType,
            Winsvc.dwErrorControl dwErrorControl,
            String lpBinaryPathName,
            String lpLoadOrderGroup,
            String lpdwTagId,
            String lpDependencies,
            String lpServiceStartName,
            String lpPassword
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean CloseServiceHandle(IntPtr hSCObject);

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern IntPtr ControlService(IntPtr hService, Winsvc.dwControl dwControl, out Winsvc._SERVICE_STATUS lpServiceStatus);

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern IntPtr ControlServiceEx(IntPtr hService, Winsvc.dwControl dwControl, Int32 dwInfoLevel, out Winsvc._SERVICE_STATUS lpServiceStatus);

        [DllImport("advapi32.dll")]
        public static extern Boolean CreateProcessAsUser(IntPtr hToken, IntPtr lpApplicationName, IntPtr lpCommandLine, ref Winbase._SECURITY_ATTRIBUTES lpProcessAttributes, ref Winbase._SECURITY_ATTRIBUTES lpThreadAttributes, Boolean bInheritHandles, Winbase.CREATION_FLAGS dwCreationFlags, IntPtr lpEnvironment, IntPtr lpCurrentDirectory, ref Winbase._STARTUPINFO lpStartupInfo, out Winbase._PROCESS_INFORMATION lpProcessInfo);

        [DllImport("advapi32.dll")]
        public static extern Boolean CreateProcessAsUserW(IntPtr hToken, IntPtr lpApplicationName, IntPtr lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, Boolean bInheritHandles, Winbase.CREATION_FLAGS dwCreationFlags, IntPtr lpEnvironment, IntPtr lpCurrentDirectory, ref Winbase._STARTUPINFO lpStartupInfo, out Winbase._PROCESS_INFORMATION lpProcessInfo);

        [DllImport("advapi32.dll")]
        public static extern Boolean CreateProcessWithTokenW(IntPtr hToken, LOGON_FLAGS dwLogonFlags, IntPtr lpApplicationName, IntPtr lpCommandLine, Winbase.CREATION_FLAGS dwCreationFlags, IntPtr lpEnvironment, IntPtr lpCurrentDirectory, ref Winbase._STARTUPINFO lpStartupInfo, out Winbase._PROCESS_INFORMATION lpProcessInfo);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool CreateProcessWithLogonW(
            String userName,
            String domain,
            String password,
            int logonFlags,
            String applicationName,
            String commandLine,
            int creationFlags,
            IntPtr environment,
            String currentDirectory,
            ref Winbase._STARTUPINFO startupInfo,
            out Winbase._PROCESS_INFORMATION processInformation
        );


        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean DeleteService(IntPtr hService);

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean DuplicateTokenEx(IntPtr hExistingToken, UInt32 dwDesiredAccess, IntPtr lpTokenAttributes, Winnt._SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, Winnt.TOKEN_TYPE TokenType, out IntPtr phNewToken);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern Boolean ImpersonateLoggedOnUser(IntPtr hToken);

        [DllImport("advapi32.dll")]
        public static extern Boolean ImpersonateSelf(Winnt._SECURITY_IMPERSONATION_LEVEL ImpersonationLevel);

        [DllImport("advapi32.dll")]
        public static extern Boolean LookupPrivilegeName(
            String lpSystemName,
            IntPtr lpLuid,
            StringBuilder lpName,
            ref Int32 cchName
        );

        [DllImport("advapi32.dll")]
        public static extern Boolean LookupPrivilegeValue(
            String lpSystemName,
            String lpName,
            ref Winnt._LUID luid
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern IntPtr OpenSCManager(String lpMachineName, String lpDatabaseName, Winsvc.dwSCManagerDesiredAccess dwDesiredAccess);

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern IntPtr OpenService(IntPtr hSCManager, String lpServiceName, Winsvc.dwDesiredAccess dwDesiredAccess);

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean StartService(IntPtr hService, Int32 dwNumServiceArgs, String[] lpServiceArgVectors);

        ////////////////////////////////////////////////////////////////////////////////
        // Registry Functions
        ////////////////////////////////////////////////////////////////////////////////
        [DllImport("advapi32.dll", SetLastError=true, CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(
            UIntPtr hKey,
            String subKey,
            Int32 ulOptions,
            Int32 samDesired,
            out UIntPtr hkResult
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern uint RegQueryValueEx(
            UIntPtr hKey,
            String lpValueName,
            Int32 lpReserved,
            ref RegistryValueKind lpType,
            IntPtr lpData,
            ref Int32 lpcbData
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern UInt32 RegQueryValueEx(
            UIntPtr hKey,
            string lpValueName,
            int lpReserved,
            ref Int32 lpType,
            IntPtr lpData,
            ref int lpcbData
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Int32 RegQueryInfoKey(
            UIntPtr hKey,
            StringBuilder lpClass,
            ref UInt32 lpcchClass,
            IntPtr lpReserved,
            out UInt32 lpcSubkey,
            out UInt32 lpcchMaxSubkeyLen,
            out UInt32 lpcchMaxClassLen,
            out UInt32 lpcValues,
            out UInt32 lpcchMaxValueNameLen,
            out UInt32 lpcbMaxValueLen,
            IntPtr lpSecurityDescriptor,
            IntPtr lpftLastWriteTime
        );

        ////////////////////////////////////////////////////////////////////////////////
        // Vault Functions
        ////////////////////////////////////////////////////////////////////////////////
        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean CredEnumerateW(
            String Filter,
            Int32 Flags,
            out Int32 Count,
            out IntPtr Credentials
        );

        public enum CRED_TYPE : uint
        {
            Generic = 1,
            DomainPassword,
            DomainCertificate,
            DomainVisiblePassword,
            GenericCertificate,
            DomainExtended,
            Maximum,
            MaximumEx = Maximum + 1000,
        }

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean CredReadW(
            String target,
            CRED_TYPE type, 
            Int32 reservedFlag, 
            out IntPtr credentialPtr
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean CredWriteW(
            ref WinCred._CREDENTIAL userCredential, 
            UInt32 flags
        );

        [DllImport("advapi32.dll", SetLastError=true)]
        public static extern Boolean CredFree(
            IntPtr Buffer
        );

        [DllImport("advapi32.dll")]
        public static extern Boolean GetTokenInformation(
            IntPtr TokenHandle,
            Winnt._TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            UInt32 TokenInformationLength,
            out UInt32 ReturnLength
        );
    }
} 