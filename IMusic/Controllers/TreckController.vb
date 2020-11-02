Imports System.Web.Mvc

Namespace Controllers
    Public Class TreckController
        Inherits Controller

        ' GET: Treck
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace