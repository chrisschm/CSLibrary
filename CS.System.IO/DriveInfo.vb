Namespace Global
    Namespace CS
        Namespace System
            Namespace IO

                ''' <summary>
                ''' Ermöglicht Zugriff auf Informationen zu einem Laufwerk.
                ''' </summary>
                Public NotInheritable Class DriveInfo

                    Private drvDriveInfo As Global.System.IO.DriveInfo
                    Private WMI As Global.System.Management.ManagementObject

#Region "Public Methods"
                    ''' <summary>
                    ''' Ruft die Laufwerknamen aller logischen Laufwerke auf einem Computer ab.
                    ''' </summary>
                    ''' <returns>Ein Array vom Typ System.IO.DriveInfo, das die auf einem Computer vorhandenen logischen Laufwerke darstellt.</returns>
                    ''' <exception cref="Global.System.IO.IOException">E/a-Fehler (z. B. ein Datenträgerfehler oder ein Laufwerk nicht bereit war).</exception>
                    ''' <exception cref="Global.System.UnauthorizedAccessException">Der Aufrufer verfügt nicht über die erforderliche Berechtigung.</exception>
                    Public Shared Function GetDrives() As DriveInfo()
                        Dim DrvInf() As Global.System.IO.DriveInfo = Global.System.IO.DriveInfo.GetDrives()
                        Dim DIs(DrvInf.Count) As DriveInfo
                        Dim i As Integer = 0
                        For Each DI As Global.System.IO.DriveInfo In DrvInf
                            DIs(i) = New DriveInfo(DI.Name)
                            i = i + 1
                        Next
                        Return DIs
                    End Function

                    ''' <summary>
                    ''' Ermöglicht Zugriff auf Informationen zum angegebenen Laufwerk.
                    ''' </summary>
                    ''' <param name="driveName">Ein gültiger Laufwerkpfad oder -buchstabe. Dieser kann von "a" bis "z" in Großbuchstaben oder in Kleinbuchstaben angegeben sein. Ein NULL-Wert ist nicht zulässig.</param>
                    ''' <exception cref="Global.System.ArgumentNullException">Der Laufwerkbuchstabe nicht null.</exception>
                    ''' <exception cref="Global.System.ArgumentException">Der erste Buchstabe des driveName ist kein Großbuchstabe oder Kleinbuchstabe Großbuchstabe von "a" bis "Z".- oder - driveName verweist nicht auf ein gültiges Laufwerk.</exception>
                    Public Sub New(driveName As String)
                        drvDriveInfo = New Global.System.IO.DriveInfo(driveName)
                        Dim mosDDs As New Global.System.Management.ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE Name=" & Left(drvDriveInfo.Name, 2))
                        For Each mosDD As Global.System.Management.ManagementObject In mosDDs.[Get]()
                            If mosDD("Name").ToString() = Left(drvDriveInfo.Name, 2) Then
                                WMI = mosDD
                                Exit For
                            End If
                        Next
                    End Sub
#End Region

#Region "Public Properties"
                    ''' <summary>
                    ''' Art des verfügbaren Medienzugriffs.
                    ''' </summary>
                    ''' <returns>Einer der Enumerationswerte, der einen Zugriffstyp angibt.</returns>
                    Public ReadOnly Property Access As AccessType
                        Get
                            If IsNothing(WMI) = True Then
                                Return 0
                            Else
                                If IsNothing(WMI("Name")) = True Then
                                    Return 0
                                Else
                                    Return WMI("Name")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Gibt die Gesamtmenge an verfügbarem freiem Speicherplatz in Bytes ab, 
                    ''' die auf einem Laufwerk verfügbar ist.
                    ''' </summary>
                    ''' <returns>Die auf dem Laufwerk verfügbare Menge an freiem Speicherplatz in Bytes.</returns>
                    ''' <exception cref="Global.System.UnauthorizedAccessException">Zugriff auf Laufwerksinformationen wird verweigert.</exception>
                    ''' <exception cref="Global.System.IO.IOException">E/a-Fehler (z. B. ein Datenträgerfehler oder ein Laufwerk nicht bereit war).</exception>
                    Public ReadOnly Property AvailableFreeSpace As Long
                        Get
                            Return drvDriveInfo.AvailableFreeSpace
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Namen des Dateisystems ab, z. B. NTFS oder FAT32.
                    ''' </summary>
                    ''' <returns>Der Name des Dateisystems auf dem angegebenen Laufwerk.</returns>
                    ''' <exception cref="Global.System.UnauthorizedAccessException">Zugriff auf Laufwerksinformationen wird verweigert.</exception>
                    ''' <exception cref="Global.System.IO.DriveNotFoundException">Das Laufwerk ist nicht zugeordnet oder nicht vorhanden.</exception>
                    ''' <exception cref="Global.System.IO.IOException">E/a-Fehler (z. B. ein Datenträgerfehler oder ein Laufwerk nicht bereit war).</exception>
                    Public ReadOnly Property DriveFormat As String
                        Get
                            Return drvDriveInfo.DriveFormat
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Laufwerkstyp ab, wie z. B. CD-ROM, Wechseldatenträger, 
                    ''' Netzlaufwerk oder lokales Festplattenlaufwerk.
                    ''' </summary>
                    ''' <returns>Einer der Enumerationswerte, der einen Laufwerkstyp angibt.</returns>
                    Public ReadOnly Property DriveType As DriveType
                        Get
                            Return drvDriveInfo.DriveType
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft einen Wert ab, der angibt, ob ein Laufwerk bereit ist.
                    ''' </summary>
                    ''' <returns>True, wenn das Laufwerk bereit ist; false, wenn das Laufwerk nicht bereit ist.</returns>
                    Public ReadOnly Property IsReady As Boolean
                        Get
                            Return drvDriveInfo.IsReady
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Namen eines Laufwerks ab, wie C:\.
                    ''' </summary>
                    ''' <returns>Der Name des Laufwerks.</returns>
                    Public ReadOnly Property Name As String
                        Get
                            Return drvDriveInfo.Name
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft das Stammverzeichnis eines Laufwerks ab.
                    ''' </summary>
                    ''' <returns>Ein Objekt, das das Stammverzeichnis des Laufwerks enthält.</returns>
                    Public ReadOnly Property RootDirectory As Global.System.IO.DirectoryInfo
                        Get
                            Return drvDriveInfo.RootDirectory
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft die Gesamtmenge an freiem Speicherplatz in Bytes ab, die auf einem Laufwerk verfügbar ist.
                    ''' </summary>
                    ''' <returns>Der auf einem Laufwerk verfügbare gesamte freie Speicherplatz in Bytes.</returns>
                    ''' <exception cref="Global.System.UnauthorizedAccessException">Zugriff auf Laufwerksinformationen wird verweigert.</exception>
                    ''' <exception cref="Global.System.IO.DriveNotFoundException">Das Laufwerk ist nicht zugeordnet oder nicht vorhanden.</exception>
                    ''' <exception cref="Global.System.IO.IOException">E/a-Fehler (z. B. ein Datenträgerfehler oder ein Laufwerk nicht bereit war).</exception>
                    Public ReadOnly Property TotalFreeSpace As Long
                        Get
                            Return drvDriveInfo.TotalFreeSpace
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft die Gesamtgröße des Speicherplatzes in Bytes auf einem Laufwerk ab.
                    ''' </summary>
                    ''' <returns>Die Gesamtgröße des Laufwerks in Bytes.</returns>
                    ''' <exception cref="Global.System.UnauthorizedAccessException">Zugriff auf Laufwerksinformationen wird verweigert.</exception>
                    ''' <exception cref="Global.System.IO.DriveNotFoundException">Das Laufwerk ist nicht zugeordnet oder nicht vorhanden.</exception>
                    ''' <exception cref="Global.System.IO.IOException">E/a-Fehler (z. B. ein Datenträgerfehler oder ein Laufwerk nicht bereit war).</exception>
                    Public ReadOnly Property TotalSize As Long
                        Get
                            Return drvDriveInfo.TotalSize
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft die Volumebezeichnung eines Laufwerks ab oder legt diese fest.
                    ''' </summary>
                    ''' <returns>Die Volumebezeichnung.</returns>
                    ''' <exception cref="Global.System.IO.IOException">E/a-Fehler (z. B. ein Datenträgerfehler oder ein Laufwerk nicht bereit war).</exception>
                    ''' <exception cref="Global.System.IO.DriveNotFoundException">Das Laufwerk ist nicht zugeordnet oder nicht vorhanden.</exception>
                    ''' <exception cref="Global.System.Security.SecurityException">Der Aufrufer verfügt nicht über die erforderliche Berechtigung.</exception>
                    ''' <exception cref="Global.System.UnauthorizedAccessException">Die Bezeichnung wird in einem Netzwerk oder dem CD-ROM-Laufwerk festgelegt.- oder - Zugriff auf Laufwerksinformationen wird verweigert.</exception>
                    Public Property VolumeLabel As String
                        Get
                            Return drvDriveInfo.VolumeLabel
                        End Get
                        Set(value As String)
                            drvDriveInfo.VolumeLabel = value
                        End Set
                    End Property
#End Region

                End Class




                ''' <summary>
                ''' Definiert Konstanten für mögliche Zugriffstypen, z.B. lesen, schreiben usw..
                ''' </summary>
                Public Enum AccessType As UShort
                    Unknown = 0
                    Readable = 1
                    Writeable = 2
                    ReadWrite = 3
                    WriteOnce = 4
                End Enum



                ''' <summary>
                ''' Definiert Konstanten für Laufwerkstypen, z. B. CD-ROM, feste, Netzwerk, 
                ''' NoRootDirectory, Ram, Wechseldatenträger und unbekannt.
                ''' </summary>
                Public Enum DriveType As Integer
                    Unknown = 0
                    NoRootDirectory = 1
                    Removable = 2
                    Fixed = 3
                    Network = 4
                    CDRom = 5
                    Ram = 6
                End Enum

            End Namespace
        End Namespace
    End Namespace
End Namespace