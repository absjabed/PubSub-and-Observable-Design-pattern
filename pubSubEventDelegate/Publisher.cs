using System;
using System.Threading;
class Publisher{
    public string PublisherName { get; private set; }
    public int NotificationInterval { get; private set; }

    //** Declare an Event...
    // declare a delegate with any name
    public delegate void Notify(Publisher p, NotificationEvent e);
    // declare a variable of the delegate with event keyword
    public event Notify OnPublish;

    
    public Publisher(string _publisherName, int _notificationInterval){
        PublisherName = _publisherName;
        NotificationInterval = _notificationInterval;
    }

    //publish function publishes a Notification Event
    public void Publish(){
        while (true){

            Thread.Sleep(NotificationInterval); // fire event after certain interval
            
            if (OnPublish != null)
            {
                NotificationEvent notificationObj = new NotificationEvent(DateTime.Now, "New Notification Arrived from");
                OnPublish(this, notificationObj);
            }
            Thread.Yield();
        }
    }
}
