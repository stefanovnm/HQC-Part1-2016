using System;
using Wintellect.PowerCollections;

namespace Events
{
    public class EventHolder
    {
        private MultiDictionary<string, Event> groupByTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> groupByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.groupByTitle.Add(title.ToLower(), newEvent);
            this.groupByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.groupByTitle[title])
            {
                removed++;
                this.groupByDate.Remove(eventToRemove);
            }

            this.groupByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.groupByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
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
