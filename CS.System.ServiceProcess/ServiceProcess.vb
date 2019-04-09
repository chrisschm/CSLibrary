Namespace Global
    Namespace CS
        Namespace System
            Namespace ServiceProcess

                ''' <summary>
                ''' Stellt einen Windows-Dienst dar und ermöglicht es, eine Verbindung mit einem ausgeführten 
                ''' oder beendeten Dienst herzustellen, ihn zu verändern oder Informationen über ihn abzurufen.
                ''' Implementiert <seealso cref="Global.System.ServiceProcess.ServiceController"/> und erweitert
                ''' das Objekt durch die Win32_Service WMI Klasse bzw. deren Objekt-Parameter.
                ''' </summary>
                Public Class ServiceController
                    Inherits ComponentModel.Component

                    Private SC As Global.System.ServiceProcess.ServiceController
                    Private WMI As Management.ManagementObject

#Region "Public Methods"
                    ''' <summary>
                    ''' Trennt diese <seealso cref="ServiceController"/>-Instanz vom Dienst, und alle 
                    ''' Ressourcen die die Instanz reserviert hat werden freigegeben.
                    ''' </summary>
                    Public Sub Close()
                        SC.Close()
                    End Sub

                    ''' <summary>
                    ''' Setzt einen Dienst fort, nachdem dieser zuvor angehalten wurde.
                    ''' </summary>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="Global.System.InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public Sub [Continue]()
                        SC.Continue()
                    End Sub

                    ''' <summary>
                    ''' Führt einen benutzerdefinierten Befehl für den Dienst aus.
                    ''' </summary>
                    ''' <param name="command">Ein von der Anwendung definiertes Befehlsflag, das angibt, welcher benutzerdefinierte Befehl ausgeführt werden soll. Der Wert muss zwischen 128 und einschließlich 256 liegen.</param>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="Global.System.InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public Sub ExecuteCommand(command As Integer)
                        SC.ExecuteCommand(command)
                    End Sub

                    ''' <summary>
                    ''' Ruft die Gerätetreiberdienste auf dem lokalen Computer ab.
                    ''' </summary>
                    ''' <returns>Ein Array vom Typ System.ServiceProcess.ServiceController in dem jedes Element einem Gerätetreiberdienst auf dem lokalen Computer zugeordnet ist.</returns>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    Public Shared Function GetDevices() As ServiceController()
                        Dim GServContr() As Global.System.ServiceProcess.ServiceController = Global.System.ServiceProcess.ServiceController.GetDevices()
                        Dim SCs(GServContr.Count) As ServiceController
                        Dim i As Integer = 0
                        For Each ServContr As Global.System.ServiceProcess.ServiceController In GServContr
                            SCs(i) = New ServiceController(ServContr.ServiceName)
                            i = i + 1
                        Next
                        Return SCs
                    End Function

                    ''' <summary>
                    ''' Ruft die Gerätetreiberdienste auf dem angegebenen Computer ab.
                    ''' </summary>
                    ''' <param name="machineName">Der Computer, von dem die Gerätetreiberdienste abgerufen werden soll.</param>
                    ''' <returns>Ein Array vom Typ System.ServiceProcess.ServiceController in dem jedes Element einem Gerätetreiberdienst auf dem angegebenen Computer zugeordnet ist.</returns>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="Global.System.ArgumentException">Die machineName Parameter hat eine ungültige Syntax.</exception>
                    Public Shared Function GetDevices(machineName As String) As ServiceController()
                        Dim GServContr() As Global.System.ServiceProcess.ServiceController = Global.System.ServiceProcess.ServiceController.GetDevices(machineName)
                        Dim SCs(GServContr.Count) As ServiceController
                        Dim i As Integer = 0
                        For Each ServContr As Global.System.ServiceProcess.ServiceController In GServContr
                            SCs(i) = New ServiceController(ServContr.ServiceName, ServContr.MachineName)
                            i = i + 1
                        Next
                        Return SCs
                    End Function

                    ''' <summary>
                    ''' Ruft alle Dienste auf dem lokalen Computer mit Ausnahme der Gerätetreiberdienste ab.
                    ''' </summary>
                    ''' <returns>Ein Array vom Typ System.ServiceProcess.ServiceController in dem jedes Element einem Dienst auf dem lokalen Computer zugeordnet ist.</returns>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    Public Shared Function GetServices() As ServiceController()
                        Dim GServContr() As Global.System.ServiceProcess.ServiceController = Global.System.ServiceProcess.ServiceController.GetServices()
                        Dim SCs(GServContr.Count) As ServiceController
                        Dim i As Integer = 0
                        For Each ServContr As Global.System.ServiceProcess.ServiceController In GServContr
                            SCs(i) = New ServiceController(ServContr.ServiceName)
                            i = i + 1
                        Next
                        Return SCs
                    End Function

                    ''' <summary>
                    ''' Ruft alle Dienste auf dem angegebenen Computer mit Ausnahme der Gerätetreiberdienste ab.
                    ''' </summary>
                    ''' <param name="machineName">Der Computer, dessen Dienste abgerufen werden sollen.</param>
                    ''' <returns>Ein Array vom Typ System.ServiceProcess.ServiceController in dem jedes Element einem Dienst auf dem angegebenen Computer zugeordnet ist.</returns>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="Global.System.ArgumentException">Die machineName Parameter hat eine ungültige Syntax.</exception>
                    Public Shared Function GetServices(machineName As String) As ServiceController()
                        Dim GServContr() As Global.System.ServiceProcess.ServiceController = Global.System.ServiceProcess.ServiceController.GetServices(machineName)
                        Dim SCs(GServContr.Count) As ServiceController
                        Dim i As Integer = 0
                        For Each ServContr As Global.System.ServiceProcess.ServiceController In GServContr
                            SCs(i) = New ServiceController(ServContr.ServiceName, ServContr.MachineName)
                            i = i + 1
                        Next
                        Return SCs
                    End Function

                    ''' <summary>
                    ''' Initialisiert eine neue Instanz der <seealso cref="ServiceController"/>-Klasse, die einem 
                    ''' vorhandenen Dienst auf dem angegebenen Computer zugeordnet ist.
                    ''' </summary>
                    Public Sub New()
                        SC = New Global.System.ServiceProcess.ServiceController
                    End Sub

                    ''' <summary>
                    ''' Initialisiert eine neue Instanz der <seealso cref="ServiceController"/>-Klasse, die einem 
                    ''' vorhandenen Dienst auf dem angegebenen Computer zugeordnet ist.
                    ''' </summary>
                    ''' <param name="name">Der Name, der den Dienst für das System identifiziert. Dies kann auch der Anzeigename für den Dienst sein.</param>
                    ''' <exception cref="Global.System.ArgumentException">name ist ungültig.</exception>
                    Public Sub New(name As String)
                        SC = New Global.System.ServiceProcess.ServiceController(name)
                        WMI = New Management.ManagementObject("Win32_Service.Name='" + name + "'")
                        WMI.Get()
                    End Sub

                    ''' <summary>
                    ''' Initialisiert eine neue Instanz der <seealso cref="ServiceController"/>-Klasse, die einem 
                    ''' vorhandenen Dienst auf dem angegebenen Computer zugeordnet ist.
                    ''' </summary>
                    ''' <param name="name">Der Name, der den Dienst für das System identifiziert. Dies kann auch der Anzeigename für den Dienst sein.</param>
                    ''' <param name="machineName">Der Computer, auf dem sich der Dienst befindet.</param>
                    ''' <exception cref="Global.System.ArgumentException">name ist ungültig, oder machineName ist ungültig.</exception>
                    Public Sub New(name As String, machineName As String)
                        SC = New Global.System.ServiceProcess.ServiceController(name, machineName)
                        Dim s As Management.ManagementScope = New Management.ManagementScope("\\\\" & machineName & "\\root\\cimv2")
                        Dim p As Management.ManagementPath = New Management.ManagementPath("Win32_Service.Name='" + name + "'")
                        Dim opt As Management.ObjectGetOptions = New Management.ObjectGetOptions(Nothing, TimeSpan.MaxValue, True)
                        WMI = New Management.ManagementObject(s, p, opt)
                        WMI.Get()
                    End Sub

                    ''' <summary>
                    ''' Unterbricht die Ausführung eines Diensts.
                    ''' </summary>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="Global.System.InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public Sub Pause()
                        SC.Pause()
                    End Sub

                    ''' <summary>
                    ''' Aktualisiert Eigenschaftswerte durch Zurücksetzen der Eigenschaften auf ihre aktuellen Werte.
                    ''' </summary>
                    Public Sub Refresh()
                        SC.Refresh()
                    End Sub

                    ''' <summary>
                    ''' Startet den Dienst und übergibt dabei keine Argumente.
                    ''' </summary>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="Global.System.InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public Sub Start()
                        SC.Start()
                    End Sub

                    ''' <summary>
                    ''' Startet einen Dienst und übergibt dabei die angegebenen Argumente.
                    ''' </summary>
                    ''' <param name="args">Ein Array von Argumenten, die an den Dienst übergeben werden, wenn er gestartet wird.</param>
                    Public Sub Start(args As String())
                        SC.Start(args)
                    End Sub

                    ''' <summary>
                    ''' Beendet diesen Dienst sowie alle Dienste, die von diesem Dienst abhängig sind.
                    ''' </summary>
                    ''' <exception cref="Global.System.ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="Global.System.InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public Sub [Stop]()
                        SC.Stop()
                    End Sub

                    ''' <summary>
                    ''' Wartet unbegrenzt, bis der Dienst den angegebenen Zustand annimmt.
                    ''' </summary>
                    ''' <param name="desiredStatus">Der Status auf den gewartet wird.</param>
                    ''' <exception cref="Global.System.ComponentModel.InvalidEnumArgumentException">Der im desiredStatus Parameter übergebene Wert ist nicht gemäß der <seealso cref="ServiceControllerStatus"/> Enumeration.</exception>
                    Public Sub WaitForStatus(desiredStatus As ServiceControllerStatus)
                        SC.WaitForStatus(desiredStatus)
                    End Sub

                    ''' <summary>
                    ''' Wartet, bis der Dienst den angegebenen Status annimmt oder bis das angegebene Timeout abläuft.
                    ''' </summary>
                    ''' <param name="desiredStatus">Der Status auf den gewartet wird.</param>
                    ''' <param name="timeout">Ein <seealso cref="TimeSpan"/>-Objekt das die Zeitspanne angibt, die gewartet werden soll bis der Dienst den angegebenen Status annimmt.</param>
                    ''' <exception cref="Global.System.ComponentModel.InvalidEnumArgumentException">Der im desiredStatus Parameter übergebene Wert ist nicht gemäß der <seealso cref="ServiceControllerStatus"/> Enumeration.</exception>
                    ''' <exception cref="Global.System.ServiceProcess.TimeoutException">Der angegebene Wert für den timeout Parameter ist abgelaufen.</exception>
                    Public Sub WaitForStatus(desiredStatus As ServiceControllerStatus, timeout As TimeSpan)
                        SC.WaitForStatus(desiredStatus, timeout)
                    End Sub
#End Region

#Region "Public Properties"
                    ''' <summary>
                    ''' Ruft einen Wert ab, der angibt, ob der Dienst angehalten und fortgesetzt werden kann.
                    ''' </summary>
                    ''' <returns>True Wenn der Dienst angehalten werden kann; andernfalls false.</returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property CanPauseAndContinue As Boolean
                        Get
                            Return SC.CanPauseAndContinue
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft einen Wert ab, der angibt, ob der Dienst beim Herunterfahren des Systems benachrichtigt werden soll.
                    ''' </summary>
                    ''' <returns>True Wenn der Dienst beim Herunterfahren des Systems benachrichtigt werden soll; andernfalls false.</returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property CanShutdown As Boolean
                        Get
                            Return SC.CanShutdown
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft einen Wert ab, der angibt, ob der Dienst nach dem Starten angehalten werden kann.
                    ''' </summary>
                    ''' <returns>
                    ''' True Wenn der Dienst beendet werden kann und die 
                    ''' <seealso cref="Global.System.ServiceProcess.ServiceBase.OnStop"/> Methode 
                    ''' aufgerufen wird; andernfalls false.
                    ''' </returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property CanStop As Boolean
                        Get
                            Return SC.CanStop
                        End Get
                    End Property

                    ''' <summary>
                    ''' Wert, den der Dienst regelmäßig inkrementiert, um den Fortschritt während eines langen Starts, Stopps, 
                    ''' Anhaltens oder Fortsetzen des Vorgangs anzuzeigen. Der Dienst erhöht diesen Wert beispielsweise, wenn er 
                    ''' beim Start jeden Schritt der Initialisierung durchführt. Das Benutzeroberflächenprogramm, das den Vorgang 
                    ''' für den Dienst aufruft, verwendet diesen Wert, um den Fortschritt des Diensts während eines längeren Vorgangs 
                    ''' zu verfolgen. Dieser Wert ist ungültig und sollte Null sein, wenn der Dienst noch nicht gestartet, gestoppt, 
                    ''' angehalten oder fortgesetzt wurde.
                    ''' </summary>
                    ''' <returns>Fortschrittsanzeiger</returns>
                    Public ReadOnly Property CheckPoint As UInteger
                        Get
                            If IsNothing(WMI) = True Then
                                Return 0
                            Else
                                If IsNothing(WMI("CheckPoint")) = True Then
                                    Return 0
                                Else
                                    Return WMI("CheckPoint")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Bei True wird der Dienst gestartet, nachdem andere Autostart-Dienste gestartet wurden, 
                    ''' ausserdem gibt es eine kurze Verzögerung.
                    ''' </summary>
                    ''' <returns>Boolean</returns>
                    Public ReadOnly Property DelayedAutoStart As Boolean
                        Get
                            If IsNothing(WMI) = True Then
                                Return False
                            Else
                                If IsNothing(WMI("DelayedAutoStart")) = True Then
                                    Return False
                                Else
                                    Return WMI("DelayedAutoStart")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Beschreibung des Objekts
                    ''' </summary>
                    ''' <returns>Beschreibung des Objekts</returns>
                    Public ReadOnly Property Description As String
                        Get
                            If IsNothing(WMI) = True Then
                                Return ""
                            Else
                                Return WMI("Description").ToString
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Gibt an, ob der Dienst Fenster auf dem Desktop erstellen oder damit kommunizieren kann und somit in 
                    ''' gewisser Weise mit einem Benutzer interagieren kann. Interaktive Dienste müssen unter dem lokalen 
                    ''' Systemkonto ausgeführt werden. Die meisten Dienste sind nicht interaktiv. Das heißt, sie kommunizieren 
                    ''' in keiner Weise mit dem Benutzer.
                    ''' </summary>
                    ''' <returns>Boolean</returns>
                    Public ReadOnly Property DesktopInteract As Boolean
                        Get
                            If IsNothing(WMI) = True Then
                                Return False
                            Else
                                If IsNothing(WMI("DesktopInteract")) = True Then
                                    Return False
                                Else
                                    Return WMI("DesktopInteract")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft die Gruppe von Diensten ab, die von dem Dienst der <seealso cref="ServiceController"/> Instanz abhängen.
                    ''' </summary>
                    ''' <returns>Ein Array von <seealso cref="ServiceController"/> Instanzen, von denen jede ein Dienst ist, der von diesem Dienst abhängt.</returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property DependentServices As ServiceController()
                        Get
                            Dim SCs(SC.DependentServices.Count) As ServiceController
                            Dim i As Integer = 0
                            For Each ServContr As Global.System.ServiceProcess.ServiceController In SC.DependentServices
                                SCs(i) = New ServiceController(ServContr.ServiceName, ServContr.MachineName)
                                i = i + 1
                            Next
                            Return SCs
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft einen angezeigten Namen für den Dienst ab oder richtet ihn ein.
                    ''' </summary>
                    ''' <returns>Der angezeigte Name des Diensts, der zu dessen Identifizierung verwendet werden kann.</returns>
                    ''' <exception cref="ArgumentNullException"><seealso cref="DisplayName"/> ist null.</exception>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public Property DisplayName As String
                        Get
                            Return SC.DisplayName
                        End Get
                        Set(value As String)
                            SC.DisplayName = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Schweregrad des Fehlers, wenn dieser Dienst während des Startvorgangs nicht gestartet werden kann. 
                    ''' Der Wert gibt die vom Startprogramm durchgeführte Aktion an, wenn ein Fehler auftritt. Alle Fehler 
                    ''' werden vom Computersystem protokolliert.
                    ''' </summary>
                    ''' <returns>Schweregrad des Fehlers</returns>
                    Public ReadOnly Property ErrorControl As String
                        Get
                            If IsNothing(WMI) = True Then
                                Return ""
                            Else
                                Return WMI("ErrorControl").ToString
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Windows-Fehlercode der Fehler definiert, die beim Starten oder Stoppen des Dienstes 
                    ''' aufgetreten sind. Diese Eigenschaft wird auf ERROR_SERVICE_SPECIFIC_ERROR (1066) gesetzt, 
                    ''' wenn der Fehler für den durch diese Klasse dargestellten Dienst eindeutig ist und 
                    ''' Informationen zum Fehler in der Eigenschaft <seealso cref="ServiceSpecificExitCode"/> verfügbar sind. 
                    ''' Der Dienst setzt diesen Wert bei der Ausführung auf NO_ERROR und bei normaler Beendigung erneut.
                    ''' </summary>
                    ''' <returns>Windows-Fehlercode</returns>
                    Public ReadOnly Property ExitCode As UInteger
                        Get
                            If IsNothing(WMI) = True Then
                                Return 0
                            Else
                                If IsNothing(WMI("ExitCode")) = True Then
                                    Return 0
                                Else
                                    Return WMI("ExitCode")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Namen des Computers ab, auf dem sich dieser Dienst befindet, oder legt diesen fest.
                    ''' </summary>
                    ''' <returns>
                    ''' Der Name des Computers mit dem Dienst zugeordnet ist <seealso cref="ServiceController"/> 
                    ''' Instanz. Der Standardwert ist der lokale Computer (".").
                    ''' </returns>
                    ''' <exception cref="ArgumentException">Die <seealso cref="MachineName"/> Syntax ist ungültig.</exception>
                    Public Property MachineName As String
                        Get
                            Return SC.MachineName
                        End Get
                        Set(value As String)
                            SC.MachineName = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Vollständig qualifizierter Pfad zu der Dienstbinärdatei, die den Dienst implementiert.
                    ''' </summary>
                    ''' <returns>Pfad zu der Dienstbinärdatei</returns>
                    ''' <example>"\SystemRoot\System32\drivers\afd.sys"</example>
                    Public ReadOnly Property PathName As String
                        Get
                            If IsNothing(WMI) = True Then
                                Return ""
                            Else
                                Return WMI("PathName").ToString
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Prozesskennung des Dienstes.
                    ''' </summary>
                    ''' <returns>Prozesskennung des Dienstes.</returns>
                    Public ReadOnly Property ProcessID As UInteger
                        Get
                            If IsNothing(WMI) = True Then
                                Return 0
                            Else
                                If IsNothing(WMI("ProcessID")) = True Then
                                    Return 0
                                Else
                                    Return WMI("ProcessID")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft das Handle für den Dienst ab.
                    ''' </summary>
                    ''' <returns>Ein <seealso cref="Runtime.InteropServices.SafeHandle"/> der das Handle für den Dienst enthält.</returns>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property ServiceHandle As Runtime.InteropServices.SafeHandle
                        Get
                            Return SC.ServiceHandle
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Namen ab, der den Dienst identifiziert, auf den diese Instanz verweist, 
                    ''' oder richtet diesen Namen ein.
                    ''' </summary>
                    ''' <returns>
                    ''' Der Name, der den Dienst identifiziert, die von diesem <seealso cref="ServiceController"/> 
                    ''' Instanz verweist. Der Standardwert ist eine leere Zeichenfolge ("").
                    ''' </returns>
                    ''' <exception cref="ArgumentNullException"><seealso cref="ServiceController.ServiceName"/> ist null.</exception>
                    ''' <exception cref="ArgumentException">Die Syntax der <seealso cref="ServiceController.ServiceName"/> Eigenschaft ist ungültig.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public Property ServiceName As String
                        Get
                            Return SC.ServiceName
                        End Get
                        Set(value As String)
                            SC.ServiceName = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Die Gruppe von Diensten, von denen dieser Dienst abhängig ist.
                    ''' </summary>
                    ''' <returns>
                    ''' Ein Array von <seealso cref="ServiceController"/> Instanzen, die jeweils einen für diesen 
                    ''' Dienst zur Ausführung ausgeführten Dienst zugeordnet sind.
                    ''' </returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property ServicesDependedOn As ServiceController()
                        Get
                            Dim SCs(SC.ServicesDependedOn.Count) As ServiceController
                            Dim i As Integer = 0
                            For Each ServContr As Global.System.ServiceProcess.ServiceController In SC.ServicesDependedOn
                                SCs(i) = New ServiceController(ServContr.ServiceName, ServContr.MachineName)
                                i = i + 1
                            Next
                            Return SCs
                        End Get
                    End Property

                    ''' <summary>
                    ''' Dienstspezifischer Fehlercode für Fehler, die auftreten, wenn der Dienst gestartet oder gestoppt wird. Die Beendigungscodes werden von dem durch diese Klasse repräsentierten Dienst definiert. Dieser Wert wird nur festgelegt, wenn der ExitCode-Eigenschaftswert ERROR_SERVICE_SPECIFIC_ERROR (1066) lautet.
                    ''' </summary>
                    ''' <returns>Dienstspezifischer Fehlercode</returns>
                    Public ReadOnly Property ServiceSpecificExitCode As UInteger
                        Get
                            If IsNothing(WMI) = True Then
                                Return 0
                            Else
                                If IsNothing(WMI("ServiceSpecificExitCode")) = True Then
                                    Return 0
                                Else
                                    Return WMI("ServiceSpecificExitCode")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Typ des Dienstes ab, auf den dieses Objekt verweist.
                    ''' </summary>
                    ''' <returns>Einer der <seealso cref="ServiceType"/> Werte, mit dem der Netzwerkdiensttyp angegeben.</returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property ServiceType As ServiceType
                        Get
                            Return SC.ServiceType
                        End Get
                    End Property

                    ''' <summary>
                    ''' Gibt an, ob der Dienst gestartet ist oder nicht.
                    ''' </summary>
                    ''' <returns>Gibt an, ob der Dienst gestartet ist oder nicht.</returns>
                    Public ReadOnly Property Started As Boolean
                        Get
                            If IsNothing(WMI) = True Then
                                Return False
                            Else
                                If IsNothing(WMI("Started")) = True Then
                                    Return False
                                Else
                                    Return WMI("Started")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Startmodus des Windows-Basisdienstes.
                    ''' </summary>
                    ''' <returns>Startmodus</returns>
                    Public ReadOnly Property StartMode As String
                        Get
                            If IsNothing(WMI) = True Then
                                Return ""
                            Else
                                Return WMI("StartMode").ToString
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Kontoname, unter dem ein Dienst ausgeführt wird. Je nach Diensttyp kann der Kontoname in der 
                    ''' Form "Domänenname\Benutzername" oder UPN-Format ("*Benutzername@Domänenname*") vorliegen. 
                    ''' Der Serviceprozess wird bei seiner Ausführung mit einem dieser beiden Formulare protokolliert. 
                    ''' Wenn das Konto zur integrierten Domäne gehört, kann ".\Benutzername" angegeben werden. Für 
                    ''' Treiber auf Kernel- oder Systemebene enthält StartName den Namen des Treiberobjekts 
                    ''' (dh "\FileSystem\Rdr" oder "\Driver\Xns"), mit dem das E/A-System den Gerätetreiber lädt. 
                    ''' Wenn NULL angegeben wird, wird der Treiber außerdem mit einem Standardobjektnamen ausgeführt, 
                    ''' der vom E/A-System basierend auf dem Servicenamen erstellt wird.
                    ''' </summary>
                    ''' <returns>Kontoname, unter dem ein Dienst ausgeführt wird.</returns>
                    Public ReadOnly Property StartName As String
                        Get
                            If IsNothing(WMI) = True Then
                                Return ""
                            Else
                                Return WMI("StartName").ToString
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Typ des Diensts ab, auf den dieses Objekt verweist.
                    ''' </summary>
                    ''' <returns>
                    ''' Eines der <seealso cref="ServiceType"/> Werte, mit dem der Netzwerkdiensttyp angegeben wird.
                    ''' </returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property StartType As ServiceStartMode
                        Get
                            Return SC.StartType
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ruft den Zustand des Dienstes ab, auf den diese Instanz verweist.
                    ''' </summary>
                    ''' <returns>
                    ''' Eines der <seealso cref="ServiceControllerStatus"/> Werte, der angibt, ob der Dienst ausgeführt 
                    ''' wird, beendet oder angehalten wurde, oder der angibt ob eine Methode Starten, Beenden, 
                    ''' Anhalten oder Fortsetzen zur Verfügung steht.
                    ''' </returns>
                    ''' <exception cref="ComponentModel.Win32Exception">Beim Zugreifen auf eine System-API ist ein Fehler aufgetreten.</exception>
                    ''' <exception cref="InvalidOperationException">Der Dienst wurde nicht gefunden.</exception>
                    Public ReadOnly Property Status As ServiceControllerStatus
                        Get
                            Return SC.Status
                        End Get
                    End Property

                    ''' <summary>
                    ''' Eindeutiges Kennzeichen für diesen Dienst in einer Gruppe. Ein Wert von 0 (Null) zeigt an, dass der Dienst 
                    ''' kein Kennzeichen hat. Ein Kennzeichen kann verwendet werden, um den Start des Dienstes innerhalb einer 
                    ''' Ladeauftragsgruppe zu sortieren, indem Sie in der Registrierung einen Tag-Bestellvektor angeben, der sich 
                    ''' an folgender Position befindet:<para/>
                    ''' HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\    GroupOrderList<para/>
                    ''' Kennzeichen werden nur für Kernel-Treiber und Dateisystemtreiber (ServiceType) ausgewertet, die über 
                    ''' den Startmodus oder den Systemstartmodus verfügen (ServiceStartMode = System oder Boot).
                    ''' </summary>
                    ''' <returns>Kennzeichen (TagID) als UInteger</returns>
                    Public ReadOnly Property TagID As UInteger
                        Get
                            If IsNothing(WMI) = True Then
                                Return 0
                            Else
                                If IsNothing(WMI("TagID")) = True Then
                                    Return 0
                                Else
                                    Return WMI("TagID")
                                End If
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Geschätzte Zeit in Millisekunden für einen anstehenden Start, Stopp, Pause oder die Fortsetzung. 
                    ''' Nach Ablauf der angegebenen Zeit führt der Dienst den nächsten Aufruf der SetServiceStatus-Methode 
                    ''' mit einem inkrementierten CheckPoint-Wert oder einer Änderung in CurrentState aus. Wenn die von 
                    ''' WaitHint angegebene Zeit verstrichen ist und CheckPoint nicht inkrementiert wurde oder 
                    ''' CurrentState nicht geändert wurde, nimmt der Dienststeuerungs-Manager oder das 
                    ''' Dienststeuerungsprogramm an, dass ein Fehler aufgetreten ist.
                    ''' </summary>
                    ''' <returns>Zeit in Millisekunden als UInteger</returns>
                    Public ReadOnly Property WaitHint As UInteger
                        Get
                            If IsNothing(WMI) = True Then
                                Return 0
                            Else
                                If IsNothing(WMI("WaitHint")) = True Then
                                    Return 0
                                Else
                                    Return WMI("WaitHint")
                                End If
                            End If
                        End Get
                    End Property
#End Region

                End Class

                ''' <summary>
                ''' Gibt den aktuellen Status des Dienstes an.
                ''' </summary>
                Public Enum ServiceControllerStatus As Integer
                    Stopped = 1
                    StartPending = 2
                    StopPending = 3
                    Running = 4
                    ContinuePending = 5
                    PausePending = 6
                    Paused = 7
                End Enum

                ''' <summary>
                ''' Gibt den Startmodus des Dienstes an.
                ''' </summary>
                Public Enum ServiceStartMode As Integer
                    Boot = 0
                    System = 1
                    Automatic = 2
                    Manual = 3
                    Disabled = 4
                End Enum

                ''' <summary>
                ''' Stellt den Typ des Dienstes dar.
                ''' </summary>
                Public Enum ServiceType As Integer
                    KernelDriver = 1
                    FileSystemDriver = 2
                    Adapter = 4
                    RecognizerDriver = 8
                    Win32OwnProcess = 16
                    Win32ShareProcess = 32
                    InteractiveProcess = 256
                End Enum

            End Namespace
        End Namespace
    End Namespace
End Namespace