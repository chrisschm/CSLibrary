Namespace CS
    Public Module Interaction

        Public Enum MessageBoxStyle As Integer
            AbortRetryIgnore = 2
            ApplicationModal = 0
            Critical = 16
            DefaultButton1 = 0
            DefaultButton2 = 256
            DefaultButton3 = 512
            Exclamation = 48
            Information = 64
            MsgBoxHelp = 16384
            MsgBoxRight = 524288
            MsgBoxRtlReading = 1048576
            MsgBoxSetForeground = 65536
            OkCancel = 1
            OkOnly = 0
            Question = 32
            RetryCancel = 5
            SystemModal = 4096
            YesNo = 4
            YesNoCancel = 3
        End Enum

        Public Enum MessageBoxResult As Integer
            Abort = 3
            Cancel = 2
            Ignore = 5
            No = 7
            Ok = 1
            Retry = 4
            Yes = 6
        End Enum

        Private Declare Function MessageBox Lib "user32.dll" Alias "MessageBoxA" (ByVal hwnd As Int32, ByVal lpText As String, ByVal lpCaption As String, ByVal wType As Int32) As Int32

        Public Function MBox(ByVal Handle As Integer, ByVal Message As String, ByVal Caption As String, ByVal Type As MessageBoxStyle) As MessageBoxResult
            Return MessageBox(Handle, Message, Caption, Type)
        End Function


    End Module
End Namespace