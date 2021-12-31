Namespace CS
    Namespace System

        Public Module Management

            ''' <summary>
            ''' The shutdown type. This parameter must include one of the following values. Optionally include one of the Force flags.
            ''' </summary>
            Public Enum ExitWindowsFlags As Integer
                HybridShutdown = &H400000
                Logoff = &H0
                Poweroff = &H8
                Reboot = &H2
                RestartApps = &H40
                Shutdown = &H1
                Force = &H4
                ForceIfHung = &H10
            End Enum

            ''' <summary>
            ''' Major reason flags indicate the general issue type. Minor reason flags modify the specified 
            ''' major reason flag. You can use any minor reason in conjunction with any major reason, but 
            ''' some combinations do not make sense. Planned and UserDefined flags provide additional information about the event.
            ''' </summary>
            Public Enum SystemShutdownReasonCodes As Integer
                MajorApplication = &H40000
                MajorHardware = &H10000
                MajorLegacyAPI = &H70000
                MajorOS = &H20000
                MajorOther = &H0
                MajorPower = &H60000
                MajorSoftware = &H30000
                MajorSystem = &H50000
                MinorBluescreen = &HF
                MinorCordunplugge = &HB
                MinorDisk = &H7
                MinorEnvironment = &HC
                MinorHardwareDriver = &HD
                MinorHotfix = &H11
                MinorHotfixUninstall = &H17
                MinorHung = &H5
                MinorInstallation = &H2
                MinorMaintenance = &H1
                MinorMMC = &H19
                MinorNetworkConnectivity = &H14
                MinorNetworkCard = &H9
                MinorOther = &H0
                MinorOtherDriver = &HE
                MinorPowerSupply = &HA
                MinorProcessor = &H8
                MinorReconfig = &H4
                MinorSecurity = &H13
                MinorSecurityFix = &H12
                MinorSecurityFixUninstall = &H18
                MinorServicePack = &H10
                MinorServicePackUninstall = &H16
                MinorTermSRV = &H20
                MinorUnstable = &H6
                MinorUpgrade = &H3
                MinorWMI = &H15
                UserDefined = &H40000000
                Planned = &H80000000
            End Enum

            Private Declare Function ExitWindowsEx Lib "user32.dll" (ByVal uFlags As Int32, ByVal dwReserved As Int32) As Int32

            ''' <summary>
            ''' Logs off the interactive user, shuts down the system, or shuts down and restarts the system. It sends the 
            ''' WM_QUERYENDSESSION message to all applications to determine if they can be terminated.
            ''' </summary>
            ''' <param name="Flags">
            ''' The shutdown type. This parameter must include one of the following values.
            ''' </param>
            ''' <param name="Reason">
            ''' The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes.
            ''' </param>
            ''' <returns>
            ''' If the function succeeds, the return value is nonzero. Because the function executes asynchronously, 
            ''' a nonzero return value indicates that the shutdown has been initiated. It does not indicate whether 
            ''' the shutdown will succeed. It is possible that the system, the user, or another application will abort the shutdown.
            ''' </returns>
            Public Function ExitWindows(ByVal Flags As ExitWindowsFlags, ByVal Optional Reason As SystemShutdownReasonCodes = SystemShutdownReasonCodes.MajorOther) As Integer
                Return ExitWindowsEx(Flags, Reason)
            End Function

        End Module

    End Namespace
End Namespace