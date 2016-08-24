namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        MultiDictionary<string, Event> groupByTitle = new MultiDictionary<string, Event>(true);
        OrderedBag<Event> groupByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            groupByTitle.Add(title.ToLower(), newEvent);
            groupByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in groupByTitle[title])
            {
                removed++;
                groupByDate.Remove(eventToRemove);
            }

            groupByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = groupByDate.RangeFrom(new Event(date, "", ""), true);

            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
