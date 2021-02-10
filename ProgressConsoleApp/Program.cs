using System;
using Progress.Open4GL.Exceptions;

namespace ProgressConsoleApp
{
  class Program
  {
    private static Progress.Open4GL.Proxy.Connection pAConn;
    private static pAMobileEtikett pAMEtk;
    private static string connectionString = "AppServer://padb-01:5163/proalpha-test2-sfe";
    static void Main(string[] args)
    {
      string cTicket = null;
      try
      {
        pAConn = new Progress.Open4GL.Proxy.Connection(connectionString, "", "", "");
        pAConn.SessionModel = 1;
        pAMEtk = new pAMobileEtikett(pAConn);

        pAMEtk.paLogin("XMDE", "xGiese", "xmdepass", "", out cTicket);
      }
      catch (Open4GLException ex)
      {
        Console.WriteLine($"Open4GLException: {ex.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Exception: {ex.Message} - {ex.InnerException} - {ex.StackTrace}");
      }
      finally
      {
        Console.WriteLine($"Hello {cTicket}!");
        pAMEtk.pALogout(cTicket);
        pAConn?.Dispose();
        pAMEtk?.Dispose();
      }


    }
  }
}
