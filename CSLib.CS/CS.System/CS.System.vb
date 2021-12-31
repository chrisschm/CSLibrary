Namespace Global
    Namespace CS
        Namespace System

            Public Class Config

                Public Event RebootNedded()

                Public Property RealTimeIsUniversal() As Boolean
                    Get
                        Dim readValue As Integer = Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\TimeZoneInformation", "RealTimeIsUniversal", 0)
                        Return readValue
                    End Get
                    Set(value As Boolean)
                        Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\TimeZoneInformation", "RealTimeIsUniversal", value)
                    End Set
                End Property


            End Class



            Public Class Services

                Implements IEnumerable

                Private colServices As Collection

#Region "CreateObject"
                ''' <summary>
                ''' Erstellt eine neue Instanz der Services Klasse und gibt ein Services Objekt zurück.
                ''' </summary>
                Public Sub New()

                    Dim scs() As ServiceProcess.ServiceController
                    Dim sc As Service

                    scs = ServiceProcess.ServiceController.GetServices()

                    For Each s As ServiceProcess.ServiceController In scs
                        sc = New Service(s.ServiceName, s.MachineName)
                        colServices.Add(sc, sc.ServiceName)
                    Next

                    scs = ServiceProcess.ServiceController.GetDevices()

                    For Each s As ServiceProcess.ServiceController In scs
                        sc = New Service(s.ServiceName, s.MachineName)
                        colServices.Add(sc, sc.ServiceName)
                    Next

                End Sub

                ''' <summary>
                ''' Erstellt eine neue Instanz der Services Klasse und gibt ein Services Objekt zurück.
                ''' </summary>
                ''' <param name="Host">Erforderlich. Hostname des abzufragenden Computers. Wird keiner angegeben, werden die Dienste des lokalen Computers abgefragt.</param>
                Public Sub New(Host As String)

                    Dim scs() As ServiceProcess.ServiceController
                    Dim sc As Service

                    scs = ServiceProcess.ServiceController.GetServices(Host)

                    For Each s As ServiceProcess.ServiceController In scs
                        sc = New Service(s.ServiceName, s.MachineName)
                        colServices.Add(sc, sc.ServiceName)
                    Next

                    scs = ServiceProcess.ServiceController.GetDevices(Host)

                    For Each s As ServiceProcess.ServiceController In scs
                        sc = New Service(s.ServiceName, s.MachineName)
                        colServices.Add(sc, sc.ServiceName)
                    Next

                End Sub

                ''' <summary>
                ''' Gibt einen Boolean Wert zurück der angibt, ob ein Services-Objekt 
                ''' ein Element mit einem bestimmten Schlüssel enthält.
                ''' </summary>
                ''' <param name="Key">
                ''' Erforderlich. Ein String Ausdruck, der den Schlüssel für die
                ''' Elemente der Auflistung übergibt, die gesucht werden sollen.
                ''' </param>
                ''' <returns>
                ''' Gibt einen Boolean Wert zurück der angibt, ob ein Services-Objekt 
                ''' ein Element mit einem bestimmten Schlüssel enthält.
                ''' </returns>
                Public Function Contains(Key As String) As Boolean
                    Return colServices.Contains(Key)
                End Function


                Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
                    Return colServices.GetEnumerator()
                End Function
#End Region




#Region "PublicProperties"

                Public ReadOnly Property Count() As Integer
                    Get
                        Return colServices.Count()
                    End Get
                End Property

                Public ReadOnly Property Item(Index As Integer) As Service
                    Get
                        Return colServices.Item(Index)
                    End Get
                End Property

                Public ReadOnly Property Item(Index As Object) As Service
                    Get
                        Return colServices.Item(Index)
                    End Get
                End Property

                Public ReadOnly Property Item(Key As String) As Service
                    Get
                        Return colServices.Item(Key)
                    End Get
                End Property
#End Region

            End Class






            Public Class Service

                Private SC As ServiceProcess.ServiceController

                Friend Sub New(Name As String)

                    SC = New ServiceProcess.ServiceController(Name)

                End Sub

                Friend Sub New(Name As String, Host As String)

                    SC = New ServiceProcess.ServiceController(Name, Host)

                End Sub




                Public ReadOnly Property CanPauseAndContinue As Boolean
                    Get
                        Return SC.CanPauseAndContinue
                    End Get
                End Property

                Public ReadOnly Property CanShutdown As Boolean
                    Get
                        Return CanShutdown
                    End Get
                End Property

                Public ReadOnly Property CanStop As Boolean
                    Get
                        Return SC.CanStop
                    End Get
                End Property

                Public ReadOnly Property DependentServices As Service()
                    Get
                        Dim tempSCs(SC.DependentServices.Count) As Service
                        Dim tempSC As Service
                        Dim l As Long = 0

                        For Each s As ServiceProcess.ServiceController In SC.DependentServices
                            tempSC = New Service(s.ServiceName, s.MachineName)
                            tempSCs(l) = tempSC
                            l = l + 1
                        Next

                        Return tempSCs
                    End Get
                End Property

                Public Property DisplayName As String
                    Get
                        Return SC.DisplayName
                    End Get
                    Set(value As String)
                        SC.DisplayName = value
                    End Set
                End Property

                Public ReadOnly Property MachineName As String
                    Get
                        Return SC.MachineName
                    End Get
                End Property

                Public ReadOnly Property ServiceName As String
                    Get
                        Return SC.ServiceName
                    End Get
                End Property

                Public ReadOnly Property ServicesDependedOn As Service()
                    Get
                        Dim tempSCs(SC.ServicesDependedOn.Count) As Service
                        Dim tempSC As Service
                        Dim l As Long = 0

                        For Each s As ServiceProcess.ServiceController In SC.ServicesDependedOn
                            tempSC = New Service(s.ServiceName, s.MachineName)
                            tempSCs(l) = tempSC
                            l = l + 1
                        Next

                        Return tempSCs
                    End Get
                End Property

                Public ReadOnly Property StartType As ServiceProcess.ServiceStartMode
                    Get
                        Return SC.StartType
                    End Get
                End Property

                Public ReadOnly Property Status As ServiceProcess.ServiceControllerStatus
                    Get
                        Return SC.Status
                    End Get
                End Property

                Public ReadOnly Property Type As ServiceProcess.ServiceType
                    Get
                        Return SC.ServiceType
                    End Get
                End Property

            End Class

        End Namespace
    End Namespace
End Namespace