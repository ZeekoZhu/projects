namespace ProcessMon;

public interface IProcessMonitor
{
  public class ProcessEventArgs
  {
    public int ProcessId { get; set; }
    public string ProcessCommand { get; set; } = string.Empty;
  }

  public event EventHandler<ProcessEventArgs> ProcessStarted;


  public event EventHandler<ProcessEventArgs> ProcessStopped;

  public void Start();
  public void Stop();
}
