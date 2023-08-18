using Tmds.Linux;

namespace ProcessMon;

using static Tmds.Linux.LibC;

public class LinuxProcessMonitor : IProcessMonitor
{
  public event EventHandler<IProcessMonitor.ProcessEventArgs>? ProcessStarted;
  public event EventHandler<IProcessMonitor.ProcessEventArgs>? ProcessStopped;
  // ReSharper disable once InconsistentNaming
  const int NETLINK_CONNECTOR = 11;

  public void Start()
  {
    int sockfd = socket(AF_NETLINK, SOCK_DGRAM, NETLINK_CONNECTOR);
    if (sockfd < 0)
    {
      Console.WriteLine("Error: " + errno);
    }
  }

  public void Stop()
  {
    throw new NotImplementedException();
  }
}
