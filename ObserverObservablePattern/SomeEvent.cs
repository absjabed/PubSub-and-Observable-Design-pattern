using System;
public class SomeEvent{
    public string EventProviderName { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public SomeEvent(string _eventProviderName, string _description, DateTime _date){
        EventProviderName = _eventProviderName;
        Description = _description;
        Date = _date;
    }
}